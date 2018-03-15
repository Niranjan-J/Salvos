using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ring6Plantation : MonoBehaviour {
	public GameObject m,dr,p,b;
	public Text mt,score;	
	private void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		ScoreController.i++;
		m.SetActive(true);
		Destroy(dr);
		Debug.Log(score.text);
		if(ScoreController.i==3){
			mt.text="Well Done!! You Win!!\nSteeper Mountains have greater chances of landslides.";
		}
		else{
			mt.text="You Lose.\nHint: Steeper Mountains have greater chances of landslides.";
		}
		b.SetActive(false);
		p.SetActive(true);
	}
}
