
// /*--------------------------------------------------------------------------------
// ----------------------------------------------------------------------------------
// Creation Date: #DateTime#
// Author: 2239356@swansea.ac.uk
// Description: ChemXR
// ----------------------------------------------------------------------------------
// --------------------------------------------------------------------------------*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIActivateAndFadeIn : MonoBehaviour
{
    public GameObject gameObjectToActivate;
    public GameObject gameObjectToDeactivate;
    public CanvasGroup canvasGroupToFadeIn;
    public CanvasGroup canvasGroupToFadeOut;
    public float fadeInDuration = 1f;
    public float fadeOutDuration = 1f;

    private void Start()
    {
        // Set the game object to inactive initially
        gameObjectToActivate.SetActive(false);

        // Start the coroutine to activate and fade in the canvas group
        //StartCoroutine(ActivateAndFadeInCoroutine());
    }

    public void ShowUI()
    {
        StartCoroutine(ActivateAndFadeInCoroutine());
        StartCoroutine(DeactivateAndFadeOutCoroutine());
    }

    private IEnumerator ActivateAndFadeInCoroutine()
    {
        // Wait for a short delay before starting the fade in animation
        //yield return new WaitForSeconds(0.5f);

        // Activate the game object
        gameObjectToActivate.SetActive(true);

        // Gradually increase the alpha value of the canvas group
        float time = 0f;
        while (time < fadeInDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, (time / fadeInDuration));
            canvasGroupToFadeIn.alpha = alpha;
            yield return null;
        }

        // Ensure the alpha value is exactly 1 at the end of the animation
        canvasGroupToFadeIn.alpha = 1f;
    }

    public IEnumerator DeactivateAndFadeOutCoroutine()
    {
        // Gradually decrease the alpha value of the canvas group to fade out
        float time = 0f;
        while (time < fadeOutDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, time / fadeOutDuration);
            canvasGroupToFadeOut.alpha = alpha;
            yield return null;
        }

        // Ensure the alpha value is exactly 0 at the end of the fade-out animation
        canvasGroupToFadeOut.alpha = 0f;
    }
}

