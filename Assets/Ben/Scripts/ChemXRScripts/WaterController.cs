using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class WaterController : MonoBehaviour
{
    public Material waterWobble;
    public Renderer waterWobbleRenderer;
    //public XRKnob waterFlowXRKnob;

    public float waterLevel;

    public HeatExchangerController heatExchanger;

    private void Update()
    {
        WaterLevelChange(myValue);
        Debug.Log("Water Level: " + heatExchanger.waterFlowRate * 1f * Time.deltaTime);
        WaterLevelIncrease();
    }


    public void WaterLevelChange(float waterLevel)
    {
        waterWobble.SetFloat("_FillAmount", waterLevel);
        //Debug.Log(waterFlowXRKnob.value);
    }

    public float myValue;
    public float increaseRate; // Adjust this value to increase slower or faster
    public float maxIncrease;
    public float totalTime; // The total time in seconds to increase the value

    private float timeElapsed = 0f;

    public bool isWaterCollected;
    void WaterLevelIncrease()
    {
        if (myValue < maxIncrease && timeElapsed < totalTime)
        {
            myValue += increaseRate;
            timeElapsed += Time.deltaTime;
        }
        else
        {
            isWaterCollected = true;
        }
    }
}
