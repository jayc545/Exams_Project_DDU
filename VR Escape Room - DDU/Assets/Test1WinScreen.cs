using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1WinScreen : MonoBehaviour
{
    public static Test1WinScreen instance;
    public Transform[] socket, cube; //Sockets for the cubes

    public MeshRenderer text; //Mesh renderer for text

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        text.enabled = true;
        for (int i = 0; i < socket.Length; i++)
        {
            if (socket[i].position != cube[i].position)
            {
                text.enabled = false;
            }
        }
    }
}
