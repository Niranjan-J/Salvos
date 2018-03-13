using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	private void Start() {
		offset= transform.position-player.transform.position;
	}
	private void LateUpdate() {
		transform.rotation=player.transform.rotation;
		transform.position=player.transform.position+player.transform.rotation*offset;
	}
}

