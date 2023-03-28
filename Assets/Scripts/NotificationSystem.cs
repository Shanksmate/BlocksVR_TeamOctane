using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotificationSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text currentDockHeader;
    [SerializeField] private TMP_Text currentDockObjective;
    [SerializeField] private Image currentDockImage;
    [SerializeField] private TMP_Text currentHoveredItem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowMessage(string message = "hint")
    {
        //UI animation
        currentHoveredItem.text = message;

        //delay for x seconds
        //UI amination out 
        Debug.Log(message);
    }

    public void UpdateDock(string objectiveIndex = "Index")
    {
        if(objectiveIndex == "1")
        {
            currentDockObjective.text = "Connect Rebar object to assembly point";
            //currentDockImage.sprite = sourceImage;
        }

        if (objectiveIndex == "2")
        {
            currentDockObjective.text = "Grab and set the Kicker";
            //currentDockImage.sprite = sourceImage;
        }
        if (objectiveIndex == "3")
        {
            currentDockObjective.text = "Grab and join the marine boards";
            //currentDockImage.sprite = sourceImage;
        }
        if (objectiveIndex == "4")
        {
            currentDockObjective.text = "Brace the forwork using wood ties and acrow pipes";
            //currentDockImage.sprite = sourceImage;
        }
        if (objectiveIndex == "5")
        {
            currentDockObjective.text = "Mix and pour the reinforced concrete mix";
            //currentDockImage.sprite = sourceImage;
        }

    }
}

