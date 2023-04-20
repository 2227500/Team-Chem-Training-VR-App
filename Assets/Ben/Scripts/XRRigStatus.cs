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
    private TeleportationArea sceneTeleportArea;
    [SerializeField]
    public CheckXRRigStatus xRRigStatus;

    public GameObject playerSpawnPoint;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Respawn");
        sceneTeleportArea = GameObject.FindObjectOfType<TeleportationArea>();
        xRRigStatus = GameObject.FindObjectOfType<CheckXRRigStatus>();
        Debug.Log("New Scene Loaded");
    }

    private void Start()
    {
        ActivateOrDeactiveteTeleportArea();
        player.transform.position = playerSpawnPoint.transform.position;
    }

    /// <summary>
    /// Method to enable or disable teleportation area in the scene.
    /// </summary>
    public void ActivateOrDeactiveteTeleportArea()
    {
        if (xRRigStatus.teleportMovementStatus)
        {
            sceneTeleportArea.enabled = true;
        }
        else if (!xRRigStatus.teleportMovementStatus)
        {
            sceneTeleportArea.enabled = false;
        }
    }
}
