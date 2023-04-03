///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This script helps to enable the teleportaion area in the second scene.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRRigStatus : MonoBehaviour
{
    [SerializeField]
    private bool teleportationOpted;
    [SerializeField]
    private TeleportationArea hospitalTeleportArea;
    [SerializeField]
    public CheckXRRigStatus xRRigStatus;


    private void Awake()
    {
        hospitalTeleportArea = GameObject.FindObjectOfType<TeleportationArea>();
        xRRigStatus = GameObject.FindObjectOfType<CheckXRRigStatus>();
        Debug.Log("New Scene Loaded");
    }

    private void Start()
    {
        ActivateOrDeactiveteTeleportArea();
    }


    public void ActivateOrDeactiveteTeleportArea()
    {
        if (xRRigStatus.teleportMovementStatus)
        {
            hospitalTeleportArea.enabled = true;
        }
        else if (!xRRigStatus.teleportMovementStatus)
        {
            hospitalTeleportArea.enabled = false;
        }
    }
}
