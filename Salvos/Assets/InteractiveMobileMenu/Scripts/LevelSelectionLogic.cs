using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSelectionLogic : MonoBehaviour {

	public List<LevelList> levelList = new List<LevelList>(); //List of level class;
	private Vector2 touchPos;
	private CameraControls cam; 		// Camera controls reference;
	private float touchTime;			// How long touch time;
	private float reactTime = 0.25F;		// Fixed touch time to level loading happens;

	void Awake()
	{
		cam = Camera.main.GetComponent<CameraControls>();

		if(PlayerPrefs.HasKey("currentCamPos") && cam.cameraPosition == CameraControls.CameraPosition.SaveCurrent)
		{
			cam.defaultPosition = PlayerPrefsX.GetVector3("currentCamPos");
		}

		//Check if player prefs have any data with levels indexes, if so - assign;
		foreach (LevelList level in levelList)
		{
			if(PlayerPrefs.HasKey("isFinished" + level.LevelIndex.ToString()))
			{
				level.isFinished = PlayerPrefsX.GetBool("isFinished" + level.LevelIndex.ToString());
			}
			if(PlayerPrefs.HasKey("startsCount" + level.LevelIndex.ToString()))
			{
					level.starsCount = PlayerPrefs.GetInt("startsCount"+ level.LevelIndex.ToString());
			}
		}

		for(int i = 0; i < levelList.Count; i++)
		{
			//draw stats depends on how much stars we gained;
			if(levelList[i].isFinished)
			{
				if(levelList[i].starsCount == 1) levelList[i].Stats.sprite = levelList[i].levelSettings.OneStar;
				if(levelList[i].starsCount == 2) levelList[i].Stats.sprite = levelList[i].levelSettings.TwoStars;
				if(levelList[i].starsCount == 3) levelList[i].Stats.sprite = levelList[i].levelSettings.ThreeStars;

				//unlock next level;
				if(i+1 <= levelList.Count-1)
				{
					levelList[i+1].unlocked = true;
					if(cam.cameraPosition == CameraControls.CameraPosition.WithNextLevel)
						cam.defaultPosition = levelList[i+1].LevelObject.transform.position;
				}
			}

			//draw unlock level sprite if level is unlocked and conversely;
			if(levelList[i].unlocked)
			{
				levelList[i].Stats.gameObject.SetActive(true);
				levelList[i].LevelObject.sprite = levelList[i].levelSettings.LevelUnlocked;
			}
			else
			{
				levelList[i].Stats.gameObject.SetActive(false);
				levelList[i].LevelObject.sprite = levelList[i].levelSettings.LevelLocked;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Detecting if LevelObject sprite contains touch position and if so, load it if unlocked;

		if(Input.GetMouseButton(0))
		{
			touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			touchTime += Time.deltaTime;
		}

		if(Input.GetMouseButtonUp(0))
		{
			for (int i = 0; i < levelList.Count; i++)
			{
				if(levelList[i].unlocked && levelList[i].LevelObject.bounds.Contains(touchPos) && touchTime < reactTime)
				{
					Application.LoadLevel(levelList[i].LevelIndex);
					PlayerPrefsX.SetVector3("currentCamPos", cam.transform.position);
				}
			}
			touchTime = 0;
		}
	}
}

//Level class;
[System.Serializable]
public class LevelList
{
	public SpriteRenderer LevelObject;			//Level object renderer in the scene (assign from hierarchy panel);
	public SpriteRenderer Stats;				//Level stats renderer in the scene (assign from hierarchy panel);
	public int LevelIndex;						//Level index, can be found in the build settings;
	public bool unlocked;						//Is level unlocked? you can unlock it as default;
	public bool isFinished;						//Is level finished?
	public int starsCount;						//Stars count, zero is default, 3 is max in this case;						
	public LevelSettings levelSettings = new LevelSettings();			//Level settings class, contain sprites to replace the default ones;


	//some bools for editor script purposes;
	public bool expandLevelList = true;
	public bool expandLevelSettings = true;
}

//NOTE: assign this sprites from the project panel;
[System.Serializable]
public class LevelSettings
{
	public Sprite LevelUnlocked;				//Unlocked level sprite;
	public Sprite LevelLocked;					//Locked level sprite;
												//Stars;
	public Sprite OneStar;
	public Sprite TwoStars;
	public Sprite ThreeStars;
}
