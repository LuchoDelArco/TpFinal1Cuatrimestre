using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class deathRodSides : MonoBehaviour
{
	float speed = 0.15f;
	bool toRight;

	public GameObject topeIzq;
	public GameObject topeDer;

	// Start is called before the first frame update
	void Start()
    {
		toRight = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (toRight == true)
		{
			transform.position += new Vector3(speed, 0, 0);
		}
		else
		{
			transform.position -= new Vector3(speed, 0, 0);
		}

		if (transform.position.x > topeDer.transform.position.x - 1)
		{
			toRight = false;
		}
		if (transform.position.x < topeIzq.transform.position.x + 1)
		{
			toRight = true;
		}
	}
}
