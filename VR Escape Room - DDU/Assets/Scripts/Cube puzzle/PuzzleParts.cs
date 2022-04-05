using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzleParts : MonoBehaviour
{

    [SerializeField] private puzzleController LinkedPuzzleManager;
    [SerializeField] public string tags;
    private XRSocketInteractor socket;

    private void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
        //Takes the socket interactor.
    }

    private void OnEnable()
    {
        //The Socket interactors events.
        /////This is when we enter the socket.
        socket.selectEntered.AddListener(ObjectSnapped);
        socket.selectExited.AddListener(ObjectRemoved);
    }
    private void OnDisable()
    {
        //The Socket Interactors events.
        ////The is when we
        socket.selectEntered.RemoveListener(ObjectSnapped);
        socket.selectExited.RemoveListener(ObjectRemoved);
    }


    private void ObjectSnapped(SelectEnterEventArgs arg0)
    {
        //Take the interactable object and takes its data.
        var snappedObjectName = arg0.interactableObject;

        if (snappedObjectName.transform.tag == tags)
        {
            Debug.Log("Correct socket");
            LinkedPuzzleManager.CompletedPuzzleTasks();
        }
    }

    private void ObjectRemoved(SelectExitEventArgs arg0)
    {
        //Take the interactable object and takes its data.
        var RemovedObjectName = arg0.interactableObject;
        //
        if (RemovedObjectName.transform.tag == tags)
        {
            LinkedPuzzleManager.PuzzlePieceRemoved();
            Debug.Log("Removed");
        }
    }
}
