using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class Ring6Plantation : MonoBehaviour {
	public GameObject m,dr,c,b,m1,m2;
	public Text mt,bt;	
	private void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		m.SetActive(true);
		Destroy(dr);
		if(m1.activeSelf && m2.activeSelf){
			mt.text="Well Done!! You Win!!\nSteeper Mountains have greater chances of landslides.";
		}
		else{
			mt.text="You Lose.\nHint: Steeper Mountains have greater chances of landslides.";
		}
		b.SetActive(false);
		c.SetActive(true);
	}
}
