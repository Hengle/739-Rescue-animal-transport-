using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshCombineStudio
{
    [ExecuteInEditMode]
    public class ChildCount : MonoBehaviour
    {

        public bool lodGroupsActive;
        public bool setLodGroups;

        private void Awake()
        {
            Transform[] transforms = transform.GetComponentsInChildren<Transform>();

            MeshFilter[] mfs = transform.GetComponentsInChildren<MeshFilter>();

            int vertexCount = 0, triangleCount = 0;

            for (int i = 0; i < mfs.Length; i++)
            {
                Mesh m = mfs[i].sharedMesh;
                if (m == null) continue;
                // if (m.subMeshCount == 1) continue;

                vertexCount += m.vertexCount;
                triangleCount += m.triangles.Length;
            }

            LODGroup[] lodGroups = transform.GetComponentsInChildren<LODGroup>();

            Debug.Log("Children " + transforms.Length + " VertexCount " + vertexCount + " TriangleCount " + triangleCount + " LODGroups " + lodGroups.Length);
        }


        private void Update()
        {
            if (setLodGroups)
            {
                setLodGroups = false;
                SetLodGroupsActive(lodGroupsActive);
            }
        }

        public void SetLodGroupsActive(bool active)
        {
            LODGroup[] lodGroups = transform.GetComponentsInChildren<LODGroup>();

            for (int i = 0; i < lodGroups.Length; i++)
            {
                lodGroups[i].enabled = active;
            }
        }
    }
}
