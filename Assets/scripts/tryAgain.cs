using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tryAgain : MonoBehaviour {

private void OnMouseDown()
{
	SceneManager.LoadScene("main",LoadSceneMode.Single);
}
}
