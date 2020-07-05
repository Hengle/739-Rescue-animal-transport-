using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ListLODGroups : MonoBehaviour {

	void Start ()
	{
		LODGroup[] lodGroups = GetComponentsInChildren<LODGroup>();

		for (int i = 0; i < lodGroups.Length; i++) Debug.Log(lodGroups[i].name);
		Debug.Log("-----------------------------------------------");
		Debug.Log(lodGroups.Length + " LodGroups found");
	}
}
