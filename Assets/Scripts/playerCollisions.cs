using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCollisions : MonoBehaviour
{
	public AudioSource source;
	public AudioClip caida;
	public AudioClip respawn;
	public AudioClip muerte;
	public AudioClip msg;
	public AudioClip derrota;
	public AudioClip collectable;


	public GameObject player;
	public GameObject camera2;
	public GameObject platform;

	public GameObject indicationTxt;

	public GameObject platformText;
	public Text txtVidas;
	public Text gameOver;
	public Text contadorObj;

	int counter;
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
		if (gameObject.transform.position.y < -6 && vidas > 0)
		{
			Respawn();

			source.clip = caida;
			source.Play();
		}


		if (vidas == 0)
		{
			source.clip = derrota;
			source.Play();
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

			source.clip = respawn;
			source.Play();
		}


		if (col.gameObject.name == "checkpoint2")
		{
			//valores del segundo checkpoint
			spawnX = 35;
			spawnY = 0.1f;
			spawnZ = 27;

			//Activa la plataforma y el texto
			platform.SetActive(true);
			platformText.SetActive(true);
			Destroy(platformText, 3);

			source.clip = msg;
			source.Play();
		}
		if (col.gameObject.tag == "collectable")
		{
			counter++;
			source.clip = collectable;
			source.Play();

		}
		if (col.gameObject.name == "checkpoint3")
		{
			//valores del primer checkpoint
			spawnX = 36.5f;
			spawnY = 2.95f;
			spawnZ = -3.25f;

			
			contadorObj.text = "Tienes: " + counter + "/6";
		}

		if (col.gameObject.tag == "deathObs")
		{
			//cuando el player toque un obstáculo vuelve al último punto
			Respawn();

			source.clip = muerte;
			source.Play();

		}
		

		if (col.gameObject.name == "Detector2")
		{
			indicationTxt.SetActive(true);
			Destroy(indicationTxt, 3);


			source.clip = msg;
			source.Play();

		}

		
	}

	//Función del respawn
	void Respawn()
	{
		transform.position = new Vector3(36.5f, 2.95f, -3.25f);
		vidas--;

	}
}
