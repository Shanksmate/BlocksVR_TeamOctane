using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR.Content.Interaction;

public class QuizManager : MonoBehaviour
{
    public XRPushButton trueButton;
    public XRPushButton falseButton;

    
    public TMP_Text scoreText;
    public TMP_Text questionCounterText;
    public TMP_Text questionText; // Added public variable to display the current question
    private int playerScore = 0;

    // Added Unity events for when the quiz starts and when the quiz ends
    public UnityEvent onQuizStart;
    public UnityEvent onQuizEnd;

    // Changed questions array to store Question objects
    [SerializeField] private List<QuestionType1> questionsList;
    private int currentQuestionIndex = 0;

    // Added Question class to store question text and correct answer

    [System.Serializable]
    public class QuestionType1
    {
        public string questionText;
        public bool correctAnswer;

    }

    private void Start()
    {
        // Add null checks for trueButton and falseButton
        if (trueButton != null)
        {
            trueButton.onPress.AddListener(TrueClicked);
        }
        else
        {
            Debug.LogError("trueButton is not assigned in the Inspector!");
        }

        if (falseButton != null)
        {
            falseButton.onPress.AddListener(FalseClicked);
        }
        else
        {
            Debug.LogError("falseButton is not assigned in the Inspector!");
        }

    }
    // Added public StartQuiz function that can be called from the Unity editor to start the quiz
    public void StartQuiz()
    {

        // Invoke the onQuizStart event
        onQuizStart.Invoke();
        playerScore = 0;
        ShowQuestion();
    }

    void TrueClicked()
    {
       // Check if the quiz is still in progress
       CheckAnswer(true);
    }

    void FalseClicked()
    {
        // Check if the quiz is still in progress
        CheckAnswer(false);
    }

    void CheckAnswer(bool answer)
    {
        // Check if currentQuestionIndex is within the bounds of the questions array
        if (currentQuestionIndex < 0 || currentQuestionIndex > questionsList.Count - 1)
        {
            return;
        }

        // Check if player's answer is equal to the correct answer for the current question
        if (answer == questionsList[currentQuestionIndex].correctAnswer)
        {
            Debug.Log("Correct!");
            playerScore += 10;
           
        }
        else
        {
            Debug.Log("Incorrect!");
            playerScore += 0;
            // Removed code to update scoreText during gameplay
        }


        if (currentQuestionIndex == questionsList.Count -1)
        {
            EndQuiz();
            return;
        }

        currentQuestionIndex++;
        ShowQuestion(currentQuestionIndex);
       
    }

    void ShowQuestion(int questionIndex = 0)
    {
        if (questionIndex < 0 || questionIndex > questionsList.Count-1)
        {
            return;
        }

        questionText.text = questionsList[questionIndex].questionText;
        questionCounterText.text = "Question " + (questionIndex + 1).ToString() + " of " + questionsList.Count.ToString();

        currentQuestionIndex = questionIndex;

    }

    void EndQuiz()
    {
        // Invoke the onQuizEnd event
        onQuizEnd.Invoke();

        // Display the player's results
        DisplayResults();
    }

    void DisplayResults()
    {
        // Add null check for scoreText
        if (scoreText != null)
        {
            // Calculate the total possible score for the quiz
            int totalPossibleScore = questionsList.Count * 10;

            // Display the player's final score and total possible score at the end of the quiz
            scoreText.text = "Final Score: " + playerScore.ToString() + " / " + totalPossibleScore.ToString();
        }
        else
        {
            Debug.LogError("scoreText is not assigned in the Inspector!");
        }

    }

    public void ResetQuiz()
    {
        currentQuestionIndex = 0;
        playerScore = 0;
        //UpdateUI();
    }

    /*private void UpdateUI()
    {
        // Add null check for scoreText
        if (scoreText != null)
        {
            // Update the scoreText UI element to display the current player score
            scoreText.text = "Score: " + playerScore.ToString();
        }
        else
        {
            Debug.LogError("scoreText is not assigned in the Inspector!");
        }

        // Add null check for questionCounterText
        if (questionCounterText != null)
        {
            // Update the questionCounterText UI element to display the current question number
            questionCounterText.text = "Question " + (currentQuestionIndex + 1).ToString() + " of " + questions.Length.ToString();
        }
        else
        {
            Debug.LogError("questionCounterText is not assigned in the Inspector!");
        }

        // Add null check for questionText
        if (questionText != null)
        {
            // Update the questionText UI element to display the current question text
            questionText.text = questions[currentQuestionIndex].questionText;
        }
        else
        {
            Debug.LogError("questionText is not assigned in the Inspector!");
        }
    }*/
}