using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ConcentratedLiquidrController : MonoBehaviour
{
    public Material waterWobble;
    public Renderer waterWobbleRenderer;
    //public XRKnob waterFlowXRKnob;

    public float waterLevel;

    public HeatExchangerController heatExchanger;

    private void Update()
    {
        ConcLiquidLevelChange(initValue);
        Debug.Log("Con Liquid: " + heatExchanger.concLiquidFlowRate + 0.01f * Time.deltaTime + 0.45);
        ConcLevelIncrease();
    }


    public void ConcLiquidLevelChange(float waterLevel)
    {

        waterWobble.SetFloat("_FillAmount", waterLevel);
        //Debug.Log(waterFlowXRKnob.value);
    }

    public float initValue = 0f;
    public float increaseRate = 0.01f; // Adjust this value to increase slower or faster
    public float maxIncrease = 1f;
    public float totalTime = 10f; // The total time in seconds to increase the value

    private float timeElapsed = 0f;

    void ConcLevelIncrease()
    {
        if (initValue < maxIncrease && timeElapsed < totalTime)
        {
            initValue += increaseRate;
            timeElapsed += Time.deltaTime;
        }
    }
}
