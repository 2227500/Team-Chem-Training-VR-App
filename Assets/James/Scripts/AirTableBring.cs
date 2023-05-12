using System;
using System.Collections.Generic;
using UnityEngine;
using VRKeys;
public class AirTableBring : MonoBehaviour
{
    public Keyboard keyboard;

    public string studentNumber;

    public void Update()
    {
        studentNumber = keyboard.text;
    }

}
