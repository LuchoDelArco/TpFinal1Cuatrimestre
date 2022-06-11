using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{

	public GameObject prefab;

	float yOffset;
	float zOffset;
	int i;

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
		if (col.gameObject.name == "stairsBase")
		{
			while (i == 0)
			{
				yOffset -= 4;
				zOffset -= 2;
				Instantiate(prefab).transform.position += new Vector3(0, yOffset, zOffset);
				Destroy(gameObject, 0.3f);
				i++;
			}
		}
	}
}
