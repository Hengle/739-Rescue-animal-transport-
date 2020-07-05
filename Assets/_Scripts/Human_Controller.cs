using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Human_Controller : MonoBehaviour
{

    public float moveSpeed;
    public float turnSpeed;
	bool forward,backward,left,right,stop;
    float axis;
    int countgifts=0;
    public Animator Person;
    Rigidbody rb;
 
    private void Start()
    {
        Person = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //if ((Input.GetAxis("Vertical") < 0) || Input.GetKeyDown(KeyCode.S))
		if ((CrossPlatformInputManager.GetAxis("Vertical") < 0) || backward==true)
        {
            // Walk backwards
			rb.MovePosition(transform.position - transform.forward * moveSpeed * Time.deltaTime);

			Person.SetBool ("back",true);
			Person.SetBool ("walk", false);
            //transform.GetComponent<Animator>().SetBool("run", false);
        }

		if ((CrossPlatformInputManager.GetAxis("Vertical") > 0)||forward==true)
        {
            // Walk forward
            rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);

			axis = CrossPlatformInputManager.GetAxis("Vertical");
            if (axis > 0.5f)
                axis = 0.5f;

			Person.SetBool ("back",false);
			Person.SetBool ("walk", true);
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

		if (CrossPlatformInputManager.GetAxis("Horizontal") < 0 || Input.GetKeyDown(KeyCode.A) || right==true)
        {
            //print("Horizontal");
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
			Person.SetBool ("walk", true);
        }

		if (CrossPlatformInputManager.GetAxis("Horizontal") > 0 || Input.GetKeyDown(KeyCode.D) || left==true)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
			Person.SetBool ("walk", true);
        }

		if (CrossPlatformInputManager.GetAxis("Vertical") == 0 && CrossPlatformInputManager.GetAxis("run") <= 0 )
        {
			Person.SetBool ("back",false);
			Person.SetBool ("walk", false);//transform.GetComponent<Animator>().SetBool("run", false);
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


	public void _forwad()
	{
		forward = true;
		backward = false;
		stop = true;
	}

	public void _backward()
	{
		forward = false;
		backward = true;
		Person.SetBool ("walk", true);
		stop = true;

	}

	public void _left()
	{
		left = true;
		right = false;
		Person.SetBool ("walk", true);
		stop = true;

	}
	public void _right()
	{
		left = false;
		right = true;
		Person.SetBool ("walk", true);
		stop = true;

	}
	public void _upstate()
	{
		Person.SetBool ("walk", false);
		Person.SetBool ("back",false);
		forward = false;
		backward = false;
		left = false;
		right = false;
		stop = false;
	}
}
