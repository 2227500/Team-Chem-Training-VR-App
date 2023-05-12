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
/// <summary>
/// Decreases the water level in a tank
/// </summary>
public class TK1WaterLevel : MonoBehaviour
{
    public Material waterWobble;
    public Renderer waterWobbleRenderer;
    //public XRKnob waterFlowXRKnob;
    public float waterLevel;
    public HeatExchangerController heatExchanger; 
    public float myValue = 0.64f;
    public float decreaseRate = 0.001f; // Adjust this value to decrease slower or faster
    public float minDecrease = 0.45f;
    public float totalTime = 180f; // The total time in seconds to decrease the value

    private float timeElapsed = 0f;
    public bool isTK1Empty;

    void Update()
    {

        WaterLevelChange(myValue);
        TestIncrement();
    }
    /// <summary>
    /// method to change the value of shader fill amount.
    /// </summary>
    /// <param name="waterLevel"></param>
    public void WaterLevelChange(float waterLevel)
    {
        waterWobble.SetFloat("_FillAmount", waterLevel);
        //Debug.Log(waterFlowXRKnob.value);
    }

    void TestIncrement()
    {
        if (myValue > minDecrease && timeElapsed < totalTime)
        {
            myValue -= decreaseRate;
            timeElapsed += Time.deltaTime;
        }
        else
        {
            isTK1Empty = true;
        }
        Debug.Log(myValue);
    }
}
