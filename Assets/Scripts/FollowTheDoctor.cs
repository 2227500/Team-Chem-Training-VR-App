///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This script helps the NPC to follow the doctor.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheDoctor : MonoBehaviour
{
    public Transform objectToFollow; // object to follow by manikin


    public bool isGathered; // bool to check whether manikin found XR Rig

    [SerializeField]
    private float _speed; // speed of walk
    public float targetDistance; // distance between XR Rig and manikin
    public float allowedDistance; // distance allowed between Manikin and XR Rig
    private float _distanceToXRrig; // current distance between XRRig and player

    public RaycastHit Shot;

    [SerializeField]
    private Animator avatarAnimator; // manikin animator


    public bool enteredDoctorArea; // bool for entering helicopter area


    #region Monobehaviour Methods
    void Start()
    {
        avatarAnimator = gameObject.GetComponent<Animator>();
        isGathered = false;
        enteredDoctorArea = false;
    }

    void Update()
    {
        // method to check whether the manikin is found by player
        CheckingGatheredOrNot();

        // Checking whether the player gathered all the NPC and they have not entered the helicopter area
        if (isGathered == true && !enteredDoctorArea)
        {
            // method for following the XR Rig(player) 
            FollowThePlayer();

            //ManikinDeathAnimationTransition();
        }

        // Checking NPC's entering helicopter area
        if (enteredDoctorArea)
        {
            //EnetredHelicopterArea();
        }
    }

    /// <summary>
    /// Checking a bool whether the manikin has entered the 'HelicopterSaveArea'
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DoctorTargetArea")
        {
            //enteredDoctorArea = true;
            isGathered = true;
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Bool to check whether the manikins are gathered by player
    /// </summary>
    void CheckingGatheredOrNot()
    {
        //Calculating distance between the object to follow and gameobject attached with this script
        _distanceToXRrig = Vector3.Distance(objectToFollow.position, transform.position);

        if (_distanceToXRrig < 6)
        {
            //isGathered = true;
        }
    }


    /// <summary>
    /// Method for the Manikin to follow the XR_Rig (Player) using Raycast and calculating distance between Player and Manikin.
    /// Also appropriate character animation will be player.
    /// </summary>
    void FollowThePlayer()
    {
        _distanceToXRrig = Vector3.Distance(objectToFollow.position, transform.position);

        // looking at XR Rig (player)
        transform.LookAt(objectToFollow);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot) && isGathered == true && enteredDoctorArea == false)
        {
            // Checking whether the raycast hit properly to thr target object, i.e Player.
            Debug.DrawRay(transform.position, transform.forward, Color.blue, 15f);

            // target distance is equal to the ray hit distance
            targetDistance = Shot.distance;

            if (targetDistance >= allowedDistance)
            {
                //speed of walk
                _speed = 0.02f;
                avatarAnimator.Play("Walking");  // playing animation Walking
                // moving manikin towards player
                transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position, _speed);
            }
            else
            {
                _speed = 0f;
                avatarAnimator.Play("Idle");   // playing idle animation
            }
        }
    }

    #endregion
}
