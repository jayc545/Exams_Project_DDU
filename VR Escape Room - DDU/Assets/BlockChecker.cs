using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour
{
    public int check = 0;


    public void ExitColision()
    {
        check -=1;
    }

    public void Plus()
    {
        check++;
    }
}
