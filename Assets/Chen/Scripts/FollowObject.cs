using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offsetPosition;
    public Vector3 offsetRotation;

    private void Awake()
    {
        objectToFollow = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    void Start()
    {

        //transform.parent = objectToFollow;
        transform.position = objectToFollow.position;
    }

    void Update()
    {

        Vector3 newPosition = objectToFollow.position + offsetPosition;
        Quaternion newRotation = objectToFollow.rotation;
        

       
        transform.position = newPosition;
        transform.rotation = newRotation;

        transform.Rotate(offsetRotation);
    }
}
