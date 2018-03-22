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
		if (ScoreController.i == 1)
		{
			Data.SaveData(levelIndex, false, 1);
			//LoadNextLevel();
		}

		if (ScoreController.i == 2)
		{
			Data.SaveData(levelIndex, false, 2);
			//LoadNextLevel();
		}

		if (ScoreController.i == 3)
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
