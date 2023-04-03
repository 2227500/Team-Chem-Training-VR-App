///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This script helps to enable the teleportation from the hand choice of the user.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;


public class TeleportationStatus : MonoBehaviour
{
    public CheckXRRigStatus rigStatus;

    private void Awake()
    {
        
    }
    private void Start()
    {
        if (rigStatus.teleportMovementStatus)
        {
            LeftXRTeleportRayEnableOrDisable();
            RightXRTeleportRayEnableOrDisable();
        }
        else if (!rigStatus.teleportMovementStatus)
        {
            gameObject.GetComponent<XRRayInteractor>().enabled = false;
        }
        Debug.Log("XR RayInteractor Choice");
    }

    /// <summary>
    /// Enable or disable left hand teleport functionality
    /// </summary>
    public void LeftXRTeleportRayEnableOrDisable()
    {
        if (rigStatus.isLeftDominantHand && gameObject.tag == "LeftTeleportInteractor")
        {
            gameObject.GetComponent<XRRayInteractor>().enabled = true;
            Debug.Log("Left XR RayInteractor enabled");
        }
        else if (!rigStatus.isLeftDominantHand && rigStatus.isRightDominantHand && gameObject.tag == "LeftTeleportInteractor")
        {
            gameObject.GetComponent<XRRayInteractor>().enabled = false;
            Debug.Log("Left XR RayInteractor disabled");
        }
    }
    /// <summary>
    /// Enable or disable right hand teleport functionality
    /// </summary>
    public void RightXRTeleportRayEnableOrDisable()
    {
        if (rigStatus.isRightDominantHand && gameObject.tag == "RightTeleportInteractor")
        {
            gameObject.GetComponent<XRRayInteractor>().enabled = true;
            Debug.Log("Right XR RayInteractor enabled");
        }
        else if (!rigStatus.isRightDominantHand && rigStatus.isLeftDominantHand && gameObject.tag == "RightTeleportInteractor")
        {
            gameObject.GetComponent<XRRayInteractor>().enabled = false;
            Debug.Log("Right XR RayInteractor disabled");
        }
    }


    private void Update()
    {
        if (rigStatus.teleportMovementStatus)
        {
            LeftXRTeleportRayEnableOrDisable();
            RightXRTeleportRayEnableOrDisable();
        }
        else if (!rigStatus.teleportMovementStatus)
        {
            gameObject.GetComponent<XRRayInteractor>().enabled = false;
        }
        Debug.Log("XR RayInteractor Choice");
    }
}
