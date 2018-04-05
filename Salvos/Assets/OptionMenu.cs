using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour {

	// Use this for initialization
	void Update () {
        Slider sli;
        sli = GetComponentInChildren<Slider>();
        sli.value = PlayerPrefs.GetFloat("volume", 0.5f);
        
    }
}
