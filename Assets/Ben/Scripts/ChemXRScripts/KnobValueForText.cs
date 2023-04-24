using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Content.Interaction;

public class KnobValueForText : MonoBehaviour
{
    public XRKnob knob;
    public Text knobValueText;
    public SingleEffectEvaporatorCalculation calculatedValues;

    public bool shouldOpenFully;
    public bool shouldOpenPartially;
    public Outline leverOutlineColor;

    private void Start()
    {
        calculatedValues = new SingleEffectEvaporatorCalculation();
    }

    private void Update()
    {
        //calculatedValues.UpdateValues();
    }
    public void KnobeValue()
    {
        var value = 100f * knob.value;
        knobValueText.text = value.ToString();
        if ((knob.value == 1 && shouldOpenFully) || (knob.value >= 0.45f && shouldOpenPartially))
        {
            leverOutlineColor.OutlineColor = Color.green;
        }
        else
        {
            leverOutlineColor.OutlineColor = Color.red;
        }
    }

    public void SteamValueChange()
    {
        calculatedValues.OnSteamFlowRateChanged(knobValueText.text);
        calculatedValues.UpdateValues();
    }

    public void FeedRateChange()
    {
        calculatedValues.OnSteamFlowRateChanged(knob.value.ToString());
        calculatedValues.UpdateValues();
    }
}
