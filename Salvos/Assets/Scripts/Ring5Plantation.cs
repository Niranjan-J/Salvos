using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ring5Plantation : MonoBehaviour {
	public GameObject m,dr,p;
	public Text mt;	
	private void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		m.SetActive(true);
		Destroy(dr);
		mt.text="You Lose.\nHint: STEEPER MOUNUTAINS have greater chances of landslides.";
		p.SetActive(true);
	}
}
