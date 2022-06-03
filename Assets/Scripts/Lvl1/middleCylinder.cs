using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleCylinder : MonoBehaviour
{

	float speed = 0.1f;
	bool toRight;

	public GameObject baseIzq;
	public GameObject baseDer;

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

		if (transform.position.z > baseDer.transform.position.z - 0.5f)
		{
			toRight = false;


		}
		if (transform.position.z < baseIzq.transform.position.z + 0.5f)
		{
			toRight = true;

		}
	}
}
