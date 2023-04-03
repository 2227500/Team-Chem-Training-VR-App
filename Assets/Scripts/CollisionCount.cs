using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCount : MonoBehaviour
{
    public FollowThePath follow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            follow.enabled = true;
        }
    }
}
