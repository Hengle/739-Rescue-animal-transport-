using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ListMeshVertCount : MonoBehaviour {

	void OnEnable ()
    {
        MeshFilter[] mfs = GetComponentsInChildren<MeshFilter>(true);

        int vertCount = 0;
        int triangleCount = 0;

        for (int i = 0; i < mfs.Length; i++)
        {
            Mesh m = mfs[i].sharedMesh;
            if (m == null) continue;
            vertCount += m.vertexCount;
            triangleCount += m.triangles.Length;
        }

        Debug.Log(gameObject.name + " Vertices " + vertCount + "  Triangles " + triangleCount);
	}
}
