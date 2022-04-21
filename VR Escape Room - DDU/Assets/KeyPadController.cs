using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Linq;


/// <summary>
/// /FOR THE KEYPAD 
/// 
/// LIST OF FUNCTION
/// - Keypad with NUMPAD
/// - Checking the Correct code
/// - Randomizing the code.
/// 
/// 
/// </summary>
public class KeyPadController : MonoBehaviour
{
    [Header("Current Key and Key value")]
    public string correctCode;
    public string key;

    [Space(5f)]

    [Header("Other Objects")]
    public TMP_Text thing;
    private string userInput = "";
    [SerializeField] private TMP_InputField codeDisplay;
    [SerializeField] private float resetTime = 1f;
    [SerializeField] private string succesText;
    [SerializeField] private Collider doorHandleCollider;

    [Space(5f)]

    [Header("Keypad Entry Events")]

    public UnityEvent onCorrectPassword;
    public UnityEvent onInCorrectPassword;

    public bool allowMultipleActivation = false;
    private bool hasUsedCorrectCode = false;
    public bool HasUsedCorrectCode { get { return HasUsedCorrectCode; } }



    private void Translater()
    {
        //Making a map of the Randomized code with the key and the key value.. aka the code.
        System.Random random = new System.Random();

        var map = new Dictionary<string, int>();
        map.Add("A", 04061);  map.Add("B", 19603); map.Add("C", 42069); map.Add("D", 73591); map.Add("E", 22100);
        map.Add("F", 20542); map.Add("G", 93487); map.Add("H", 65647); map.Add("I", 35822); map.Add("J", 23451);
        map.Add("K", 51274); map.Add("L", 88730); map.Add("M", 17350); map.Add("N", 17350); map.Add("O", 05039);

        int result = map["A"];
        var myKey = map.FirstOrDefault(x => x.Value == 04061).Key;
        
        ///// Tester of the map, getting the key and key-value.
       // Debug.Log(" The First Code  :" + result + "    And Value of the First Code thing the Key : " + myKey);

        //Choosing a Random Key and Code
        int index = random.Next(map.Count);
        KeyValuePair<string, int> pair = map.ElementAt(index);
        ////Another tester prints the chosen key and keyvalue/KeyCode.
        Debug.Log("key: " + pair.Key + ", value: " + pair.Value); ;

        //Objects of the choosen Key and keyValue.
        correctCode = pair.Value.ToString(); //Note It translates from intiger to String.
        key = pair.Key;

        //Shows the Keycode to the Keypad.
        /////TODO Make the translator thing
        thing.text = key;
    }


    private void Awake()
    {
        //Basicually starts the RandomCode Function for the Keypad.
        Translater();

        doorHandleCollider.enabled = false;
    }
    
    public void UserNumberEntry (string selevtedNum)
    {
        if (userInput.Length >= 5)
            return;

        userInput += selevtedNum;
        UpdateDisplay();

        if (userInput.Length >= 5)
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
    
    private void correctPasswardGiven() // If the Correct code is given there will be a congrats screen and the door will be unlocked.
    {
        if (allowMultipleActivation)
        {
            onCorrectPassword.Invoke();
            codeDisplay.text = succesText;
            doorHandleCollider.enabled = true;

            StartCoroutine(ResetKeycode());
        }
        else if(!allowMultipleActivation && !hasUsedCorrectCode)
        {
            onCorrectPassword.Invoke();
            hasUsedCorrectCode = true;
            codeDisplay.text = succesText;
            doorHandleCollider.enabled = true;
        }
    }


    private void IncorrectPassword() // If the code is correct.
    {
        onInCorrectPassword.Invoke();
        StartCoroutine(ResetKeycode());
    }

    private void UpdateDisplay()//Updates the screen everytime the player presses the button. So We don't need to used void Update.
    {
        codeDisplay.text = null;

            codeDisplay.text += userInput;
        
    }

    public void DeleteEntry() //If the user Presses on the delete-Button the player with delete...duujh.
    {
        if (userInput.Length <= 0)
            return;
        userInput = "";

        UpdateDisplay();
    }

    IEnumerator ResetKeycode() ///Reset the Keycode for whatever the reason.
    {
        yield return new WaitForSeconds(resetTime);
        codeDisplay.text = "";
    }

    private void NotUsedCode()
    {
        /*
          var map = new Dictionary codeNumbers = new string[] { "04061", 
    "19603", "42069" , "73591", "22100", "20542", "93487", "65647", "35822", 
    "23451", "51274", "88730", "73682", "17350", "05039"};
correctCode = codeNumbers[UnityEngine.Random.Range(0, codeNumbers.Length)];

Debug.Log("RE  :" + correctCode + "  The First code :  " +  codeNumbers.ElementAt(0));

thing.text = correctCode;
/*
switch (codeNumbers.ElementAt(0))
{
    case "04061":
        Debug.Log("A");
        break;
    case "19603":
        Debug.Log("REEEEEEEEEe");
        break;
    case "42069":
        Debug.Log("REEEEEEEEEe");
        break;
    case "73591":
        Debug.Log("REEEEEEEEEe");
        break;
    case "22100":
        Debug.Log("REEEEEEEEEe");
        break;
    case "20542":
        Debug.Log("REEEEEEEEEe");
        break;
    case "93487":
        Debug.Log("REEEEEEEEEe");
        break;
    case "65647":
        Debug.Log("REEEEEEEEEe");
        break;
    case "35822":
        Debug.Log("REEEEEEEEEe");
        break;
    case "23451":
        Debug.Log("REEEEEEEEEe");
        break;
    case "51274":
        Debug.Log("REEEEEEEEEe");
        break;
    case "88730":
        Debug.Log("REEEEEEEEEe");
        break;
    case "73682":
        Debug.Log("REEEEEEEEEe");
        break;
    case "17350":
        Debug.Log("REEEEEEEEEe");
        break;
}
*/
    }
}
