///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This scripts helps the NPC to walk around through the target points and to check the boolean values for other NPCs to follow this gameobject.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoctorWalkingAround : MonoBehaviour
{
    public Transform[] points;
    public Transform wayback;
    public GameObject followDoctorCheckpoint;
    public GameObject duplicateDoc;
    
    private NavMeshAgent agent;

    public Animator doctorAnimator;
    public AnimationClip[] doctorAnimationClip;
    public AnimationClip doctorAnimationClipLength;
    public Animation doctorAnimation;
    //public Animation nPCAnimation;

    private int destPoint = 0;
    public int numberOfNPCDone;
    public int timerValue;
    public int doctorWaitingTime;
    public float doctorWalkingRepeatTime;
    public float receptionWaitingTime;

    public bool isGoneBack;
    public bool isAtReceptionArea;
    public bool canNPCFollow;
    public bool isWaitingForUser;

    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
        isAtReceptionArea = false;
        canNPCFollow = false;

        followDoctorCheckpoint.SetActive(false);

        doctorAnimation = gameObject.GetComponent<Animation>();
        
        // invoke the doctors to and fro movement
        InvokeRepeating("WalkAround", 6f, doctorWalkingRepeatTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ReceptionAreaForDoc")
        {
            isAtReceptionArea = true;
            isGoneBack = false;
            canNPCFollow = false;

            numberOfNPCDone++;
            
            doctorAnimator.Play("Talking");

            followDoctorCheckpoint.SetActive(true);         
        }
        else if (other.tag == "DoctorDesk")
        {
            isGoneBack = true;
            isAtReceptionArea = false;
            canNPCFollow = false;
            followDoctorCheckpoint.SetActive(false);
        }
        else if (other.tag == "FollowDoctor")   //"NPCStarter"
        {
            canNPCFollow = true;
            isGoneBack = false;
            isAtReceptionArea = false;
        }
        else if (other.tag == "NPCStarter")  
        {
            isGoneBack = false;
            isAtReceptionArea = false;
        }
        else if (other.tag == "ReceptionAreaForDoc" && numberOfNPCDone == 3)
        {
            isAtReceptionArea = true;
            isGoneBack = false;
            numberOfNPCDone++;

            if (timerValue < doctorWaitingTime)
            {
                doctorAnimator.Play("Idle");
            }
            else
            {
                WalkAround();
            }

            followDoctorCheckpoint.SetActive(true);            
        }
        else if(isGoneBack && numberOfNPCDone == 4)
        {
            CancelInvoke("WalkAround");
            isWaitingForUser = true;
            duplicateDoc.SetActive(true);

            Destroy(gameObject);
        }
    }
    
    public void WalkAround()
    {
        StartCoroutine(WalkBetweenPoints());
    }

    /// <summary>
    /// Ienumerator that helps the NPC to walk between two points 
    /// </summary>
    /// <returns></returns>
    public IEnumerator WalkBetweenPoints()
    {
        agent.destination = points[5].position;
        yield return new WaitForSeconds(5);
        if (isAtReceptionArea)
        {
            yield return new WaitForSeconds(receptionWaitingTime);

            doctorAnimation.clip = doctorAnimationClip[6];
            doctorAnimation.Play();
            yield return new WaitForSeconds(1f);

            doctorAnimator.Play("Walking");
            agent.destination = wayback.position;

            isAtReceptionArea = false;
            //isGoneBack = true;
        }
        yield return new WaitForSeconds(1);

    }

}
