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

    public void TestPrefName()
    {
        SetString("Name", tableStudent.ToString());
    }
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
