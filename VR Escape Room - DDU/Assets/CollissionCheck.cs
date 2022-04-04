using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CollissionCheck : MonoBehaviour
{
    public Rigidbody rigidbody;

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.collider.tag);

    }
}
