using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupHandler : MonoBehaviour {
	public GameObject panel;
	private Text Message,ButtonText;
	private string[] s= {
		"Hello! Let's get started with our 1st Mission!",
		"Look at the mountain/peaks to find highlighted region.",
		"You can go to the highlighted region to plant trees on that mountain.",
		"You can only chose one among the two mountains.",
		"You have to detect where landslide could occur.",
		"Look at the mountains on your sides.",
		"You're All Set... Goodluck!!!",""
	};

	private static int i;
	void Start () {
		i=0;
		Message=GameObject.Find("Message").GetComponent<Text>();
		ButtonText = GameObject.Find("Button/Text").GetComponent<Text>();
		ButtonText.text="Next";
		Message.text=s[i];
		GameObject.Find("Button").GetComponent<Button>().onClick.AddListener(GameGuide);
	}
	void GameGuide(){
		i++;
		Message.text= s[i];
		if(i==6)
			ButtonText.text="Start";
		else if(i==7)
			panel.SetActive(false);
	}
}
