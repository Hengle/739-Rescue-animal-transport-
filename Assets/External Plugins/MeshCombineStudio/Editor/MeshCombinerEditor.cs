using UnityEngine;
using UnityEditor;
using System.Collections;

namespace MeshCombineStudio
{
    [CustomEditor(typeof(MeshCombiner))]
    public class MeshCombinerEditor : Editor
    {
        GameObject meshCombine;
        MeshCombiner meshCombiner;

        // Search Options
        SerializedProperty searchOptions, drawGizmos, searchBoxSquare, parent, useVertexInputLimit, vertexInputLimit, layerMask, useTag, tag, nameContains, nameContainList, onlyStatic;
        SerializedProperty searchBoxGridX, searchBoxGridY, searchBoxGridZ;

        // Output Settings
        SerializedProperty cellSize, useVertexOutputLimit, vertexOutputLimit, addMeshColliders, lodAmount, lodSeachText; //, removeGeometryBelowTerrain, terrains;

        // Runtime
        SerializedProperty combineInRuntime, combineOnStart, useCombineSwapKey, combineSwapKey, originalObjects, originalObjectsLODGroups;

        float editorSkinMulti;

        private void OnEnable()
        {
            editorSkinMulti = EditorGUIUtility.isProSkin ? 1 : 0.35f;

            // SearchParent
            searchOptions = serializedObject.FindProperty("searchOptions");
            drawGizmos = searchOptions.FindPropertyRelative("drawGizmos");
            searchBoxGridX = searchOptions.FindPropertyRelative("searchBoxGridX");
            searchBoxGridY = searchOptions.FindPropertyRelative("searchBoxGridY");
            searchBoxGridZ = searchOptions.FindPropertyRelative("searchBoxGridZ");
            searchBoxSquare = searchOptions.FindPropertyRelative("searchBoxSquare");
            parent = searchOptions.FindPropertyRelative("parent");
            useVertexInputLimit = searchOptions.FindPropertyRelative("useVertexInputLimit");
            vertexInputLimit = searchOptions.FindPropertyRelative("vertexInputLimit");
            layerMask = searchOptions.FindPropertyRelative("layerMask");
            useTag = searchOptions.FindPropertyRelative("useTag");
            tag = searchOptions.FindPropertyRelative("tag");
            onlyStatic = searchOptions.FindPropertyRelative("onlyStatic");
            nameContains = searchOptions.FindPropertyRelative("nameContains");
            nameContainList = searchOptions.FindPropertyRelative("nameContainList");

            // Output Settings
            cellSize = serializedObject.FindProperty("cellSize");
            addMeshColliders = serializedObject.FindProperty("addMeshColliders");
            useVertexOutputLimit = serializedObject.FindProperty("useVertexOutputLimit");
            vertexOutputLimit = serializedObject.FindProperty("vertexOutputLimit");
            lodAmount = serializedObject.FindProperty("lodAmount");
            lodSeachText = serializedObject.FindProperty("lodSearchText");
            // removeGeometryBelowTerrain = serializedObject.FindProperty("removeGeometryBelowTerrain");
            // terrains = serializedObject.FindProperty("terrains");

            // Runtime
            combineInRuntime = serializedObject.FindProperty("combineInRuntime");
            combineOnStart = serializedObject.FindProperty("combineOnStart");
            useCombineSwapKey = serializedObject.FindProperty("useCombineSwapKey");
            combineSwapKey = serializedObject.FindProperty("combineSwapKey");
            originalObjects = serializedObject.FindProperty("originalObjects");
            originalObjectsLODGroups = serializedObject.FindProperty("originalObjectsLODGroups");
        }

        void OnSceneGUI()
        {
            ApplyScaleLimit();
            ApplyCombinedLock();
        }

