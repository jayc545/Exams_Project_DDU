using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public MeshRenderer itemModel;

    public float itemRotationSpeed = 50f;
    public float itemBobSpeed = 2f;
    private Vector3 basePosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, itemRotationSpeed * Time.deltaTime, Space.World);
        transform.position = basePosition + new Vector3(3.221f, 1.26f + 0.25f * Mathf.S(Time.time * itemBobSpeed), 0f);
    }
}
