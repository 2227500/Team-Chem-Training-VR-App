///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This script helps the user in managing the NPCs, controles player movement.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public GameObject doctorNPC;
    public GameObject doctorPassCheckpoint;

    public GameObject receptionistToStandUp;
    public GameObject initialPlayerRestrictedArea;
    public TeleportationArea playerInitialTeleportRestrictedArea;
    public Animator receptionistStandUp;
    
    public GameObject[] patientsArray;

    [SerializeField]
    private DoctorWalkingAround doctor;
    public ReceptionistandDoctorAnimationController receptionistandDocAnimatorController;

    public FollowThePath npcToFollowPlayer;

    public int nPCToMove;

    private void Start()
    {
        doctor = doctorNPC.GetComponent<DoctorWalkingAround>();
        receptionistStandUp = receptionistToStandUp.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Doctor")  //DoctorTargetArea
        {
            //nPCToMove++;
            NPCWalkingController();
        }
        //else if(other.tag == "Player")
        //{
        //    
        //    //npcToFollowPlayer.startFollowing = true;
        //}
    }

    /// <summary>
    /// Method helps to make the NPCs in the array to follow the doctor one by one
    /// </summary>
    public void NPCWalkingController()
    {
        if (doctor.canNPCFollow && nPCToMove <= patientsArray.Length)
        {
            //nPCToMove = doctor.numberOfNPCDone;
            nPCToMove++;
            patientsArray[nPCToMove - 1].GetComponent<FollowThePath>().startFollowing = true;
            Debug.Log("For Loop" + patientsArray[nPCToMove - 1].GetComponent<FollowThePath>().startFollowing);
            doctor.canNPCFollow = false;
            doctorPassCheckpoint.GetComponent<BoxCollider>().isTrigger = true;
        }

        if (doctor.isGoneBack)
        {
            doctorPassCheckpoint.GetComponent<BoxCollider>().isTrigger = false;
        }
    }


    private void Update()
    {
        ReceptionistWaveToLobby();
    }

    /// <summary>
    ///  Methods to control player movement.
    /// </summary>
    public void ReceptionistWaveToLobby()
    {
        if (doctor.isWaitingForUser)
        {
            receptionistStandUp.Play("Waving");
            receptionistandDocAnimatorController.playerDynamicMoveProvider.enabled = true; // enabling movement of player
            receptionistandDocAnimatorController.playerTeleportMoveProvider.enabled = true; // enable the teleportation functionality
            initialPlayerRestrictedArea.SetActive(false);
            playerInitialTeleportRestrictedArea.enabled = true; // restricts the player to move beyoud a line
        }
    }
}
