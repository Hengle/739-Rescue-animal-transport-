using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
public class dogpoint : MonoBehaviour {

	public GameObject animalcontrols, truckcontrols,nexttargert,truckdog,back1,back2;
	public ArrowTarget _target;
	public GameObject rcccam, maincam;
	public GameObject _player;
    Animation animation;
//	public Transform sheep;
	// Use this for initialization
	void Start () {

       animation=   truckdog.GetComponent<Animation>();
    }
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "animal") {
			rcccam.SetActive (true);
			_player.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			col.gameObject.transform.parent.gameObject.SetActive (false);
			animalcontrols.gameObject.SetActive (false);
			truckcontrols.gameObject.SetActive (true);
			_target._target = nexttargert.transform;
			truckdog.gameObject.SetActive (true);
            animation.CrossFade("Eating");
            truckdog.GetComponent<Rigidbody>().IsSleeping();
            back1.gameObject.SetActive (true);
			back2.gameObject.SetActive (false);
			maincam.SetActive (false);
			this.gameObject.SetActive (false);
		}
	}
	// Update is called once per frame
	
}
