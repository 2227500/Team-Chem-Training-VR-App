using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class WaterController : MonoBehaviour
{
    public Material waterWobble;
    public Renderer waterWobbleRenderer;
    public XRKnob waterFlowXRKnob;

    public float waterLevel;


    private void Update()
    {
        WaterLevelChange(waterFlowXRKnob.value);
    }


    public void WaterLevelChange(float waterLevel)
    {
        waterWobble.SetFloat("_FillAmount", waterLevel);
        Debug.Log(waterFlowXRKnob.value);
    }
}
