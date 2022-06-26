using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
	public AudioSource source;
	public AudioClip holyMusic;

	public GameObject prefab;
	public GameObject Escalon;
	public GameObject baseFinal;

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

			source.clip = holyMusic;
			source.Play();

			Escalon.SetActive(true);
			baseFinal.SetActive(true);

			while (counter < 15)
			{ 
				yOffset += 0.2f;
				zOffset += -1;
				Instantiate(prefab).transform.position += new Vector3(0, yOffset, zOffset);

				counter++;


			}
			
		}
	}
}
