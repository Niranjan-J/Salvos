using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	public GameObject m1,m2,m3;
	public static int i;
	public Text score;
	void Start () {
		i=0;
		score.text="SCORE: "+i;
	}

	void Update () {
		score.text="SCORE: "+i;

	}
}
