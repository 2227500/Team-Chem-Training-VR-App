using UnityEngine;
using System.Collections;

public class FollowHand : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offsetPosition;
    public Vector3 offsetRotation;
    public GameObject hand;
    private void Awake()
    {
        objectToFollow = hand.transform;
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
