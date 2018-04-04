using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public static class hasComponent
{
    public static bool HasComponent<T>(this GameObject flag) where T : Component
    {
        return flag.GetComponent<T>() != null;
    }
}
public class GameScript : MonoBehaviour {
    public static int scene = 0;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;
    public GameObject box5;
    public GameObject box6;
    public GameObject box7;
    public GameObject box8;
    public GameObject box9;
    public GameObject box10;
    public GameObject box11;
    public GameObject box12;
    public GameObject[] Pox;
    public Text score;

    public int gameScore(GameObject c)
    {
        string o1 = "Sword";
        string o2 = "Staff";
        string o3 = "Axe";
        int value = 0;
        if (c.transform.Find(o1))
        {
            value = 1000;
        }
        else if (c.transform.Find(o2))
        {
            value = 2000;
        }
        else if (c.transform.Find(o3))
        {
            value = 3000;
        }
        return value;
    }
    public int exit(GameObject[] c)
    {
        int check = 1;
        for(int i=0;i< c.Length;i++)
        {
            if (c[i].transform.childCount == 0)
            {
                check = 0;
            }
        }
        return check;
    }
    // Use this for initialization
    private void Update()
    {
        int budget = -5000;
        budget += gameScore(box1);
        budget += gameScore(box2);
        budget += gameScore(box3);
        budget += gameScore(box4);
        budget += gameScore(box5);
        budget += gameScore(box6);
        budget += gameScore(box7);
        budget += gameScore(box8);
        budget += gameScore(box9);
        budget += gameScore(box10);
        budget += gameScore(box11);
        budget += gameScore(box12);
        score.text = "Budget : "+budget.ToString()+"   ";
        if (exit(Pox) == 1)
        {
            scene = 1;
            SceneManager.LoadScene(7);
        }
    }
}
