///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This script helps to lock the position of player. This script has to be attached to player to work.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;

public class FreezeTheUser : MonoBehaviour
{
    public DynamicMoveProvider moveProvider;
    public TeleportationProvider teleportProviderfinal;

    public int timesColliedeWithChair;

    private void Start()
    {
        moveProvider = gameObject.GetComponent<DynamicMoveProvider>();
        teleportProviderfinal = gameObject.GetComponent<TeleportationProvider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VacantChair")
        {
            timesColliedeWithChair++;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "FinalDestination")
        {
            StartCoroutine(ReachedFinalDestination());
            //moveProvider.enabled = false;
            //Debug.Log("Player reached final destination");
        }
    }

    private IEnumerator ReachedFinalDestination()
    {
        yield return new WaitForSeconds(2f);
        
        moveProvider.enabled = false;
        teleportProviderfinal.enabled = false;
        Debug.Log("Player reached final destination");
        
    }

    private void FinalDestinationReached()
    {
        moveProvider.enabled = false;
    }
}
