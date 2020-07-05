using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshCombineStudio
{
    [ExecuteInEditMode]
    public class GarbageCollectMesh : MonoBehaviour
    {
        public Mesh mesh;

        private void Awake()
        {
            MeshFilter mf = GetComponent<MeshFilter>();
            if (mf != null) mesh = mf.sharedMesh; else Debug.Log("MeshFilter = null");
            // Debug.Log("Awake");
        }

        private void OnDestroy()
        {
            if (mesh != null)
            {
                #if UNITY_EDITOR
                    DestroyImmediate(mesh);
                #else
                    Destroy(mesh);
                #endif
            }
            // Debug.Log("Destroy Mesh");
        }
    }
}
