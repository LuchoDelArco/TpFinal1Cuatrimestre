﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectablesDstry : MonoBehaviour
{
	


	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Player")
		{
			Destroy(gameObject);
		}
	}



}
