using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ring6Plantation : MonoBehaviour {
	public GameObject m,dr,p;
	public Text mt;	
	private void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		ScoreController.i++;
		m.SetActive(true);
		Destroy(dr);
        AudioSource[] a;
        a = gameObject.GetComponentsInParent<AudioSource>();
        a[0].Play();
        if (ScoreController.i==3)
			mt.text="Well Done!! You Win!!\nPLANTING TREES on STEEPER MOUNUTAINS reduce the risk of landslides.";
		else
			mt.text="You Lose.\nHint: STEEPER MOUNUTAINS have greater chances of landslides.";
		p.SetActive(true);
	}
}
