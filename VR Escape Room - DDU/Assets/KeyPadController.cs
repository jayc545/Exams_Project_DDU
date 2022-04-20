using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class KeyPadController : MonoBehaviour
{
    public string correctCode;

    public TMP_Text thing;

    private string userInput = "";

    [SerializeField] private TMP_InputField codeDisplay;
    [SerializeField] private float resetTime = 1f;
    [SerializeField] private string succesText;

    [Space(5f)]

    [Header("Keypad Entry Events")]

    public UnityEvent onCorrectPassword;
    public UnityEvent onInCorrectPassword;

    public bool allowMultipleActivation = false;
    private bool hasUsedCorrectCode = false;
    public bool HasUsedCorrectCode { get { return HasUsedCorrectCode; } }

    private void Awake()
    {
        string[] codeNumbers = new string[] { "1234", "2345", "3456", "4567" };
        correctCode = codeNumbers[UnityEngine.Random.Range(0, codeNumbers.Length)];

        Debug.Log("RE  :" + correctCode);

        thing.text = correctCode;
    }

    public void UserNumberEntry (string selevtedNum)
    {
        if (userInput.Length >= 4)
            return;

        userInput += selevtedNum;
        UpdateDisplay();

        if (userInput.Length >= 4)
            CheckPassword();
    }

    private void CheckPassword()
    {
            if(userInput != correctCode)
            {
                IncorrectPassword();
                return; 
        }
        correctPasswardGiven();
    }

    private void correctPasswardGiven()
    {
        if (allowMultipleActivation)
        {
            onCorrectPassword.Invoke();
            codeDisplay.text = succesText;

            StartCoroutine(ResetKeycode());
        }
        else if(!allowMultipleActivation && !hasUsedCorrectCode)
        {
            onCorrectPassword.Invoke();
            hasUsedCorrectCode = true;
            codeDisplay.text = succesText;
        }
    }


    private void IncorrectPassword()
    {
        onInCorrectPassword.Invoke();
        StartCoroutine(ResetKeycode());
    }

    private void UpdateDisplay()
    {
        codeDisplay.text = null;

            codeDisplay.text += userInput;
        
    }

    public void DeleteEntry()
    {
        if (userInput.Length <= 0)
            return;
        userInput = "";

        UpdateDisplay();
    }

    IEnumerator ResetKeycode()
    {
        yield return new WaitForSeconds(resetTime);
        codeDisplay.text = "";
    }
}
