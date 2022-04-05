using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private int numberOfTasksToComplete;//The Number of task needed to be completeted.
    private int currentlyCompletedTasks = 0;

    [Header("Completion Events")]
    public UnityEvent onPuzzleCompletion;

    public void CompletedPuzzleTasks()
    { //When the task is correctly completed.
        currentlyCompletedTasks++;
        //Checks if all the task is completed.
        CheckForPuzzleCompletion();
    }

    private void CheckForPuzzleCompletion()
    {
        //If all the task is completed an event will happen.
        if(currentlyCompletedTasks >= numberOfTasksToComplete)
        {
            onPuzzleCompletion.Invoke();
        }
    }

    public void PuzzlePieceRemoved()
    {
        currentlyCompletedTasks--;
    }
}
