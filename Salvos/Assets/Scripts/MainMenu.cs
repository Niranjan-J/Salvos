using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame(){
		SceneManager.LoadScene(4);
	}

	public void PlayIntro(){
		SceneManager.LoadScene(3);
	}

	public void QuitGame(){
		Debug.Log("QUIT");
		Application.Quit();
	}
}
