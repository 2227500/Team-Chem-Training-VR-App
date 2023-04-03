///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This script helps to play the audio while colliding with other gameobjects.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundTriggerScript : MonoBehaviour
{
    public int delayAudioPlay;
    public int timesPlayerEnetered;
    public int timesPlayerEneteredSeat;

    public AudioSource audiosource;
    public AudioClip[] audioClip;

    public bool isOneShotAudioPlay;

    private void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !audiosource.isPlaying && !isOneShotAudioPlay)
        {
            StartCoroutine(playAudioInstruction());
        }
        else if(other.tag == "Player" && this.gameObject.tag == "ReceptionArea" && !isOneShotAudioPlay)
        {
            // For the collider at reception area
            timesPlayerEnetered++;
            StartCoroutine(playAudioInstructionAndDisable());    
        }
        else if(other.tag == "Player" && !audiosource.isPlaying && isOneShotAudioPlay)
        {
            timesPlayerEneteredSeat++;
            StartCoroutine(PlayAudioOneTime(0));
            
            Debug.Log(timesPlayerEneteredSeat);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !audiosource.isPlaying && !isOneShotAudioPlay)
        {
            audiosource.Stop();
        }
        else if (other.tag == "Player" && this.gameObject.tag == "ReceptionArea" && !isOneShotAudioPlay)
        {
            audiosource.Stop();

        }
        else if (other.tag == "Player" && !audiosource.isPlaying && isOneShotAudioPlay)
        {
            audiosource.Stop();
        }
        else if (other.tag == "Player" && isOneShotAudioPlay)
        {
            audiosource.Stop();
        }
    }


    // Normal audio play
    IEnumerator playAudioInstruction()
    {
        yield return new WaitForSeconds(1);
        audiosource.PlayOneShot(audioClip[0]);
    }

    /// <summary>
    /// Trigger audio after certain times
    /// </summary>
    /// <returns></returns>
    IEnumerator playAudioInstructionAndDisable()
    {
        yield return new WaitForSeconds(delayAudioPlay);
        // For the collider at reception area
        if (timesPlayerEnetered == 2)
        {
            audiosource.PlayOneShot(audioClip[0]);
        }
    }
    /// <summary>
    /// Plays only one audio at a time
    /// </summary>
    /// <param name="audioNumber"></param>
    /// <returns></returns>
    IEnumerator PlayAudioOneTime(int audioNumber)
    {
        audiosource.PlayOneShot(audioClip[audioNumber]);
        yield return new WaitForSeconds(audioClip[audioNumber].length);
        audiosource.enabled = false;

    }

  
}
