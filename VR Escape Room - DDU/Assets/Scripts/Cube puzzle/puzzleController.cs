using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class puzzleController : MonoBehaviour
{
    [SerializeField] private int numberOfTasksToComplete;//The Number of task needed to be completeted.
    [SerializeField] private int currentlyCompletedTasks = 0;

    [Header("Completion Events")]
    [SerializeField] ParticleSystem Particle1 = null;
    [SerializeField] ParticleSystem Particle2 = null;
    [SerializeField] MeshRenderer winText = null;
    [SerializeField] GameObject Tablet = null;


    public void TaskDone()
    {
        //winText.enabled = true; 
        Particle1.Play();
        Particle2.Play();
        Tablet.SetActive(true);
    }

    public void CompletedPuzzleTasks()
    { //When the task is correctly completed.

        currentlyCompletedTasks++;
        //Checks if all the task is completed.
        CheckForPuzzleCompletion();
    }

    private void CheckForPuzzleCompletion()
    {
        //If all the task is completed an event will happen.
        if (currentlyCompletedTasks >= numberOfTasksToComplete)
        {
            TaskDone();
            Debug.Log("Everything works just fine!");
            //onPuzzleCompletion.Invoke();
        }
    }

    public void PuzzlePieceRemoved()
    {
        currentlyCompletedTasks--;
    }
}
