using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame(){
		SceneManager.LoadScene(5);//6
	}

	public void PlayIntro(){
		SceneManager.LoadScene(4);//5
	}

	public void QuitGame(){
		Debug.Log("QUIT");
		Application.Quit();
	}
}
