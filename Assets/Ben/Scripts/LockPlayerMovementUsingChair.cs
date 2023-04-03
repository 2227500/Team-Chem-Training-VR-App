///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This scripts helps to lock the player movement once the collided with the gameobject with tis script.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LockPlayerMovementUsingChair : MonoBehaviour
{
    [SerializeField]
    private TeleportationArea hospitalTeleportArea;

    [SerializeField]
    private FreezeTheUser userMovementFreezeScript;

    [SerializeField]
    public int numberOfTimesPlayerCollided;

    private void Awake()
    {
        userMovementFreezeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<FreezeTheUser>();
    }
    private void Start()
    {
        hospitalTeleportArea = GameObject.FindGameObjectWithTag("TeleportArea").GetComponent<TeleportationArea>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(userMovementFreezeScript.timesColliedeWithChair == 2)
        {
            hospitalTeleportArea.enabled = false;
            userMovementFreezeScript.moveProvider.enabled = false;
        }
    }
}
