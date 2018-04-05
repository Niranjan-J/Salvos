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
public class GameScript : MonoBehaviour
{
    public static int priority;
    public static int scene = 0;
    public GameObject[] Pox;
    public Text score;
    public GameObject submit;

    public void gameScore(GameObject[] c, ref int budget, ref int score)
    {
        string[] obj = new string[12];
        obj[0] = "Bank";
        obj[1] = "Bridge";
        obj[2] = "Flyover";
        obj[3] = "Hospital";
        obj[4] = "Hotel";
        obj[5] = "House";
        obj[6] = "Park";
        obj[7] = "Road";
        obj[8] = "School";
        obj[9] = "Shop";
        obj[10] = "Temple";
        obj[11] = "Train";
        int[] price = { 4000, 11000, 7000, 6000, 6000, 1000, 10000, 7000, 3000, 2000, 5000, 9000 };
        int[] priority = { 2, 1, 1, 3, 1, 3, 1, 3, 3, 2, 0, 1 };
        for (int i = 0; i < c.Length; i++)
        {
            for (int j = 0; j < obj.Length; j++)
                if (c[i].transform.Find(obj[j]))
                {
                    budget -= price[j];
                    score += priority[j];
                }
        }

    }

    public int exit(GameObject[] c)
    {
        int check = 1;
        for (int i = 0; i < c.Length; i++)
        {
            if (c[i].transform.childCount == 0)
            {
                check = 0;
            }
        }
        return check;
    }


    private void Start()
    {
        priority = 0;
    }
    // Use this for initialization
    private void Update()
    {
        int budget = 25000;
        int value = 0;
        gameScore(Pox, ref budget, ref value);
        priority = value;
        score.text = "Budget : " + (budget).ToString() + "   ";
        if (exit(Pox) == 1)
        {
            if (budget >= 0)
            {
                submit.gameObject.SetActive(true);
            }
        }
        else
        {
            submit.gameObject.SetActive(false);
        }
    }
    public void finish()
    {
        scene = 1;
        SceneManager.LoadScene(7);
    }
}
