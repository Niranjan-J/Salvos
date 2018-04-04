using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocksCollisionHandler : MonoBehaviour {
	public GameObject p;
	public Text mt;
	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")){
			mt.text="GAME OVER.\nHint: Stay away from the rocks and boulders. They are dangerous.";
		}
		p.SetActive(true);
	}
}
