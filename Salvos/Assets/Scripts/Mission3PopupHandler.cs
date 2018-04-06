using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mission3PopupHandler : MonoBehaviour {
    public GameObject panel,back,next;
	private Text Message,NextText,BackText;
	private string[] s= {
		"Hello! Let's get started with 3rd Mission!\nTOWN PLANNING",
		"Landslide has occurred and you have saved as many people as you can.",
		"As everything is now destroyed, you have to do TOWN PLANNING.",
		"Your are given some money to build your town.",
		"Build all necessary things with given Budget and then Submit.",
		"Fill all the boxes by dragging and dropping. Negative budget is not allowed.",
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
            SceneManager.LoadScene(7);
			return;
		}
		GameGuide(i);
	}
	void Back(){
		i--;
		if(i<0)
			i=0;
		else if(i==6){
			SceneManager.LoadScene(3);
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
			NextText.text="FINISH";
			BackText.text="RETRY";
		}
	}
}