        public override void OnInspectorGUI()
        {
            meshCombiner = (MeshCombiner)target;
            serializedObject.Update();

            DrawInspectorGUI();
            serializedObject.ApplyModifiedProperties();

            // DrawDefaultInspector();

            if (!meshCombiner.combined && (meshCombiner.transform.position != meshCombiner.oldPosition || meshCombiner.transform.lossyScale != meshCombiner.oldScale))
            {
                if (meshCombiner.octreeCreated)
                {
                    // Debug.Log("Reset");
                    meshCombiner.ResetOctree();
                }
                meshCombiner.oldPosition = meshCombiner.transform.position;
                meshCombiner.oldScale = meshCombiner.transform.localScale;
            }

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Search"))
            {
                meshCombiner.AddToOctree();
                SceneView.RepaintAll();
            }
            
            Transform t = meshCombiner.transform;

            if (searchBoxSquare.boolValue)
            {
                Vector3 localScale = t.localScale;
                t.localScale = new Vector3(localScale.x, localScale.x, localScale.x);
            }
            
            if (!combineInRuntime.boolValue)
            { 
                GUILayout.Space(10);
                if (GUILayout.Button("Combine")) meshCombiner.CombineLods();
            }
            
            EditorGUILayout.EndHorizontal();
            if (meshCombiner.octreeCreated) DisplayOctreeInfo();

            GUIDraw.DrawSpacer();
            if (meshCombiner.combinedList.Count > 0)
            {
                if (GUILayout.Button("Delete Combined Objects"))
                {
                    meshCombiner.DestroyCombinedGameObjects();
                }
                GUIDraw.DrawSpacer();
            }

            
        }

        void ApplyScaleLimit()
        {
            meshCombiner = (MeshCombiner)target;
            Vector3 scale = meshCombiner.transform.localScale;
            Vector3 newScale = scale;

            if (newScale.x < 0.01f) newScale.x = 0.01f;
            if (newScale.y < 0.01f) newScale.y = 0.01f;
            if (newScale.z < 0.01f) newScale.z = 0.01f;

            if (newScale != scale) meshCombiner.transform.localScale = newScale;
        }

        void ApplyCombinedLock()
        {
            meshCombiner = (MeshCombiner)target;
            if (meshCombiner.transform.childCount == 0) meshCombiner.combined = false;

            if (!meshCombiner.combined) return;

            meshCombiner.transform.position = meshCombiner.oldPosition;
            meshCombiner.transform.localScale = meshCombiner.oldScale;
        }

        void DrawInspectorGUI()
        {
            GUIDraw.DrawSpacer();
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Version 1.0");

            GUI.backgroundColor = Color.green;
            if (GUILayout.Button("Documentation"))
            {
                Application.OpenURL("http://www.terraincomposer.com/mcs-documentation/");
            }
            GUI.backgroundColor = Color.white;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            GUIDraw.DrawSpacer();
            DrawSearchOptions(Color.red * editorSkinMulti);
            GUIDraw.DrawSpacer();
            DrawOutputSettings(Color.blue * editorSkinMulti);
            GUIDraw.DrawSpacer();
            DrawRuntime(Color.green * editorSkinMulti);
            GUIDraw.DrawSpacer();
        }

        void DisplayOctreeInfo()
        {
            int lodCount = ObjectOctree.lodCount;

            EditorGUILayout.LabelField("Cells " + ObjectOctree.MaxCell.maxCellCount);

            int objectCount = meshCombiner.lodObjectCount[0];

            for (int i = 0; i < lodCount; i++)
            {
                EditorGUILayout.BeginHorizontal();
                if (objectCount == meshCombiner.lodObjectCount[i]) GUI.color = Color.green; else GUI.color = Color.red;
                EditorGUILayout.LabelField("LOD" + i + " -> " + meshCombiner.lodObjectCount[i] + " Objects ");
                EditorGUILayout.EndHorizontal();
            }

            GUI.color = Color.white;
        }

