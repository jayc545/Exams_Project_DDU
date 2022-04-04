using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class checkerb : MonoBehaviour
{
    [SerializeField] private Transform Correct;
    private XRSocketInteractor socket;

    private void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socket.selectEntered.AddListener(ObjectSnapped);
        socket.selectExited.AddListener(ObjectRemoved);
    }
    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(ObjectSnapped);
        socket.selectExited.RemoveListener(ObjectRemoved);
    }


    private void ObjectSnapped(SelectEnterEventArgs arg0)
    {
        var snappedObjectName = arg0.interactableObject;
        if (snappedObjectName.transform.tag == "yellow")
        {
            Debug.Log("REEEEE");
        }
    }    
    
    private void ObjectRemoved(SelectExitEventArgs arg0)
    {
        throw new NotImplementedException();
    }
}
