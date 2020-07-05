using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Human_Controller1 : MonoBehaviour
{

    public float moveSpeed;
    public float turnSpeed;
	bool forward,backward,left,right,stop;
    float axis;
    int countgifts=0;
	public Animation Person;
    Rigidbody rb;
	public AudioSource _audiosource;
	bool checksound;
	public AudioClip walk,_up, kick;

 
    private void Start()
    {
		Person = gameObject.GetComponent<Animation>();
        rb = GetComponent<Rigidbody>();
		_audiosource = GetComponent<AudioSource> ();

    }
	void Update ()
	{
		Vector3 temp = transform.rotation.eulerAngles;
		temp.x = 0f;
		temp.z = 0f;
		transform.rotation = Quaternion.Euler (temp);
	}
    void FixedUpdate()
    {
		
        //if ((Input.GetAxis("Vertical") < 0) || Input.GetKeyDown(KeyCode.S))
		if ((CrossPlatformInputManager.GetAxis("Vertical") < 0) || backward==true)
        {
            // Walk backwards
			rb.MovePosition(transform.position - transform.forward * moveSpeed * Time.deltaTime);
			Person.CrossFade ("Walk");
			_audiosource.enabled = true;
			_audiosource.clip = walk;
			_audiosource.pitch = 0.5f;
			_audiosource.loop = true;
            //transform.GetComponent<Animator>().SetBool("run", false);
        }

		if ((CrossPlatformInputManager.GetAxis("Vertical") > 0)||forward==true)
        {
            // Walk forward
            rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);

			_audiosource.enabled = true;
			_audiosource.clip = walk;
			if (checksound == true) {
				checksound = false;
				_audiosource.Play();
			}
			_audiosource.pitch = 0.5f;
			_audiosource.loop = true;
			axis = CrossPlatformInputManager.GetAxis("Vertical");
            if (axis > 0.5f)
                axis = 0.5f;

			Person.CrossFade ("Walk");
            //transform.GetComponent<Animator>().SetBool("run", false);
        }

//        if ((Input.GetAxis("run") > 0))
//        {
//            // /run
//
//            //print("run");
//            rb.MovePosition(transform.position + transform.forward * 15 * Time.deltaTime);
//
//
//            axis = Input.GetAxis("run");
//            if (axis > 0.5f)
//                axis = 0.5f;
//
//			Person.SetBool ("back",false);
//			Person.SetBool ("walk", true);
//        }

		if (CrossPlatformInputManager.GetAxis("Horizontal") < -0.8 || Input.GetKeyDown(KeyCode.A) || right==true)
        {
            //print("Horizontal");
			//left turn
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
			Person.CrossFade ("Walk");

        }

		if (CrossPlatformInputManager.GetAxis("Horizontal") > 0.8 || Input.GetKeyDown(KeyCode.D) || left==true)
        {
			//right turn
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
			Person.CrossFade ("Walk");
        }

		if (CrossPlatformInputManager.GetAxis("Vertical") == 0 && CrossPlatformInputManager.GetAxis("run") <= 0 )
        {
//			_audiosource.enabled = false;
//			Person.CrossFade ("Idle");//transform.GetComponent<Animator>().SetBool("run", false);
        }

        //if (Input.GetButton("Fire1"))
        //{

        //    Person.SetFloat("velocity x", 4);
        //    Person.SetFloat("velocity y", 0);
        //}
        //if (Input.GetAxis("Mouse X")>0)
        //{
        //    transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        //}
        //if (Input.GetAxis("Mouse X") < 0)
        //{
        //    transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        //}
        if (Input.GetButton("pick"))
        {
//            Person.SetBool("pick", true);
        }
        if (Input.GetButton("drop"))
        {
//            print("drop");
//            Person.SetBool("pick", false);
        }
    }


	public void up()
	{
		Person.CrossFade ("Idle");
		_audiosource.enabled = false;
	}

	public void Kick()
	{
		Person.CrossFade ("Kick");
		checksound = true;
		_audiosource.enabled = true;
		_audiosource.clip = kick;
		_audiosource.pitch = 1f;
		_audiosource.PlayOneShot (kick);
		_audiosource.loop = false;
		StartCoroutine (wait1());
	}
	public void _downstate()
	{
		Person.CrossFade ("Up");
		_audiosource.Stop ();
		print ("work");
		_audiosource.enabled = true;
		_audiosource.clip = _up;
		_audiosource.pitch = 1f;
		_audiosource.PlayOneShot (_up);
		_audiosource.loop = false;
		checksound = true;
		StartCoroutine (wait());
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (2.7f);
		Person.CrossFade ("Idle");
		_audiosource.enabled = false;
	
	}

	IEnumerator wait1()
	{
		yield return new WaitForSeconds (1f);
		_audiosource.enabled = false;
		Person.CrossFade ("Idle");
	
	}



}
