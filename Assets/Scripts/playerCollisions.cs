using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCollisions : MonoBehaviour
{

	public GameObject player;
	public GameObject camera2;

	

	public Text txtVidas;
	public Text gameOver;

	public int vidas = 5;

	float spawnX;
	float spawnY;
	float spawnZ; 

    // Start is called before the first frame update
    void Start()
    {
		//valores iniciales del spawn
		spawnX = 0;
		spawnY = 0.1f;
		spawnZ = 0;

		gameOver.text = "";
		txtVidas.text = "";

    }

    // Update is called once per frame
    void Update()
    {
		//Si el player baja a cierta altura, vuelve al último spawn
		if (gameObject.transform.position.y < -10)
		{
			transform.position = new Vector3(spawnX, spawnY, spawnZ);
			vidas--;
		}
		if (vidas == 0)
		{
			Destroy(player);
			camera2.SetActive(true);
			gameOver.text = "Game Over";


		}

		txtVidas.text = "Vidas: " + vidas.ToString();
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "checkpoint1")
		{
			//valores del primer checkpoint
			spawnX = 18.54f;
			spawnY = 0.1f;
			spawnZ = 27.23f;
		}	
		if (col.gameObject.tag == "deathObs")
		{
			//cuando el player toque un obstáculo vuelve al último punto
			transform.position = new Vector3(spawnX, spawnY, spawnZ);
			vidas--;
		}
		

	}
}
