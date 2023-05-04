using UnityEngine;
using System.Collections;

public class FollowHandRight : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offsetPosition;
    public Vector3 offsetRotation;
    //public GameObject leftHand;
    private void Awake()
    {
        objectToFollow = GameObject.FindGameObjectWithTag("RightHand").transform;
        //leftHand = GameObject.FindGameObjectWithTag("RightHand");
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
