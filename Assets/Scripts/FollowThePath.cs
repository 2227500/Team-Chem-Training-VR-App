///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This script helps the NPC to follow the gameobject attached with DoctorWalkingAround script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowThePath : MonoBehaviour
{
    public Transform[] points;

    private int destPoint = 0;

    private NavMeshAgent agent;

    public Animator nPCAnimator;
    public AnimationClip[] nPCAnimationClip;

    public bool startFollowing;

    private void Awake()
    {
        //this.enabled = false;

    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
        nPCAnimator = gameObject.GetComponent<Animator>();
        GotoNextPoint();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Doctor")
        {
            //EnableScript();
        }
        else if(other.tag == "NPCDestroyer")
        {
            DestroyTheNPC();
        }
    }
    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
        transform.LookAt(points[destPoint]);
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1 )% points.Length;
    }
    


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        //if (!agent.pathPending && agent.remainingDistance < 0.5f)
        //GotoNextPoint();
        StartWalking();
    }

    public void EnableScript()
    {
        this.enabled = true;
    }

    public void StartWalking()
    {
        if (startFollowing)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
            
            nPCAnimator.Play("Walk");
        }
    }

    /// <summary>
    /// Destroy the game object attached with this script
    /// </summary>
    public void DestroyTheNPC()
    {
            Destroy(this.gameObject);
            //Debug.Log(destPoint.ToString());  
    }
}
