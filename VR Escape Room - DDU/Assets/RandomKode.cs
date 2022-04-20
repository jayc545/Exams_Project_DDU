using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomKode : MonoBehaviour
{

    string randomCode;
    public  void Start()
    {
        string[] codeNumbers = new string[] { "1234", "2345", "3456", "4567" };
        randomCode = codeNumbers[UnityEngine.Random.Range(0, codeNumbers.Length)];

        Debug.Log(randomCode);
    }

    public void RandomCode(string TheCode)
    {
        string[] codeNumbers = new string[] { "1234", "2345", "3456", "4567" };
        randomCode = codeNumbers[UnityEngine.Random.Range(0, codeNumbers.Length)];

        Debug.Log("RE  :"+randomCode);
    }
}
