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
	public AudioClip collectable;
	public AudioClip puerta;
	

	public GameObject player;
	public GameObject camera2;
	public GameObject platform;
	public GameObject puertaFinal;
	public GameObject prefab;
	public GameObject prefab2;

	public GameObject backgroundMusic;
	public GameObject winMusic;
	public GameObject defeatMusic;


	public GameObject indicationTxt;
	public GameObject platformText;

	public Text txtVidas;
	public Text gameOver;
	public Text contadorObj;

	public GameObject cnvs;
	public GameObject cnvsLoss;
	public GameObject cnvsWin;

	int counter;
	public int vidas = 8;

	public Text txtTimeFloored;

	float elapsedTime;

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

			Destroy(player);
			//Activo la sengunda cámara
			camera2.SetActive(true);
			
			gameOver.text = "Game Over";
			//Desactivar canvas del HUD
			cnvs.SetActive(false);
			//Activar canvas de derrota
			cnvsLoss.SetActive(true);
			//Desactivo musica de fondo
			backgroundMusic.SetActive(false);
			//Activo musica de derrota
			defeatMusic.SetActive(true);

			
			

		}

		else
		{
			txtVidas.text = "Vidas: " + vidas.ToString();
			elapsedTime = Time.time;
			txtTimeFloored.text = Mathf.Floor(elapsedTime).ToString();
		}

		if (counter == 6)
		{
			puertaFinal.transform.position += new Vector3(0, .002f, 0);
			Destroy(puertaFinal, 30);
			
		}

		
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

		}
		if (col.gameObject.name == "Detector1")
		{
			//Activa la plataforma y el texto
			platform.SetActive(true);
			platformText.SetActive(true);
			Destroy(platformText, 3);

			source.clip = msg;
			source.Play();
		}

		if (col.gameObject.tag == "collectable")
		{
			//Contador que incrementa cada vez que se colisiona con un recolectable
			counter++;
			source.clip = collectable;
			source.Play();
			contadorObj.text = "Tienes: " + counter + "/6";
		}

		if (col.gameObject.name == "checkpoint3")
		{
			//valores del tercer checkpoint
			spawnX = 36.5f;
			spawnY = 2.95f;
			spawnZ = -3.25f;

			
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
		if (col.gameObject.tag == "FINAL")
		{
			GameObject clon1;
			GameObject clon2;

			for (int i = 0; i < 15; i++)
			{
				clon1 = Instantiate(prefab);
				clon2 = Instantiate(prefab2);

				Destroy(clon1, 1);
				Destroy(clon2, 1);

			}
			
		}
		if (col.gameObject.name == "FINAL")
		{
			cnvs.SetActive(false);
			Destroy(player);
			camera2.SetActive(true);
			cnvsWin.SetActive(true);

			backgroundMusic.SetActive(false);
			winMusic.SetActive(true);

		}

		
	}

	

	

	//Función del respawn
	void Respawn()
	{
		transform.position = new Vector3(spawnX, spawnY, spawnZ);
		vidas--;

	}
}
