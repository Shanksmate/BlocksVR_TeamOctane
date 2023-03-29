using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjectivesManager : MonoBehaviour
{
    public int boardnumber;
    public int boardcount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckObjective(Toggle objective = null)
    {
        if (objective != null)
        {
            objective.isOn = true;
        }

    }

    public void OnBoardFixed(Toggle boardToggle)
    {
     
        boardcount++;
        if(boardcount == boardnumber)
        {
            CheckObjective(boardToggle);
        }

    }

    public void OnBoardRemoved()
    {
        boardcount--;
    }


    
}
