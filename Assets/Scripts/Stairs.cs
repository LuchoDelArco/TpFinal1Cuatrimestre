using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{

	public GameObject prefab;

	float yOffset;
	float zOffset;
	int counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Player")
		{
			while (counter >= 0)
			{
				yOffset += 0.2f;
				zOffset += -1;
				Instantiate(prefab).transform.position += new Vector3(0, yOffset, zOffset);

				counter++;
				if(counter == 6)
				{
					break;
				}
			
			}
		}
	}
}
