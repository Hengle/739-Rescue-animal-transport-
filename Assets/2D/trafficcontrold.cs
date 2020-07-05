using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;
using UnityStandardAssets.Utility;
public class trafficcontrold : MonoBehaviour {
	public AutoMoveAndRotate[] _tires;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			
			for(int i=0;i<_tires.Length;i++)
			{
				_tires [i].enabled = false;
			}
			this.gameObject.transform.parent.GetComponent<splineMove> ().Pause ();
		}

		if (col.gameObject.tag == "traffic") 
		{

			for(int i=0;i<_tires.Length;i++)
			{
				_tires [i].enabled = false;
			}
			this.gameObject.transform.parent.GetComponent<splineMove> ().Pause ();
		}
	}


	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			this.gameObject.transform.parent.GetComponent<splineMove> ().Resume ();
			for(int i=0;i<_tires.Length;i++)
			{
				_tires [i].enabled = true;
			}
		}

		if (col.gameObject.tag == "traffic") 
		{
			this.gameObject.transform.parent.GetComponent<splineMove> ().Resume ();
			for(int i=0;i<_tires.Length;i++)
			{
				_tires [i].enabled = true;
			}
		}

	}
	// Update is called once per frame
	void Update () {
		Vector3 temp = transform.parent.transform.rotation.eulerAngles;
		temp.x = 0f;
		temp.z = 0f;
		transform.parent.transform.rotation = Quaternion.Euler (temp);
	}
}
