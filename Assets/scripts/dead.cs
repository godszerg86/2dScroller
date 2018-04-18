using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead : MonoBehaviour {
	GameObject deathScreen;
	// Use this for initialization
 void Start()
	{
		deathScreen = GameObject.Find("death-screen");
        deathScreen.SetActive(false);
	}
void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player")){
			Debug.Log(other.tag);
			deathScreen.SetActive(true);
            other.gameObject.SetActive(false);
		}
	}
}
