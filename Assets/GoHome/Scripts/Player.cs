using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MAKE SURE THIS HAS RIGIDBODY
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float movementSpeed = 20f;
    private Rigidbody rigid;

	// Use this for initialization
	void Start ()
    {
        //Get reference to rigidbody
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        // Get Input Axis as float for x and y
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        //Create Input Vector
        Vector3 input = new Vector3(inputX, 0, inputZ);
        //Apply velocity
        rigid.velocity = input * movementSpeed;
        
	}
}
