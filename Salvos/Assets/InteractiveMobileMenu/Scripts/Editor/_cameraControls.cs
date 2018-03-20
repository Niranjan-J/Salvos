using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(CameraControls))]

public class _cameraControls : Editor {

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		CameraControls cam = (CameraControls) target;
		GUILayout.Space(5);
		EditorGUILayout.BeginHorizontal("Box");
			GUILayout.FlexibleSpace();	GUILayout.Label("Camera Controls", EditorStyles.boldLabel);	GUILayout.FlexibleSpace();
		EditorGUILayout.EndHorizontal();

		cam.dragSpeed = EditorGUILayout.FloatField("Drag Sensitivity", cam.dragSpeed);
		cam.dragAxes = (CameraControls.DragAxes)EditorGUILayout.EnumPopup("Drag Axes", cam.dragAxes);

		cam.cameraPosition = (CameraControls.CameraPosition)EditorGUILayout.EnumPopup("Camera Position", cam.cameraPosition);

		EditorGUILayout.BeginVertical("Box");
			float minX = -cam.sizeX.x;
			minX = EditorGUILayout.FloatField("Left Bound", minX);
			if(minX < 0) minX = 0;
			cam.sizeX.x = -minX;

			float maxX = cam.sizeY.x;
			maxX = EditorGUILayout.FloatField("Right Bound", maxX);
			if(maxX < 0) maxX = 0;
			cam.sizeY.x = maxX;

			float maxY = cam.sizeY.y;
			maxY = EditorGUILayout.FloatField("Top Bound", maxY);
			if(maxY < 0) maxY = 0;
			cam.sizeY.y = maxY;

			float minY = -cam.sizeX.y;
			minY = EditorGUILayout.FloatField("Bottom Bound", minY);
			if(minY < 0) minY = 0;
			cam.sizeX.y = -minY;
		EditorGUILayout.EndVertical();



		if(GUI.changed) EditorUtility.SetDirty(cam);
	}

	void OnInspectorUpdate()
	{
		Repaint();
	}
}
