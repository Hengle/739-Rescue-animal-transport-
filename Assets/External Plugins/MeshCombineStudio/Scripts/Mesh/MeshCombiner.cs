using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace MeshCombineStudio
{
    public class MeshCombiner : MonoBehaviour
    {
        static public MeshCombiner instance;
        public enum HandleObjects { None, DisableRenderes, DisableGameObject, DisableParentGameObject, DeleteRenderers, DeleteGameObject, DeleteParentGameObject };
        public enum HandleLODGroups { None, Disable, Delete };

        public List<Transform> combinedList = new List<Transform>();
        public ObjectOctree.Cell octree;
        [NonSerialized] public bool octreeCreated;
        
        public int cellSize = 32;
        
        // public bool removeGeometryBelowTerrain;
        // public Transform[] terrains;
        
        public bool useVertexOutputLimit;
        public int vertexOutputLimit = 65534;
        public int[] lodObjectCount, lodObjectSearchCount;

        int _vertexOutputLimit;

        // Runtime Settings
        public bool combineInRuntime;
        public bool combineOnStart = true;
        public bool useCombineSwapKey;
        public KeyCode combineSwapKey = KeyCode.Tab;
        public HandleObjects originalObjects = HandleObjects.DisableRenderes;
        public HandleLODGroups originalObjectsLODGroups = HandleLODGroups.Disable;

        public bool addMeshColliders = false;
        public int lodAmount = 1;
        public string lodSearchText = "LOD";

        public SearchOptions searchOptions;

        public Vector3 oldPosition, oldScale;

        List<CachedGameObject> originalObjectList = new List<CachedGameObject>();
        List<CachedGameObject> combinedMeshList = new List<CachedGameObject>();

        public bool combined = false;

        public CombinedLODManager combinedLODManager;
        public bool combinedActive;

        List<Vector3> newVertices, newNormals;
        List<Vector4> newTangents;
        List<Color32> newColors;
        List<int> newTriangles;

        List<Vector2> newUvs1, newUvs2, newUvs3, newUvs4;

        List<Vector3> vertices, normals;
        List<Vector4> tangents;
        List<Color32> colors;
        List<Vector2> uvs1, uvs2, uvs3, uvs4;
        List<int> triangles;

        bool hasUv2, hasUv3, hasUv4, hasColors;

        int[] matTriangles;
       
        int vertexCount, triangleCount, splitIndex, startIndex;
        int totalVertexCount, totalTriangleCount, totalVertices, totalTriangles;
        int totalCombined = 0;

        GameObject combinedGO, uncombinedGO;
        Bounds bounds;

        [Serializable]
        public class SearchOptions
        {
            public GameObject parent;
            public bool drawGizmos = true;
            public bool searchBoxGridX = true;
            public bool searchBoxGridY = true;
            public bool searchBoxGridZ = true;
            public bool searchBoxSquare;
            public bool useVertexInputLimit;
            public int vertexInputLimit = 8000;

            public LayerMask layerMask = ~0;
            public bool useTag;
            public string tag;
            public bool nameContains;
            public List<string> nameContainList = new List<string>();
            public bool onlyStatic = true;

            public SearchOptions(GameObject parent)
            {
                this.parent = parent;
            }
        }

        [Serializable]
        public class CachedGameObject
        {
            public GameObject go;
            public Transform t;
            public MeshRenderer mr;
            public MeshFilter mf;

            public CachedGameObject(GameObject go, Transform t, MeshRenderer mr, MeshFilter mf)
            {
                this.go = go;
                this.t = t;
                this.mr = mr;
                this.mf = mf;
            }
        }

        private void Awake()
        {
            instance = this;
            StartRuntime();
        } // ==========================================================================================================================

        private void StartRuntime()
        {
            if (combineInRuntime && combineOnStart)
            {
                CombineLods();
                ExecuteHandleObjects(false);
            }
            if (useCombineSwapKey) gameObject.AddComponent<SwapCombineKey>();
        } // ==========================================================================================================================

        private void OnDestroy()
        {
            instance = null;
        } // ==========================================================================================================================

        void GetBounds()
        {
            bounds = new Bounds(transform.position + new Vector3(0, transform.lossyScale.y * 0.5f, 0), transform.lossyScale);
        } // ==========================================================================================================================

        void InitLists()
        {
            newVertices = new List<Vector3>(65534);
            newNormals = new List<Vector3>(65534);
            newTangents = new List<Vector4>(65534);
            newColors = new List<Color32>(65534);
            newTriangles = new List<int>(196602);

            newUvs1 = new List<Vector2>(65534);
            newUvs2 = new List<Vector2>(65534);
            newUvs3 = new List<Vector2>(65534);
            newUvs4 = new List<Vector2>(65534);

            vertices = new List<Vector3>(65534);
            normals = new List<Vector3>(65534);
            tangents = new List<Vector4>(65534);
            colors = new List<Color32>(65534);
            uvs1 = new List<Vector2>(65534);
            uvs2 = new List<Vector2>(65534);
            uvs3 = new List<Vector2>(65534);
            uvs4 = new List<Vector2>(65534);
            triangles = new List<int>(196602);
        }

        void GarbageCollectLists()
        {
            newVertices = newNormals = null;
            newTangents = null;
            newUvs1 = newUvs2 = newUvs3 = newUvs4 = null;
            newColors = null;
            newTriangles = null;

            vertices = normals = null;
            tangents = null;
            uvs1 = uvs2 = uvs3 = uvs4 = null;
            colors = null;
            triangles = null;
        }

        public void CalcOctreeSize()
        {
            float areaSize = transform.lossyScale.x;
            float tempSize = areaSize;
            int levels = 0;
            while (tempSize > cellSize) { tempSize /= 2; ++levels; }

            // Debug.Log("Level " + levels + " " + Mathf.Log(areaSize, cellSize));

            octree.maxLevels = levels;
            float size = (int)Mathf.Pow(2, levels) * cellSize;
            octree.bounds.center = transform.position + new Vector3(0, transform.lossyScale.y * 0.5f, 0);
            octree.bounds.size = new Vector3(size, size, size);
        } // ==========================================================================================================================

        public void ResetOctree()
        {
            // Debug.Log("ResetOctree");
            octreeCreated = false;

            if (octree == null)
            {
                octree = new ObjectOctree.Cell();
                return;
            }

            totalCombined = 0;
            BaseOctree.Cell[] cells = octree.cells;
            octree.Reset(ref cells);
        } // ==========================================================================================================================

        public void AddToOctree()
        {
            // Debug.Log("Add to Octree");
            originalObjectList.Clear();
            combinedMeshList.Clear();

            ResetOctree();
            CalcOctreeSize();
            GetBounds();

            ObjectOctree.lodCount = lodAmount;
            ObjectOctree.MaxCell.maxCellCount = 0;
            lodObjectCount = new int[lodAmount];
            lodObjectSearchCount = new int[lodAmount];

            for (int i = 0; i < lodAmount; i++)
            {
                AddObjects(i);
            }

            //if (faultObject != null)
            //{
            //    Selection.activeObject = faultObject;
            //    //ShowNotification(new GUIContent("This Mesh Renderer has no material assigned!"));
            //}
        } // ==========================================================================================================================

        public void AddCombinedLODManager()
        {
            combinedLODManager = GetComponent<CombinedLODManager>();
            if (combinedLODManager == null) combinedLODManager = gameObject.AddComponent<CombinedLODManager>();

            combinedLODManager.UpdateLods(this, lodAmount);
        }

        public void DestroyCombinedLODManager()
        {
            combinedLODManager = GetComponent<CombinedLODManager>();
            if (combinedLODManager != null) DestroyImmediate(combinedLODManager);
        }

        public void DestroyCombinedGameObjects()
        {
            combined = false;
            for (int i = 0; i < combinedList.Count; i++)
            {
                if (combinedList[i] != null) DestroyImmediate(combinedList[i].gameObject);
            }
            combinedList.Clear();
        } // ==========================================================================================================================

        public void SetCombinedGameObjects(bool active)
        {
            if (combinedLODManager != null) combinedLODManager.enabled = active;

            for (int i = 0; i < combinedList.Count; i++)
            {
                if (combinedList[i] != null) combinedList[i].gameObject.SetActive(active);
            }
        }

        public void SwapCombine()
        {
            if (!combined) { CombineLods(); }

            combinedActive = !combinedActive;
            SetCombinedGameObjects(combinedActive);
            ExecuteHandleObjects(!combinedActive);
        }

        public void ExecuteHandleObjects(bool active)
        {
            // DisableRenderes, DisableGameObject, DisableParentGameObject, DeleteRenderers, DeleteGameObject, DeleteParentGameObject
            if (originalObjects == HandleObjects.DisableRenderes)
            {
                for (int i = 0; i < originalObjectList.Count; i++) originalObjectList[i].mr.enabled = active;
            }
            else if (originalObjects == HandleObjects.DisableGameObject)
            {
                for (int i = 0; i < originalObjectList.Count; i++) originalObjectList[i].go.SetActive(active);
            }
            else if (originalObjects == HandleObjects.DisableParentGameObject)
            {
                for (int i = 0; i < originalObjectList.Count; i++)
                {
                    CachedGameObject cachedGO = originalObjectList[i];
                    if (cachedGO.t.parent != null) cachedGO.t.parent.gameObject.SetActive(active);
                }
            }
            else if (originalObjects == HandleObjects.DeleteRenderers)
            {
                for (int i = 0; i < originalObjectList.Count; i++)
                {
                    CachedGameObject cachedGO = originalObjectList[i];
                    Destroy(cachedGO.mf);
                    Destroy(cachedGO.mr);
                }
            }
            else if (originalObjects == HandleObjects.DeleteGameObject)
            {
                for (int i = 0; i < originalObjectList.Count; i++)
                {
                    CachedGameObject cachedGO = originalObjectList[i];
                    if (cachedGO.go != null) Destroy(cachedGO.go);
                }
            }
            else if (originalObjects == HandleObjects.DeleteParentGameObject)
            {
                for (int i = 0; i < originalObjectList.Count; i++)
                {
                    CachedGameObject cachedGO = originalObjectList[i];
                    if (cachedGO.t != null)
                    {
                        if (cachedGO.t.parent != null) Destroy(cachedGO.t.parent.gameObject);
                    }
                }
            }

            if (originalObjectsLODGroups == HandleLODGroups.Disable)
            {
                for (int i = 0; i < originalObjectList.Count; i++)
                {
                    CachedGameObject cachedGO = originalObjectList[i];
                    if (cachedGO.t != null)
                    {
                        LODGroup lodGroup = cachedGO.t.GetComponentInParent<LODGroup>();
                        if (lodGroup != null) lodGroup.enabled = active;
                    }
                }
            }
            else if (originalObjectsLODGroups == HandleLODGroups.Delete)
            {
                for (int i = 0; i < originalObjectList.Count; i++)
                {
                    CachedGameObject cachedGO = originalObjectList[i];
                    if (cachedGO.t != null)
                    {
                        LODGroup lodGroup = cachedGO.t.GetComponentInParent<LODGroup>();
                        if (lodGroup != null) Destroy(lodGroup);
                    }
                }
            }
        }

        public void CombineLods()
        {
            DestroyCombinedGameObjects();
            if (!octreeCreated || combined) AddToOctree();
            if (!octreeCreated) return;
            if (newVertices == null) InitLists();
            // if (octree == null) Debug.Log("Octree is null");
            
            for (int i = 0; i < lodAmount; i++) Combine(i);
            
            if (lodAmount > 1)
            {
                if (combinedLODManager == null) combinedLODManager = gameObject.AddComponent<CombinedLODManager>();
                combinedLODManager.lods = new CombinedLODManager.LOD[lodAmount];
                combinedLODManager.distances = new float[lodAmount];

                for (int i = 0; i < lodAmount; i++)
                {
                    combinedLODManager.lods[i] = new CombinedLODManager.LOD(combinedList[i]);
                    combinedLODManager.distances[i] = i * cellSize;
                }

                combinedLODManager.ResetOctree();
                combinedLODManager.octreeCenter = octree.bounds.center;
                combinedLODManager.octreeSize = octree.bounds.size;
                combinedLODManager.maxLevels = octree.maxLevels;
            }

            combinedActive = true;
            combined = true;

            GarbageCollectLists();
        } // ==========================================================================================================================

        //public void RemoveGeometryBelowTerrain()
        //{
        //    if (RemoveGeometryBelowTerrain.IsMeshUnderTerrain(t, mesh))
        //    {
        //        List<int> triangleList = new List<int>(triangles);
        //        RemoveGeometryBelowTerrain.RemoveTriangles(t, triangleList, vertices);
        //        triangles = triangleList.ToArray();
        //    }
        //}
    
        public void Combine(int lodLevel)
        {
            uncombinedGO = new GameObject("_Umcombined");
            octree.UncombineMeshes(this, lodLevel);
            
            octree.SortObjects(lodLevel);
            combinedGO = new GameObject("Combined" + (lodAmount > 1 ? " " + lodSearchText + lodLevel.ToString() : ""));

            combinedGO.transform.parent = transform;

            if (useVertexOutputLimit) _vertexOutputLimit = vertexOutputLimit; else _vertexOutputLimit = 65534;

            octree.CombineMeshes(this, lodLevel);
            DestroyImmediate(uncombinedGO);

            combinedList.Add(combinedGO.transform);

            // combinedGO.SetActive(false);

            // Debug.Log("Total combined " + totalCombined);
        } // ==========================================================================================================================


        public void AddObjects(int lodLevel)
        {
            if (searchOptions.parent == null)
            {
                Debug.Log("You need to assign a 'Parent' GameObject in which meshes will be searched");
                return;
            }

            Transform[] transforms = searchOptions.parent.GetComponentsInChildren<Transform>();
            // Debug.Log(transforms.Length);
            AddTransforms(transforms, lodLevel);

        } // ==========================================================================================================================

        void AddTransforms(Transform[] transforms, int lodLevel)
        {
            string currentLodText = lodSearchText + lodLevel.ToString();

            // Debug.Log("Transforms " + transforms.Length);

            lodObjectSearchCount[lodLevel] = transforms.Length;
            
            for (int i = 0; i < transforms.Length; i++)
            {
                Transform t = transforms[i];

                int layer = 1 << t.gameObject.layer;
                if ((searchOptions.layerMask.value & layer) != layer) continue;

                if (searchOptions.useTag)
                {
                    if (!t.CompareTag(searchOptions.tag)) continue;
                }

                MeshRenderer mr = t.GetComponent<MeshRenderer>();
                if (mr == null) continue;
                if (!bounds.Contains(mr.bounds.center))
                {
                    continue;
                }
                if (searchOptions.onlyStatic && !t.gameObject.isStatic)
                {
                    continue;
                }

                MeshFilter mf = t.GetComponent<MeshFilter>();
                if (mf == null) continue;

                Mesh m = mf.sharedMesh;
                if (m == null) continue;
                if (searchOptions.useVertexInputLimit && m.vertexCount > searchOptions.vertexInputLimit) continue;

                if (searchOptions.nameContains)
                {
                    bool found = false;
                    for (int k = 0; k < searchOptions.nameContainList.Count; k++)
                    {
                        if (Methods.Contains(t.name, searchOptions.nameContainList[k])) { found = true; break; }
                    }
                    if (!found) continue;
                }
                if (lodAmount > 1 && !t.name.Contains(currentLodText)) continue;

                ++lodObjectCount[lodLevel];
                int submeshCount = m.subMeshCount;
                // Debug.Log("Submesh count " + submeshCount);
                bool isObjectAdded = octree.AddObject(t, mr, submeshCount > 1 ? false : true, lodLevel);

                if (isObjectAdded)
                {
                    originalObjectList.Add(new CachedGameObject(t.gameObject, t, mr, mf));
                }
            }

            // Debug.Log("Count " + count);

            if (lodObjectCount[lodLevel] > 0) octreeCreated = true; 
            else 
            {
                Debug.Log("No matching GameObjects with LOD "+ lodLevel +" 'Search Options' are found for combining.");
            }
        } // ==========================================================================================================================

        public void CombineMeshes(SingleMeshes sortedMesh, Vector3 center)
        {
            totalCombined += sortedMesh.meshes.Count;

            splitIndex = 0;
            totalVertexCount = 0;
            totalTriangleCount = 0;

            bool split;
            int count = 0;

            do
            {
                split = CountVertices(sortedMesh);
                CombineMesh(sortedMesh, center);
                CreateMesh(null, combinedGO.transform, sortedMesh, center, 0, false, count++);
            }
            while (split);

            splitIndex = 0;
        } // ==========================================================================================================================

        bool CountVertices(SingleMeshes sortedMesh)
        {
            totalVertices = 0;
            totalTriangles = 0;
            startIndex = splitIndex;
            bool split = false;

            for (int i = splitIndex; i < sortedMesh.meshes.Count; ++i)
            {
                MeshInfo meshInfo = sortedMesh.meshes[i];
                // meshInfo.RemoveGeometry();
                Mesh mesh = meshInfo.mesh;

                if (totalVertices + mesh.vertexCount > _vertexOutputLimit) { splitIndex = i; split = true; break; }
                totalVertices += mesh.vertexCount;
                totalTriangles += (int)mesh.GetIndexCount(0);
            }
            if (!split) splitIndex = sortedMesh.meshes.Count;
            
            // if (totalTriangles != totalTriangleCount) { newTriangles = new int[totalTriangles]; }
            // Debug.Log (totalVertices);

            return split;
        } // ==========================================================================================================================
        
        void ClearNewLists()
        {
            newVertices.Clear(); newNormals.Clear(); newTangents.Clear();
            newUvs1.Clear(); newUvs2.Clear(); newUvs3.Clear(); newUvs4.Clear();
            newColors.Clear();
            newTriangles.Clear();
        }


        void CombineMesh(SingleMeshes sortedMesh, Vector3 center)
        {
            totalVertexCount = 0;
            totalTriangleCount = 0;

            ClearNewLists();
            
            for (int count = startIndex; count < splitIndex; ++count)
            {
                MeshInfo meshInfo = sortedMesh.meshes[count];
                Transform t = meshInfo.t;
                Vector3 pos = t.position;
                Quaternion rotation = t.rotation;
                Vector3 scale = t.lossyScale;

                Vector3 newPos = pos - center;
                Mesh mesh = meshInfo.mesh;
        
                mesh.GetVertices(vertices);
                mesh.GetTriangles(triangles, 0);
                mesh.GetNormals(normals);
                mesh.GetTangents(tangents);
                
                hasUv2 = hasUv3 = hasUv4 = hasColors = false;

                vertexCount = vertices.Count;
                triangleCount = triangles.Count;

                mesh.GetUVs(0, uvs1);
                mesh.GetUVs(1, uvs2);
                mesh.GetUVs(2, uvs3);
                mesh.GetUVs(3, uvs4);
                mesh.GetColors(colors);

                if (uvs2.Count > 0) hasUv2 = true;
                if (uvs3.Count > 0) hasUv3 = true;
                if (uvs4.Count > 0) hasUv4 = true;
                if (colors.Count > 0) hasColors = true;

                for (int i = 0; i < vertexCount; ++i)
                {
                    Vector3 vertexPos = t.TransformPoint(vertices[i]) - pos;
                    newVertices.Add(vertexPos + newPos);
                    newNormals.Add(rotation * normals[i]);
                    Vector4 newTangent = rotation * tangents[i];
                    newTangent.w = tangents[i].w;
                    newTangents.Add(newTangent);
                    
                    newUvs1.Add(uvs1[i]);
                    if (hasUv2) newUvs2.Add(uvs2[i]);
                    if (hasUv3) newUvs3.Add(uvs3[i]);
                    if (hasUv4) newUvs4.Add(uvs4[i]);
                    if (hasColors) newColors.Add(colors[i]);
                }

                for (int i = 0; i < triangleCount; ++i)
                {
                    newTriangles.Add(triangles[i] + totalVertexCount);
                }

                totalVertexCount += vertexCount;
                totalTriangleCount += triangleCount;
            }
        } // ==========================================================================================================================

        string ClusterName(string name)
        {
            int length = name.Length;
            for (int i = length - 1; i >= 0; i -= 2)
            {
                name = name.Insert(i, "-");
            }
            return name;
        } // ==========================================================================================================================

        MeshRenderer CreateMesh(Transform t, Transform parent, SingleMeshes sortedMesh, Vector3 center, int matIndex, bool rotate, int meshIndex)
        {
            string name;
            if (t != null) name = (t.name);
            else name = (sortedMesh.mat.name);

            GameObject go = new GameObject(name);

            Transform newT = go.transform;
            newT.parent = parent;
            newT.position = center;

            if (rotate) newT.rotation = t.rotation;
            
            MeshFilter mf = go.AddComponent<MeshFilter>() as MeshFilter;
            Mesh mesh = new Mesh();
            mesh.name = name + "_" + meshIndex;

            MeshRenderer mr = go.AddComponent<MeshRenderer>();

            // Material[] sharedMats = t.GetComponent<MeshRenderer>().sharedMaterials;

            //if (matIndex > sharedMats.Length - 1)
            //{
            //    UnityEditor.Selection.activeTransform = t;
            //    Debug.Log(matIndex + " " + sharedMats.Length);
            //}

            if (t != null) mr.sharedMaterial = t.GetComponent<MeshRenderer>().sharedMaterials[matIndex];
            else mr.sharedMaterial = sortedMesh.mat;
            // mr.motionVectorGenerationMode = MotionVectorGenerationMode.Camera;

            mesh.SetVertices(newVertices);
            mesh.SetTriangles(newTriangles, 0);
            mesh.SetTangents(newTangents);
            mesh.SetNormals(newNormals);
            
            mesh.SetUVs(0, newUvs1);
            if (hasUv2) mesh.SetUVs(1, newUvs2);
            if (hasUv3) mesh.SetUVs(2, newUvs3);
            if (hasUv4) mesh.SetUVs(3, newUvs4);

            if (hasColors) mesh.SetColors(newColors);

            mf.sharedMesh = mesh;
            if (addMeshColliders) go.AddComponent<MeshCollider>();
            go.AddComponent<GarbageCollectMesh>();

            if (rotate) combinedMeshList.Add(new CachedGameObject(go, newT, mr, mf));

            return mr;
        } // ==========================================================================================================================

        public void DisplayUVs(List<Vector2> uv)
        {
            for (int i = 0; i < uv.Count; i++)
            {
                Debug.Log(uv[i].x + " " + uv[i].y);
            }
        } // ==========================================================================================================================

        public void DisplayColors(Mesh mesh)
        {
            Color32[] newColors = mesh.colors32;

            for (int i = 0; i < newColors.Length; i++)
            {
                Debug.Log(newColors[i].r + " " + newColors[i].g + " " + newColors[i].b + " " + newColors[i].a);
            }
        } // ==========================================================================================================================

        public void UncombineMeshes(List<Transform> transforms, int lodLevel)
        {
            Transform t;

            for (int i = 0; i < transforms.Count; ++i)
            {
                t = transforms[i];
                UncombineMesh(t, lodLevel);
                // Debug.Log(subLength);
            }
        } // ==========================================================================================================================

        int subTriangleCountOld;
        int[] vertexTable = new int[65534];

        public int UncombineMesh(Transform t, int lodLevel)
        {
            Mesh mesh = t.GetComponent<MeshFilter>().sharedMesh;
            int matLength = t.GetComponent<MeshRenderer>().sharedMaterials.Length;
            int subMeshLength = mesh.subMeshCount;
            int subLength = subMeshLength > matLength ? matLength : subMeshLength;
            Vector3 scale = t.lossyScale;
            
            if (subLength > 1)
            {
                // Debug.Log(scale);
                // Debug.Log(t.name + " submeshes " + subLength);
                vertices.Clear(); normals.Clear(); tangents.Clear();
                uvs1.Clear(); uvs2.Clear(); uvs3.Clear(); uvs4.Clear();
                colors.Clear();
                
                mesh.GetVertices(vertices);
                mesh.GetNormals(normals);
                mesh.GetTangents(tangents);
                
                hasUv2 = hasUv3 = hasUv4 = hasColors = false;

                mesh.GetUVs(0, uvs1);
                mesh.GetUVs(1, uvs2);
                mesh.GetUVs(2, uvs3);
                mesh.GetUVs(3, uvs4);
                mesh.GetColors(colors);

                if (uvs2.Count > 0) hasUv2 = true;
                if (uvs3.Count > 0) hasUv3 = true;
                if (uvs4.Count > 0) hasUv4 = true;
                if (colors.Count > 0) hasColors = true;
                
                for (int i = 0; i < subLength; ++i)
                {
                    ClearNewLists();

                    int newVertexIndex = 0;
                    triangles.Clear();
                    mesh.GetTriangles(triangles, i);
                    
                    for (int j = 0; j < triangles.Count; j++)
                    {
                        vertexTable[triangles[j]] = -1;
                    }

                    for (int j = 0; j < triangles.Count; ++j)
                    {
                        int vertexIndex = triangles[j];

                        if (vertexTable[vertexIndex] == -1)
                        {
                            newVertices.Add(Vector3.Scale(vertices[vertexIndex], scale));
                            newNormals.Add(normals[vertexIndex]);
                            newTangents.Add(tangents[vertexIndex]);

                            newUvs1.Add(uvs1[vertexIndex]); 
                            if (hasUv2) newUvs2.Add(uvs2[vertexIndex]);
                            if (hasUv3) newUvs3.Add(uvs3[vertexIndex]);
                            if (hasUv4) newUvs4.Add(uvs4[vertexIndex]);
                            if (hasColors) newColors.Add(colors[vertexIndex]);

                            newTriangles.Add(newVertexIndex);
                            vertexTable[vertexIndex] = newVertexIndex++;
                        }
                        else
                        {
                            newTriangles.Add(vertexTable[vertexIndex]);
                        }
                    }
                    
                    MeshRenderer mr = CreateMesh(t, uncombinedGO.transform, null, t.position, i, true, i);
                    octree.AddObject(mr.transform, mr, true, lodLevel);
                }
            }
            return subLength;
        } // ==========================================================================================================================

        void OnDrawGizmosSelected()
        {
            if (!searchOptions.drawGizmos) return;
            Vector3 size = transform.lossyScale;

            int xCells = Mathf.CeilToInt(Mathf.Ceil(size.x / cellSize) / 2) * 2;
            int yCells = Mathf.CeilToInt(size.y / cellSize);
            int zCells = Mathf.CeilToInt(Mathf.Ceil(size.z / cellSize) / 2) * 2;

            size = new Vector3(xCells * cellSize, yCells * cellSize, zCells * cellSize);

            Vector3 position = transform.position - new Vector3(size.x * 0.5f, 0, size.z * 0.5f);
            Vector3 offset = new Vector3(cellSize * 0.5f, 0, cellSize * 0.5f);

            Gizmos.color = Color.white;

            if (octree != null && octreeCreated)
            {
                octree.Draw(true);
            }
            else
            {
                if (searchOptions.searchBoxGridX)
                {
                    for (int x = 0; x < xCells; x++)
                    {
                        for (int z = 0; z < zCells; z++)
                        {
                            Gizmos.DrawWireCube(position + offset + new Vector3(x * cellSize, 0 * cellSize, z * cellSize), new Vector3(cellSize, 0, cellSize));
                        }
                    }
                }

                if (searchOptions.searchBoxGridZ)
                {
                    for (int x = 0; x < xCells; x++)
                    {
                        for (int y = 0; y < yCells; y++)
                        {
                            Gizmos.DrawWireCube(position + new Vector3(cellSize * 0.5f, cellSize * 0.5f, 0) + new Vector3(x * cellSize, y * cellSize, zCells * cellSize), new Vector3(cellSize, cellSize, 0));
                        }
                    }
                }

                if (searchOptions.searchBoxGridY)
                {
                    for (int z = 0; z < zCells; z++)
                    {
                        for (int y = 0; y < yCells; y++)
                        {
                            Gizmos.DrawWireCube(position + new Vector3(0, cellSize * 0.5f, cellSize * 0.5f) + new Vector3(0 * cellSize, y * cellSize, z * cellSize), new Vector3(0, cellSize, cellSize));
                        }
                    }
                }

                Gizmos.color = new Color(1, 1, 1, 0.25f);
                if (searchOptions.searchBoxGridX) Gizmos.DrawCube(transform.position, new Vector3(size.x, 0, size.z));
                if (searchOptions.searchBoxGridY) Gizmos.DrawCube(transform.position + new Vector3(-(xCells * cellSize) * 0.5f, (yCells * cellSize) * 0.5f, 0), new Vector3(0, size.y, size.z));
                if (searchOptions.searchBoxGridZ) Gizmos.DrawCube(transform.position + new Vector3(0, (yCells * cellSize) * 0.5f, (zCells * cellSize) * 0.5f), new Vector3(size.x, size.y, 0));
                Gizmos.color = Color.white;
            }

            GetBounds();

            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
            Gizmos.color = Color.white;

        } // ==========================================================================================================================
    }
}