using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class QuizManager : MonoBehaviour
{
    public XRPushButton trueButton;
    public XRPushButton falseButton;

    public TMP_Text scoreText;
    public TMP_Text questionCounterText;
    private int playerScore = 0;

    private string[] questions = new string[5] { "Question 1", "Question 2", "Question 3", "Question 4", "Question 5" };
    private int currentQuestionIndex = 0;

    void Start()
    {
        trueButton.onPress.AddListener(TrueClicked);
        falseButton.onPress.AddListener(FalseClicked);
        ShowQuestion();
    }

    void TrueClicked()
    {
        CheckAnswer(true);
    }

    void FalseClicked()
    {
        CheckAnswer(false);
    }

    void CheckAnswer(bool answer)
    {
        if (answer == true)
        {
            Debug.Log("Correct!");
            playerScore += 10;
            scoreText.text = "Score: " + playerScore.ToString();
        }
        else
        {
            Debug.Log("Incorrect!");
            playerScore -= 5;
            scoreText.text = "Score: " + playerScore.ToString();
        }

        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            EndQuiz();
        }
    }

    void ShowQuestion()
    {
        // Display the current question
        Debug.Log(questions[currentQuestionIndex]);
        questionCounterText.text = "Question " + (currentQuestionIndex + 1).ToString() + " of " + questions.Length.ToString();
    }

    void EndQuiz()
    {
        // Display the final score
        Debug.Log("Final Score: " + playerScore.ToString());
    }
}