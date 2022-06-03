using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathRodUpDown : MonoBehaviour
{ 
	public GameObject topeU;
	public GameObject topeD;

	float speed = 0.08f;

	bool Up = true;
	

    // Start is called before the first frame update
    void Start()
    {
		Up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Up == true)
		{
			transform.Translate (0, speed, 0);
		}
		else if (Up == false)
		{
			transform.Translate(0, -speed, 0);
		}

		if (gameObject.transform.position.y < topeD.transform.position.y + 0.5f)
		{
			Up = true;
		}
		if (gameObject.transform.position.y >= topeU.transform.position.y - 0.5f)
		{
			Up = false;
		}

	}
}
