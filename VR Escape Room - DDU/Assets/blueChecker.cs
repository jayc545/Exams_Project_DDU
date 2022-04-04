using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueChecker : MonoBehaviour
{
    public BlockChecker blockChecker;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "blue")
            blockChecker.Plus();
            }
}
