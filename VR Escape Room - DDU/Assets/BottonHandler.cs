using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BottonHandler : MonoBehaviour
{
    public TMP_Text funnyText;

    private void Start()
    {
        funnyText.enabled = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void QuitGame()
    {
        funnyText.enabled = true;
       // Application.Quit();
    }
}
