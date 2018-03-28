using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBlockage : MonoBehaviour {

	public GameObject blockage;
	// Use this for initialization
	void Start () {
		blockage.SetActive(false);
	}
	
	private void OnTriggerEnter(Collider other) {
		blockage.SetActive(true);
	}
}
