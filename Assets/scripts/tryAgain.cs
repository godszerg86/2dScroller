using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tryAgain : MonoBehaviour {

 void OnMouseUpAsButton()
{
	SceneManager.LoadScene("main",LoadSceneMode.Single);
}

}
