///Copywrite @ '2239356@swansea university'
///Date:05/03/2023
///Author: Benadict Joseph
///This script helps to freeze the movement of the gameobject attached with this script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;

public class LockPlayerPosition : MonoBehaviour
{

    public GameObject gameObjectToLock;
    [SerializeField]
    private Rigidbody lockingObjectRigidBody;
    [SerializeField]
    private DynamicMoveProvider xROriginDynamicMoveProvider;
    [SerializeField]
    private TeleportationProvider xROriginTeleportMoveProvider;
    public TeleportationArea teleportAreaHospital;
    [SerializeField]
    private int numberOfTimes;
    private int nPCToGo;

    public AudioSource audio;
    //public bool isLocked;

    private void Awake()
    {
        gameObjectToLock = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {     
        lockingObjectRigidBody = gameObjectToLock.GetComponent<Rigidbody>();
        //xROriginDynamicMoveProvider = GameObject.FindGameObjectWithTag("Player").GetComponent<DynamicMoveProvider>();        
        xROriginDynamicMoveProvider = gameObjectToLock.GetComponent<DynamicMoveProvider>();
        xROriginTeleportMoveProvider = gameObjectToLock.GetComponent<TeleportationProvider>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            numberOfTimes++;
            //xROriginDynamicMoveProvider = gameObjectToLock.GetComponent<DynamicMoveProvider>();
        }

        if (numberOfTimes == 2 && other.CompareTag("Player")) // && nPCToGo < 4)
        {
            xROriginDynamicMoveProvider.enabled = false;
            xROriginTeleportMoveProvider.enabled = false;
            teleportAreaHospital.enabled = false;
            Debug.Log("Player is freezed"); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audio.enabled = false;
        }
    }
    

    private IEnumerator LockPosition()
    {
        xROriginDynamicMoveProvider.enabled = false;
        yield return new WaitForSeconds(500f);
        xROriginDynamicMoveProvider.enabled = true;
    }

}
