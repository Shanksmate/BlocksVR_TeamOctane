using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjectivesManager : MonoBehaviour
{
    public int boardNumber;
    public int boardCount;

    public int acrowNumber;
    public int acrowCount;

    public int flatTieNumber;
    public int flatTieCount;

    public UnityEvent onBoardCompleted;
    public UnityEvent onObjectivesCompleted;
    private int completedTaskCount;
    private int maxCompletedTaskCount = 5;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckObjective(Toggle objective = null)
    {
        if (completedTaskCount == maxCompletedTaskCount)
        {
            onObjectivesCompleted.Invoke();
            return;
        }
        else if (objective != null)
        {
            objective.isOn = true;
            completedTaskCount++;
        }

    }

    public void OnBoardFixed(Toggle boardToggle)
    {
     
        boardCount++;
        if(boardCount == boardNumber)
        {
            CheckObjective(boardToggle);
            onBoardCompleted.Invoke();
        }

    }

    public void OnBoardRemoved()
    {
        boardCount--;
    }

    public void OnAcrowFixed(Toggle acrowToggle)
    {
        acrowCount++;
        if(acrowCount == acrowNumber)
        {
            CheckObjective(acrowToggle);
        }
    }

    public void OnAcrowRemoved()
    {
        acrowCount--;
    }




}
