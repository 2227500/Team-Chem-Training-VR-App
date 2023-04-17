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
    }


    public void KnobeValue()
    {
        knobValueText.text = knob.value.ToString();
        calculatedValues.OnFeedFlowRateChanged(knobValueText.text);
    }
}
