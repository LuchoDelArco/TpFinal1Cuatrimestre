using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinderMovement : MonoBehaviour
{

	public float speed = 0.16f;
	public bool toRight = true;

	public GameObject topeIzq;
	public GameObject topeDer;

	// Start is called before the first frame update
	void Start()
    {
		
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

		if (transform.position.z > topeDer.transform.position.z - 0.5f)
		{
			toRight = false;
			

		}
		if (transform.position.z < topeIzq.transform.position.z + 0.5f)
		{
			toRight = true;
			
		}

		transform.Rotate(0, 2, 0);
	}
}
