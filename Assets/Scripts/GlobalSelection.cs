using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class GlobalSelection : MonoBehaviour
{
    public int stepID;
    public int parentID;    
    GameObject formworkParent;

    
    // Start is called before the first frame update
    void Start()
    {
        
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ValidateStep()
    {
        XRSocketInteractor socket;
        
        socket = GetComponent<XRSocketInteractor>();

        //socket.onHoverEnter.AddListener();



    }


}
