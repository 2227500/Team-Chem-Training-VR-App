using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandBehindPlayer : MonoBehaviour
{
    [SerializeField]
    private FollowThePath followScript;

    private void Start()
    {
        followScript = gameObject.GetComponent<FollowThePath>();
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Final Destination"))
    //    {
    //        followScript.enabled = false;
    //    }
    //}
}
