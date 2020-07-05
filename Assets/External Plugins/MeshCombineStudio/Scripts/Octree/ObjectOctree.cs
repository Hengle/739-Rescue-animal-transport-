using UnityEngine;
using System;
using System.Collections.Generic;

namespace MeshCombineStudio
{
    [Serializable]
    public class SingleMeshes
    {
        public Material mat;
        public List<MeshInfo> meshes = new List<MeshInfo>();

        public SingleMeshes(Transform t, Material mat, Mesh mesh)
        {
            this.mat = mat;
            meshes.Add(new MeshInfo(t, mesh));
        }
    }

    [Serializable]
    public class MeshInfo
    {
        public Transform t;
        public Mesh mesh;
        // public Vector3[] vertices;
        // public int[] triangles;

        public MeshInfo(Transform t, Mesh mesh)
        {
            this.t = t;
            this.mesh = mesh;

            // vertices = mesh.vertices;
            // triangles = mesh.triangles;
        }
    }

    public class ObjectOctree
    {
        static public int lodCount;

        public class LOD
        {
            public List<Transform> transforms = new List<Transform>();
            public List<Transform> singleTransforms = new List<Transform>();
            public List<SingleMeshes> sortedMeshes;
            public int vertCount, objectCount = 0;

            public int GetSortMeshIndex(Material mat)
            {
                for (int i = 0; i < sortedMeshes.Count; i++)
                {
                    if (mat == null) Debug.Log("Material null");
                    if (sortedMeshes[i].mat == null) Debug.Log("Sorted mat null");
                    // match materials not only by name, but also by texture (combined speedtree leaves has material of the same name while materials are obviously different due to textures used)
                    if (sortedMeshes[i].mat.name == mat.name && sortedMeshes[i].mat.shader == mat.shader && (!mat.HasProperty("_MainTex") || (mat.HasProperty("_MainTex") && sortedMeshes[i].mat.GetTexture("_MainTex") == mat.GetTexture("_MainTex")))) return i;
                }
                return -1;
            }
        }

        public class MaxCell : Cell
        {
            static public int maxCellCount;
            public LOD[] lods;
        }

        public class Cell : BaseOctree.Cell
        {
            new public Cell[] cells;

            public Cell() { }
            public Cell(Vector3 position, Vector3 size, int maxLevels) : base(position, size, maxLevels) { }

            public bool AddObject(Transform t, MeshRenderer mr, bool addToSingle, int lodLevel)
            {
                Vector3 position = t.position;
                if (InsideBounds(position))
                {
                    AddObjectInternal(t, position, addToSingle, lodLevel);
                    return true;
                }
                return false;
            }

            void AddObjectInternal(Transform t, Vector3 position, bool addToSingle, int lodLevel)
            {
                if (level == maxLevels)
                {
                    MaxCell thisCell = (MaxCell)this;

                    if (thisCell.lods == null) thisCell.lods = new LOD[lodCount];
                    if (thisCell.lods[lodLevel] == null) thisCell.lods[lodLevel] = new LOD();
                    
                    LOD lod = thisCell.lods[lodLevel];

                    if (lod.transforms == null) lod.transforms = new List<Transform>();

                    if (addToSingle) lod.singleTransforms.Add(t);
                    else lod.transforms.Add(t);

                    lod.objectCount++;

                    MeshFilter mf = t.GetComponent<MeshFilter>();
                    Mesh m = mf.sharedMesh;
                    lod.vertCount += m.vertexCount;
                    return;
                }
                else
                {
                    bool maxCellCreated;
                    int index = AddCell<Cell, MaxCell>(ref cells, position, out maxCellCreated);
                    if (maxCellCreated) MaxCell.maxCellCount++;
                    cells[index].AddObjectInternal(t, position, addToSingle, lodLevel);
                }
            }

            public void SortObjects(int lodLevel)
            {
                if (level == maxLevels)
                {
                    MaxCell thisCell = (MaxCell)this;
                    LOD lod = thisCell.lods[lodLevel];

                    if (lod == null) return;

                    lod.sortedMeshes = new List<SingleMeshes>();

                    for (int i = 0; i < lod.singleTransforms.Count; ++i)
                    {
                        Transform t = lod.singleTransforms[i];
                        MeshFilter mf = t.GetComponent<MeshFilter>();
                        MeshRenderer mr = t.GetComponent<MeshRenderer>();
                        Material mat = mr.sharedMaterial;
                        Mesh mesh = mf.sharedMesh;

                        int index = lod.GetSortMeshIndex(mat);
                        if (index != -1) lod.sortedMeshes[index].meshes.Add(new MeshInfo(t, mesh));
                        else lod.sortedMeshes.Add(new SingleMeshes(t, mat, mesh));
                    }
                }
                else
                {
                    for (int i = 0; i < 8; ++i)
                    {
                        if (cellsUsed[i]) cells[i].SortObjects(lodLevel);
                    }
                }
            }



            public void SetObjectsActive(bool active, int lodLevel)
            {
                if (level == maxLevels)
                {
                    MaxCell thisCell = (MaxCell)this;
                    LOD lod = thisCell.lods[lodLevel];

                    for (int i = 0; i < lod.sortedMeshes.Count; ++i)
                    {

                    }
                }
                else
                {
                    for (int i = 0; i < 8; ++i)
                    {
                        if (cellsUsed[i]) cells[i].SetObjectsActive(active, lodLevel);
                    }
                }
            }

            public void CombineMeshes(MeshCombiner meshCombiner, int lodLevel)
            {
                if (level == maxLevels)
                {
                    MaxCell thisCell = (MaxCell)this;
                    LOD lod = thisCell.lods[lodLevel];

                    if (lod == null) return;

                    for (int i = 0; i < lod.sortedMeshes.Count; ++i)
                    {
                        meshCombiner.CombineMeshes(lod.sortedMeshes[i], bounds.center);
                    }
                }
                else
                {
                    for (int i = 0; i < 8; ++i)
                    {
                        if (cellsUsed[i]) cells[i].CombineMeshes(meshCombiner, lodLevel);
                    }
                }
            }

            public void UncombineMeshes(MeshCombiner meshCombiner, int lodLevel)
            {
                if (level == maxLevels)
                {
                    MaxCell thisCell = (MaxCell)this;
                    LOD lod = thisCell.lods[lodLevel];
                    // Debug.Log("Multi Count " + lod.transforms.Count);
                    // Debug.Log("Single Count " + lod.singleTransforms.Count);
                    if (lod == null)
                    {
                        Debug.Log("-------------");
                        for (int i = 0; i < 3; i++)
                        {
                            LOD lod0 = thisCell.lods[i];
                            if (lod0 == null) Debug.Log(i);
                        }
                        Debug.Log("-------------");
                        return;
                    }

                    meshCombiner.UncombineMeshes(lod.transforms, lodLevel);
                }
                else
                {
                    for (int i = 0; i < 8; ++i)
                    {
                        if (cellsUsed[i])
                        {
                            if (cells[i] == null) Debug.Log(i);
                            cells[i].UncombineMeshes(meshCombiner, lodLevel);
                        }
                    }
                }
            }

            public void Draw(bool onlyMaxLevel)
            {
                if (!onlyMaxLevel || level == maxLevels)
                {
                    Gizmos.DrawWireCube(bounds.center, bounds.size);
                    if (level == maxLevels) return;
                }

                if (cells == null) { Debug.Log(level); }
                if (cellsUsed == null) { Debug.Log("f " + level); }

                for (int i = 0; i < 8; i++)
                {
                    if (cellsUsed[i]) cells[i].Draw(onlyMaxLevel);
                }
            }
        }
    }
}