using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomEditor(typeof(LevelSelectionLogic))]
public class _levelSelectionLogic : Editor 
{

	bool rootFold = true;
	LevelSelectionLogic levels;

	public override void OnInspectorGUI()
	{
		levels = (LevelSelectionLogic)target;
		EditorGUILayout.BeginVertical("Box");
		GUILayout.Space(5);

		EditorGUILayout.BeginHorizontal(EditorStyles.toolbarButton);
		GUILayout.Space(10);

		rootFold = EditorGUILayout.Foldout(rootFold,"Level Selection Settings");
		var foldoutStyle = new GUIStyle(EditorStyles.toolbarButton);
		foldoutStyle.fontSize = 10;
		if(rootFold)
		{
			GUILayout.FlexibleSpace();

			GUIContent addContent;
			var addIcon = "+";
			addContent = new GUIContent(addIcon, "Add new level");
			if(GUILayout.Button(addContent, foldoutStyle, GUILayout.Width(35)))
			{
				levels.levelList.Add(new LevelList());
			}
		}
		EditorGUILayout.EndHorizontal();

		for (int i = 0; i < levels.levelList.Count; i++)
		{
			if(rootFold)
			{
				EditorGUILayout.BeginHorizontal();
				GUILayout.Space(10);
					EditorGUILayout.BeginHorizontal(EditorStyles.toolbarButton);
					GUILayout.Space(10);

					levels.levelList[i].expandLevelList = EditorGUILayout.Foldout(levels.levelList[i].expandLevelList,
					                                                              "Level " + levels.levelList[i].LevelIndex);
					GUIContent removeLevel;
					var removeIcon = '\u2573'.ToString();
					removeLevel = new GUIContent(removeIcon, "Remove Level");
					if(GUILayout.Button(removeLevel, foldoutStyle, GUILayout.Width(20)))
					{
						levels.levelList.RemoveAt(i);
					}
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.EndHorizontal();

				if(i < levels.levelList.Count && levels.levelList[i].expandLevelList)
				{
					EditorGUILayout.BeginHorizontal();
					GUILayout.Space(15);
					EditorGUILayout.BeginVertical("Box");
					EditorGUILayout.BeginHorizontal();
						EditorGUILayout.BeginVertical("Box");
							levels.levelList[i].LevelObject = (SpriteRenderer)EditorGUILayout.ObjectField
							("Level Object", levels.levelList[i].LevelObject, typeof(SpriteRenderer), true);

							levels.levelList[i].Stats = (SpriteRenderer)EditorGUILayout.ObjectField
							("Stats Object", levels.levelList[i].Stats, typeof(SpriteRenderer), true);

							levels.levelList[i].unlocked = EditorGUILayout.Toggle("isUnlocked", levels.levelList[i].unlocked);
							levels.levelList[i].LevelIndex = EditorGUILayout.IntField("Level Index", levels.levelList[i].LevelIndex);

						EditorGUILayout.EndVertical();
					EditorGUILayout.EndHorizontal();

					EditorGUILayout.BeginHorizontal();
					GUILayout.Space(10); levels.levelList[i].expandLevelSettings = EditorGUILayout.Foldout(levels.levelList[i].expandLevelSettings, "Level Settings");
					EditorGUILayout.EndHorizontal();

					if(levels.levelList[i].expandLevelSettings)
					{
						EditorGUILayout.BeginHorizontal();
						GUILayout.Space(5);
							EditorGUILayout.BeginVertical("Box");
							
							levels.levelList[i].levelSettings.LevelLocked = (Sprite)EditorGUILayout.ObjectField
							("Locked Level", levels.levelList[i].levelSettings.LevelLocked, typeof(Sprite), false);

							levels.levelList[i].levelSettings.LevelUnlocked = (Sprite)EditorGUILayout.ObjectField
							("Unlocked Level", levels.levelList[i].levelSettings.LevelUnlocked, typeof(Sprite), false);

							levels.levelList[i].levelSettings.OneStar = (Sprite)EditorGUILayout.ObjectField
							("1 Star", levels.levelList[i].levelSettings.OneStar, typeof(Sprite), false);

							levels.levelList[i].levelSettings.TwoStars = (Sprite)EditorGUILayout.ObjectField
							("2 Stars", levels.levelList[i].levelSettings.TwoStars, typeof(Sprite), false);

							levels.levelList[i].levelSettings.ThreeStars = (Sprite)EditorGUILayout.ObjectField
							("3 Stars", levels.levelList[i].levelSettings.ThreeStars, typeof(Sprite), false);
							
							EditorGUILayout.EndVertical();
						EditorGUILayout.EndHorizontal();
					}

					EditorGUILayout.EndVertical();
					EditorGUILayout.EndHorizontal();
				}
			}
		}
		GUILayout.Space(5);
		EditorGUILayout.EndVertical();
		GUI.color = new Color(1, 0, 0, 0.65F);
		GUILayout.Space(15);
		if (GUILayout.Button("Clean Player Prefs", EditorStyles.toolbarButton))
		{
			PlayerPrefs.DeleteAll();
		}

		if (GUI.changed)
			EditorUtility.SetDirty(target);
		GUILayout.Space(5);
	}
}
