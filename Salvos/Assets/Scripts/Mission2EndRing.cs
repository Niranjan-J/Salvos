using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission2EndRing : MonoBehaviour {
	public GameObject p;
	public Text mt;	
	private void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		if(Mission2Character.j==3)
			mt.text="Well Done!! You Win!!\nYou saved yourself and other people.";
		else
			mt.text="You Lose.\nHint: Save as many people as you can. Be generous!!";
		p.SetActive(true);
	}
}
