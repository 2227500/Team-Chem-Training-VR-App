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
