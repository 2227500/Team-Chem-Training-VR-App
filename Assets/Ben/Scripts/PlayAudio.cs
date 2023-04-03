using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSourceToPlay;
    [SerializeField]
    private int numberOfTimesCollided;

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Doctor"))
        {
            numberOfTimesCollided++;
        }
        if(numberOfTimesCollided >= 2 && other.CompareTag("Doctor"))
        {
            audioSourceToPlay.Play();
        }
    }
}
