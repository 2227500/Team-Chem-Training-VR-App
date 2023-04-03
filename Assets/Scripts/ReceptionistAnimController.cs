using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ReceptionistAnimController : MonoBehaviour
{
    public Animator anim;
    public BoxCollider npcCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        npcCollider = GetComponent<BoxCollider>();
        npcCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("Sitting Talking ");
        }

    }
}
