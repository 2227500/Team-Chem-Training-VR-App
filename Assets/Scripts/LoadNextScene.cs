///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This script helps to load next scene with some effects.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{

    public GameObject player;
    public GameObject loadingBar;
    public Slider progressSlideBar;

    public Renderer screenRenderer;
    public float fadeDuration;
    public Color fadeColor;

    public bool fadeOnStart;
    private void Start()
    {
        //accessing the gameobject renderer
        screenRenderer = GetComponent<Renderer>();
        if (fadeOnStart)
            FadeIn();
    }
    /// <summary>
    /// Method to decrease the alpha value,
    /// </summary>
    public void FadeIn()
    {
        Fade(1, 0);
    }
    /// <summary>
    /// Method to increase the alpha value.
    /// </summary>
    public void FadeOut()
    {
        Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    /// <summary>
    /// Coroutine to change the alpha value of a material 
    /// </summary>
    /// <param name="alphaIn"></param>
    /// <param name="alphaOut"></param>
    /// <returns></returns>
    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor1 = fadeColor;
            newColor1.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            //accessing the color variable of the shader.
            screenRenderer.material.SetColor("_BaseColor", newColor1);
            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        screenRenderer.material.SetColor("_Color", newColor2);
    }


    public void LoadNextSceneSmoothly()
    {
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //StartCoroutine(LoadingSceneSmoothly());
    }

    public IEnumerator LoadingSceneSmoothly()
    {
        FadeOut();
        //Load new scene
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        sceneLoad.allowSceneActivation = false;

        float loadingTime = 0f;
        float loadedValue = 0f;
        while(loadingTime <= fadeDuration && !sceneLoad.isDone)
        {
            loadedValue = Mathf.MoveTowards(loadedValue, sceneLoad.progress, Time.deltaTime);
            progressSlideBar.value = loadedValue;

            loadingTime += Time.deltaTime;
            if(loadedValue >= 0.9f)
            {
                progressSlideBar.value = 1;
                sceneLoad.allowSceneActivation = true;
                FadeIn();
                loadingBar.SetActive(false);
            }
            yield return null;
        }       
    }
}
