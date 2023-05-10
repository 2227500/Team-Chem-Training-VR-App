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
        ConcLiquidLevelChange(heatExchanger.concLiquidFlowRate);
    }


    public void ConcLiquidLevelChange(float waterLevel)
    {
        waterWobble.SetFloat("_FillAmount", waterLevel);
        //Debug.Log(waterFlowXRKnob.value);
    }
}
