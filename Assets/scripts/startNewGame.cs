using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startNewGame : MonoBehaviour {

	// Use this for initialization
		private void OnMouseDown()
		{
			SceneManager.LoadScene("main", LoadSceneMode.Single);
		}
	
}
