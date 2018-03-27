using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mission2PopupHandler : MonoBehaviour {
	public GameObject panel,back,next;
	private Text Message,NextText,BackText;
	private string[] s= {
		"Hello! Let's get started with our 2nd Mission!",
		"Find First Aid Boxes and Highlighted Regions.",
		"You have to pick up first aid boxes and heal the injured people.",
		"Go to the highlighted regions to  heal the people.",
		"Every person requires one first aid kit to get healed.",
		"Also save yourself from falling rocks.",
		"You're All Set... Goodluck!!!",""
	};

	private static int i;
	void Start () {
		i=0;
		Message=GameObject.Find("Message").GetComponent<Text>();
		NextText = next.GetComponentInChildren<Text>();
		BackText=back.GetComponentInChildren<Text>();
		NextText.text="NEXT";
		BackText.text="BACK";
		Message.text=s[i];
		next.GetComponent<Button>().onClick.AddListener(Next);
		back.GetComponent<Button>().onClick.AddListener(Back);
	}
	void Next(){
		i++;
		if(i==8){
			SceneManager.LoadScene(4);
			return;
		}
		GameGuide(i);
	}
	void Back(){
		i--;
		if(i<0)
			i=0;
		else if(i==6){
			SceneManager.LoadScene(1);
			return;
		}
		GameGuide(i);
	}
	void GameGuide(int j){
		Message.text= s[j];
		if(j==6){
			NextText.text="START";
			back.SetActive(false);
		}
		else if(j==7){
			panel.SetActive(false);
			back.SetActive(true);
			NextText.text="MAIN MENU";
			BackText.text="RETRY";
		}
	}
}
