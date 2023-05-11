using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnTriggerEnter : MonoBehaviour
{
    public AudioSource source;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            source.Play();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            source.Stop();
        }
    }
}
