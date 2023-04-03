using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TriggerAnimation : MonoBehaviour
{
    public Animator npcAnimator;
    public BoxCollider npcCollider;
    // Start is called before the first frame update
    void Start()
    {
        npcAnimator = gameObject.GetComponent<Animator>();
        npcCollider = gameObject.GetComponent<BoxCollider>();
        npcCollider.isTrigger = true;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcAnimator.Play("Sit To Stand");

        }
    }
}