        void DrawSearchOptions(Color color)
        {
            GUI.color = color;
            EditorGUILayout.BeginVertical("Box");
            GUI.color = Color.white;

            GUIDraw.LabelWidthUnderline("Search Options", 14);

            EditorGUILayout.PropertyField(drawGizmos);
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Show Cell Grid");
                EditorGUILayout.LabelField("X", GUILayout.Width(13));
                EditorGUILayout.PropertyField(searchBoxGridX, new GUIContent(""), GUILayout.Width(25));
                EditorGUILayout.LabelField("Y", GUILayout.Width(13));
                EditorGUILayout.PropertyField(searchBoxGridY, new GUIContent(""), GUILayout.Width(25));
                EditorGUILayout.LabelField("Z", GUILayout.Width(13));
                EditorGUILayout.PropertyField(searchBoxGridZ, new GUIContent(""), GUILayout.Width(25));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.PropertyField(searchBoxSquare);

            EditorGUILayout.PropertyField(parent);
            EditorGUILayout.PropertyField(layerMask);
            EditorGUILayout.PropertyField(useTag);
            if (useTag.boolValue)
            {
                tag.stringValue = EditorGUILayout.TagField("Tag", tag.stringValue);
            }
            EditorGUILayout.PropertyField(onlyStatic);
            EditorGUILayout.PropertyField(useVertexInputLimit);
            if (useVertexInputLimit.boolValue)
            {
                EditorGUILayout.PropertyField(vertexInputLimit);
            }

            if (vertexInputLimit.intValue < 1) vertexInputLimit.intValue = 1;


            EditorGUILayout.PropertyField(nameContains);
            if (nameContains.boolValue)
            {
                GUIDraw.PropertyArray(nameContainList);
            }


            EditorGUILayout.EndVertical();
        }

        void DrawOutputSettings(Color color)
        {

            GUI.color = color;
            EditorGUILayout.BeginVertical("Box");
            GUI.color = Color.white;

            GUIDraw.LabelWidthUnderline("Output Settings", 14);

            GUI.changed = false;
            int oldCellSize = cellSize.intValue;
            EditorGUILayout.PropertyField(cellSize);
            if (GUI.changed)
            {
                if (cellSize.intValue < 4) cellSize.intValue = 4;
                if (oldCellSize != cellSize.intValue)
                {
                    if (meshCombiner.octreeCreated) meshCombiner.ResetOctree();
                    if (meshCombiner.combinedLODManager != null)
                    {
                        serializedObject.ApplyModifiedProperties();
                        meshCombiner.combinedLODManager.UpdateDistances(meshCombiner);
                    }
                }
            }

            GUI.changed = false;
            EditorGUILayout.PropertyField(lodAmount);
            if (lodAmount.intValue < 1) lodAmount.intValue = 1;
            if (GUI.changed)
            {
                serializedObject.ApplyModifiedProperties();
                if (lodAmount.intValue > 1) meshCombiner.AddCombinedLODManager();
                else meshCombiner.DestroyCombinedLODManager();
            }
            
            if (lodAmount.intValue > 1)
            {
                EditorGUILayout.PropertyField(lodSeachText);
            }

            EditorGUILayout.PropertyField(addMeshColliders);

            EditorGUILayout.PropertyField(useVertexOutputLimit);
            if (useVertexOutputLimit.boolValue)
            {
                EditorGUILayout.PropertyField(vertexOutputLimit);
            }

            if (vertexOutputLimit.intValue < 1) vertexOutputLimit.intValue = 1;

            //EditorGUILayout.PropertyField(removeGeometryBelowTerrain);
            //if (removeGeometryBelowTerrain.boolValue)
            //{
            //    DrawPropertyArray(terrains);
            //}

            EditorGUILayout.EndVertical();
        }

        void DrawRuntime(Color color)
        {
            GUI.color = color;
            EditorGUILayout.BeginVertical("Box");
            GUI.color = Color.white;
            GUIDraw.LabelWidthUnderline("Runtime", 14);

            EditorGUILayout.PropertyField(combineInRuntime);

            if (combineInRuntime.boolValue)
            {
                EditorGUILayout.PropertyField(combineOnStart);
                EditorGUILayout.PropertyField(useCombineSwapKey);
                if (useCombineSwapKey.boolValue)
                {
                    EditorGUILayout.PropertyField(combineSwapKey);
                }
                EditorGUILayout.PropertyField(originalObjects);
                EditorGUILayout.PropertyField(originalObjectsLODGroups);
            }

            EditorGUILayout.EndVertical();
        }
    }
}