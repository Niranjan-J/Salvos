using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
    public Question[] questions;
    private static List<Question> unansweredQuestions;
    public Text score;
    private static int i = 0;
    private static int j = 0;
    private Question currentQuestion;
    [SerializeField]
    private Text factText;
    [SerializeField]
    private Text opt1;
    [SerializeField]
    private Text opt2;
    [SerializeField]
    private Text opt3;
    [SerializeField]
    private Text opt4;
    [SerializeField]
    private float TimeBwQuestions = 1f;
    [SerializeField]
    private Animator animator;

    /*
    
    [SerializeField]
    private Text trueAnswer;
    [SerializeField]
    private Text falseAnswer;
    
    */
    void Start()
    {
        score.text = "Score:  " + i.ToString();
        if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        j++;
        if(j==4)
        {
            SceneManager.LoadScene(4);
        }
        SetCurrentQuestion ();
        
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;
        opt1.text = currentQuestion.option[0];
        opt2.text = currentQuestion.option[1];
        opt3.text = currentQuestion.option[2];
        opt4.text = currentQuestion.option[3];

        unansweredQuestions.RemoveAt(randomQuestionIndex);
    }

IEnumerator NextQuestion ()
{
    unansweredQuestions.Remove(currentQuestion);
    yield return new WaitForSeconds(TimeBwQuestions);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}



    public void Opt0 ()

    {
        
        if (currentQuestion.ans == 0)
        {
            i++;
            animator.SetTrigger("T_OP0");
        }
        else
        {
            animator.SetTrigger("F_OP0");
        }
        StartCoroutine(NextQuestion());
    }
    public void Opt1()
    {
        if (currentQuestion.ans == 1)
        {
            i++;
            animator.SetTrigger("T_OP1");
        }
        else
        {
            animator.SetTrigger("F_OP1");
        }
        StartCoroutine(NextQuestion());
    }
    public void Opt2()
    {
        if (currentQuestion.ans == 2)
        {
            i++;
            animator.SetTrigger("T_OP2");
        }
        else
        {
            animator.SetTrigger("F_OP2");
        }
        StartCoroutine(NextQuestion());
    }
    public void Opt3()
    {
        if (currentQuestion.ans == 3)
        {
            i++;
            animator.SetTrigger("T_OP3");
        }
        else
        {
            animator.SetTrigger("F_OP3");
        }
        StartCoroutine(NextQuestion());
    }


}
