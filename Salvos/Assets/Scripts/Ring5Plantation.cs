using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ring5Plantation : MonoBehaviour {
	public GameObject m,dr,c,b;
	public Text mt;	
	private void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		m.SetActive(true);
		Destroy(dr);
		b.SetActive(false);
		mt.text="You Lose.\nHint: Steeper Mountains have greater chances of landslides.";
		c.SetActive(true);
	}
}
