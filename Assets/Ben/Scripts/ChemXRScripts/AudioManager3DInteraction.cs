// /*--------------------------------------------------------------------------------
// ----------------------------------------------------------------------------------
// Creation Date: 12/05/23
// Author: 2239356@swansea.ac.uk
// Description: ChemXR
// ----------------------------------------------------------------------------------
// --------------------------------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Script controls audio.
/// </summary>
public class AudioManager3DInteraction : MonoBehaviour
{
    public AudioClip[] instructionAudios;
    public AudioSource[] instructionAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            instructionAudioSource[0].clip = instructionAudios[0];
            instructionAudioSource[0].Play();
            instructionAudioSource[1].Stop();
            //instructionAudioSource[2].Stop();
            //instructionAudioSource[3].Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            instructionAudioSource[0].Stop();
            instructionAudioSource[1].Stop();
            instructionAudioSource[2].Stop();
            
        }
    }
}
