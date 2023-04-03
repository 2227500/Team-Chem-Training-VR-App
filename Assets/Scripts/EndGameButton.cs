///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This script is used to quit the application.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButton : MonoBehaviour
{
    public void EndGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
        Application.Quit();
    }

}
