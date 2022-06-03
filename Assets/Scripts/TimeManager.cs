using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
	
	public Text txtTimeFloored;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float elapsedTime = Time.time;
		txtTimeFloored.text = Mathf.Floor(elapsedTime).ToString();
    }
}
