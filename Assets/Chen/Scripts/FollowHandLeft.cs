using UnityEngine;
using System.Collections;

public class FollowHandLeft : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offsetPosition;
    public Vector3 offsetRotation;
    //public GameObject leftHand;
    private void Awake()
    {
        objectToFollow = GameObject.FindGameObjectWithTag("LeftHand").transform;
        //leftHand = GameObject.FindGameObjectWithTag("LeftHand");
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
