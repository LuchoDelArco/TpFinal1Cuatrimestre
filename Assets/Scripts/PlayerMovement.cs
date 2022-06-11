﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public AudioSource source;
	public AudioClip salto;
	public AudioClip caminata;



	public float platformSpeed;
	float movementSpeed = 0.1f;
	float rotationSpeed = 3;
	float jumpForce = 3;
	public GameObject player;

	public GameObject platform;

	public Transform parent;


	

	bool hasJump;
	Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
		
		rb = GetComponent<Rigidbody>();
		hasJump = true;

    }

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(0, 0, movementSpeed);
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(0, 0, -movementSpeed);
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(0, rotationSpeed, 0);
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(0, -rotationSpeed, 0);
		}

		if (Input.GetKeyDown(KeyCode.Space) && hasJump)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			hasJump = false;

			source.clip = salto;
			source.Play();
		}
		
	}

	

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "ground")
		{
			hasJump = true ;

			source.clip = caminata;
			source.Play();
		}
		if (col.gameObject.name == "MovingPlatform")
		{
			hasJump = true;
			gameObject.transform.SetParent(parent);
		}
		else
		{
			gameObject.transform.SetParent(null);
		}
	}
	
	
}
