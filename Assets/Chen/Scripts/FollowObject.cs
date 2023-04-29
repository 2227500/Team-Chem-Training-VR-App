using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour
{
    public Transform objectToFollow;

    void Start()
    {
      
        transform.parent = objectToFollow;
    }

    void Update()
    {
       
        Vector3 newPosition = objectToFollow.position;
        Quaternion newRotation = objectToFollow.rotation;

       
        transform.position = newPosition;
        transform.rotation = newRotation;
    }
}
