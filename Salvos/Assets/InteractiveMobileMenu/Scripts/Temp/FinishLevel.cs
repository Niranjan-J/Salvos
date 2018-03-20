using UnityEngine;
using System.Collections;

public class FinishLevel : MonoBehaviour {

	public int nextLevelIndex;			//The next scene index;
	private int levelIndex;				//This scene index

	// Use this for initialization
	void Start () 
	{
		levelIndex = Application.loadedLevel;	//Getting current level index for saving needs;
	}
	
	// Examples on how to finish level and save stats;
	void OnGUI (){
		if (GUI.Button(new Rect(0, Screen.height/2 - 105, Screen.width, 100), "Finish Level With 1 Star"))
		{
			Data.SaveData(levelIndex, true, 1);
			LoadNextLevel();
		}

		if (GUI.Button(new Rect(0, Screen.height/2, Screen.width, 100), "Finish Level With 2 Stars"))
		{
			Data.SaveData(levelIndex, true, 2);
			LoadNextLevel();
		}

		if (GUI.Button(new Rect(0, Screen.height/2 + 105, Screen.width, 100), "Finish Level With 3 Stars"))
		{
			Data.SaveData(levelIndex, true, 3);
			LoadNextLevel();
		}
	}

	//What should we load depends on the OnFinish enum choice;
	void LoadNextLevel()
	{
		Application.LoadLevel(nextLevelIndex);
	}
}
