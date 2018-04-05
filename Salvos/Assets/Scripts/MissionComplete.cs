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
        AudioSource[] a;
        a = gameObject.GetComponentsInParent<AudioSource>();
        a[0].PlayDelayed(0.8f);
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
            else if (ScoreController.i == 2)
            {
                starsCount = 2;
                animator.SetTrigger("Star_2");
            }
            else if (ScoreController.i == 3)
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
            else if (Mission2Character.j == 2)
            {
                starsCount = 2;
                animator.SetTrigger("Star_2");
            }
            else if (Mission2Character.j == 3)
            {
                isFinished = true;
                starsCount = 3;
                animator.SetTrigger("Star_3");
            }
        }
        else
   if (GameScript.scene == 1)
        {
            levelIndex = 3;
            if (GameScript.priority == 0)
            {
                starsCount = 0;
                animator.SetTrigger("Star_0");
            }
            else
            if (GameScript.priority <= 10)
            {
                starsCount = 1;
                animator.SetTrigger("Star_1");
            }
            else if (GameScript.priority <= 15)
            {
                starsCount = 2;
                animator.SetTrigger("Star_2");
            }
            else if (GameScript.priority > 15)
            {
                isFinished = true;
                starsCount = 3;
                animator.SetTrigger("Star_3");
            }
        }
        else
   if (GameManager.scene == 1)
        {
            levelIndex = 4;
            if (GameManager.i == 0)
            {
                starsCount = 0;
                animator.SetTrigger("Star_0");
            }
            else
            if (GameManager.i <= 5)
            {
                starsCount = 1;
                animator.SetTrigger("Star_1");
            }
            else if (GameManager.i <= 8)
            {
                starsCount = 2;
                animator.SetTrigger("Star_2");
            }
            else if (GameManager.i > 8)
            {
                isFinished = true;
                starsCount = 3;
                animator.SetTrigger("Star_3");
            }
            GameManager.i = 0;
        }
        if (PlayerPrefsX.GetBool("isFinished" + levelIndex.ToString(), false))
        {
            isFinished = true;
        }
        PlayerPrefsX.SetBool("isFinished" + levelIndex.ToString(), isFinished);
        if (!PlayerPrefs.HasKey("startsCount" + levelIndex.ToString()))
            PlayerPrefs.SetInt("startsCount" + levelIndex.ToString(), starsCount);

        else if (starsCount > PlayerPrefs.GetInt("startsCount" + levelIndex.ToString()))
            PlayerPrefs.SetInt("startsCount" + levelIndex.ToString(), starsCount);

    }



    public void Menu()
    {
        if (PopupHandler.scene == 1)
        {
            PopupHandler.scene = 0;
        }
        if (Mission2PopupHandler.scene == 1)
        {
            Mission2PopupHandler.scene = 0;
        }
         if (GameScript.scene == 1)
        {
            GameScript.scene = 0;
        }
        if (GameManager.scene == 1)
        {
            GameManager.scene = 0;
        }
        SceneManager.LoadScene(6);
    }

    public void Retry()
    {
        if (PopupHandler.scene == 1)
        {
            SceneManager.LoadScene(1);
        }
        if (Mission2PopupHandler.scene == 1)
        {
            SceneManager.LoadScene(2);
        }
        if (GameScript.scene == 1)
        {
            SceneManager.LoadScene(3);
        }
        if (GameManager.scene == 1)
        {
            SceneManager.LoadScene(4);
        }
       
        
        

    }

}
