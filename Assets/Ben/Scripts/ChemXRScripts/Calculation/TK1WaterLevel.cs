using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK1WaterLevel : MonoBehaviour
{
    public Material waterWobble;
    public Renderer waterWobbleRenderer;
    //public XRKnob waterFlowXRKnob;

    public float waterLevel;

    public HeatExchangerController heatExchanger;

    void Update()
    {
        //float decrementAmount = 0.01f * Time.deltaTime;
        //if (waterLevel - decrementAmount <= 0.49)
        //{
        //    waterLevel -= decrementAmount;
        //    WaterLevelChange(waterLevel -= 0.01f);
        //}
        //Debug.Log("Water Level: " + heatExchanger.waterFlowRate * 1f * Time.deltaTime);
        WaterLevelChange(myValue);
        TestIncrement();
    }


    public void WaterLevelChange(float waterLevel)
    {
        waterWobble.SetFloat("_FillAmount", waterLevel);
        //Debug.Log(waterFlowXRKnob.value);
    }

    public float myValue = 0.64f;
    public float decreaseRate = 0.001f; // Adjust this value to decrease slower or faster
    public float minDecrease = 0.45f;
    public float totalTime = 180f; // The total time in seconds to decrease the value

    private float timeElapsed = 0f;

    void TestIncrement()
    {
        if (myValue > minDecrease && timeElapsed < totalTime)
        {
            myValue -= decreaseRate;
            timeElapsed += Time.deltaTime;
        }
        Debug.Log(myValue);
    }
}
