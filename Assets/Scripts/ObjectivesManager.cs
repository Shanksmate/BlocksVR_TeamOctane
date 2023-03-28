using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjectivesManager : MonoBehaviour
{
    // Start is called before the first frame update
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
            Color color = GetComponentInChildren<Color>();
            color = Color.green;
        }

    }

    
}
