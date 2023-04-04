using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Content.Interaction;

public class QuestionManager : MonoBehaviour
{
     
    bool questionResult;
    string[] questions;

    public UnityEvent onQuizStarted;
    public UnityEvent onQuizEnded;
    
    public TMP_Text question;
    public TMP_Text questionCount;

    private int playerScore;


    public XRPushButton True;
    public XRPushButton False;

    // Start is called before the first frame update
    void StartQuiz()
    {
        //Reset Score
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateQuestion(string[] questions, string question)
    {
        //loop through array of questions and set UI values to string text
        
        for (int i = 0; i < questions.Length; i++)
        {

        }

        
    }

    public void ValidateQuestion()
    {



        
    }

    public void ResetScore()
    {

    }

    public void DisplayResult(int score)
    {

    }

   








}
