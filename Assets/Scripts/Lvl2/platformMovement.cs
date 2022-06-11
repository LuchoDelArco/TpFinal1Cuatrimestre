using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour
{

	float speed = 0.02f;
	bool toRight;

	public GameObject topeIzq;
	public GameObject topeDer;

	// Start is called before the first frame update
	void Start()
	{
		toRight = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (toRight == true)
		{
			transform.position += new Vector3(0, 0, speed);
		}
		else
		{
			transform.position -= new Vector3(0, 0, speed);
		}

		if (transform.position.z > topeDer.transform.position.z - 1)
		{
			toRight = false;


		}
		if (transform.position.z < topeIzq.transform.position.z + 0.5f)
		{
			toRight = true;

		}
	}
}
