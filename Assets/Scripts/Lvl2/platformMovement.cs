using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour
{
	public float platformSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position -= new Vector3(0, 0, platformSpeed);

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Player")
		{

		}
	}
}
