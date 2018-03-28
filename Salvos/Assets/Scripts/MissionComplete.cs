using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MissionComplete : MonoBehaviour
{
    int levelIndex;
    bool isFinished = false;
    int starsCount;
    [SerializeField]
    private Animator animator;

    void Start()
    {
       
             if (PopupHandler.scene == 1)
        {
            levelIndex = 1;
            if (ScoreController.i == 0)
            {
                starsCount = 0;
                animator.SetTrigger("Star_0");
            }
            else
            if (ScoreController.i == 1)
            {
                starsCount = 1;
                animator.SetTrigger("Star_1");
            }
            else if (ScoreController.i <= 2)
            {
                starsCount = 2;
                animator.SetTrigger("Star_2");
            }
            else
            {
                isFinished = true;
                starsCount = 3;
                animator.SetTrigger("Star_3");
            }
        }
        else
             if (Mission2PopupHandler.scene == 1)
        {
            levelIndex = 2;
            if (Mission2Character.j == 0)
            {
                starsCount = 0;
                animator.SetTrigger("Star_0");
            }
            else
            if (Mission2Character.j == 1)
            {
                starsCount = 1;
                animator.SetTrigger("Star_1");
            }
            else if (Mission2Character.j <= 2)
            {
                starsCount = 2;
                animator.SetTrigger("Star_2");
            }
            else
            {
                isFinished = true;
                starsCount = 3;
                animator.SetTrigger("Star_3");
            }
        }else
        if (GameManager.scene == 1)
        {
            levelIndex = 3;
            if (GameManager.i == 0)
            {
                starsCount = 0;
                animator.SetTrigger("Star_0");
            }
            else
            if (GameManager.i <= 4)
            {
                starsCount = 1;
                animator.SetTrigger("Star_1");
            }
            else if (GameManager.i <= 8)
            {
                starsCount = 2;
                animator.SetTrigger("Star_2");
            }
            else
            {
                isFinished = true;
                starsCount = 3;
                animator.SetTrigger("Star_3");
            }
            GameManager.i = 0;
        }
            PlayerPrefsX.SetBool("isFinished" + levelIndex.ToString(), isFinished);
        if (!PlayerPrefs.HasKey("startsCount" + levelIndex.ToString()))
            PlayerPrefs.SetInt("startsCount" + levelIndex.ToString(), starsCount);

        else if (starsCount > PlayerPrefs.GetInt("startsCount" + levelIndex.ToString()))
            PlayerPrefs.SetInt("startsCount" + levelIndex.ToString(), starsCount);

    }



    public void Menu()
    {
        if (Mission2PopupHandler.scene == 1)
        {
            Mission2PopupHandler.scene = 0;
        }
        else
       if (GameManager.scene == 1)
        {
            GameManager.scene = 0;
        }
        else
        if (PopupHandler.scene == 1)
        {
            PopupHandler.scene = 0;
        }
        SceneManager.LoadScene(5);
    }

    public void Retry()
    {
        if (GameManager.scene == 1)
        {
            SceneManager.LoadScene(2);
        }
        if (PopupHandler.scene == 1)
        {
            SceneManager.LoadScene(1);
        }

    }

}
