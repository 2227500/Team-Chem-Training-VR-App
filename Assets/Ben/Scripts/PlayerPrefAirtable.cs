// /*--------------------------------------------------------------------------------
// ----------------------------------------------------------------------------------
// Creation Date: 12/05/2023
// Author: 2239356@swansea.ac.uk
// Description: ChemXR
// ----------------------------------------------------------------------------------
// ----
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefAirtable : MonoBehaviour
{
    public AirTableStudent tableStudent;
    public AirTableTime tableTime;


    public void ChemXRPref()
    {
        TestPrefName();
        TestPrefPlayTime();
    }

    /// <summary>
    /// Stores the user name
    /// </summary>
    public void TestPrefName()
    {
        SetString("Name", tableStudent.ToString());
    }
    /// <summary>
    /// Stores the time took for the player to complete
    /// </summary>
    public void TestPrefPlayTime()
    {
        SetFloat("TimeTook", tableTime.timeValue);
    }



    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }
}
