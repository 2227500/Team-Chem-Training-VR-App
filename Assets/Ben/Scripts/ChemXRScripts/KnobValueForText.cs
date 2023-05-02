
// /*--------------------------------------------------------------------------------
// ----------------------------------------------------------------------------------
// Creation Date: #DateTime#
// Author: 2239356@swansea.ac.uk
// Description: ChemXR
// ----------------------------------------------------------------------------------
// --------------------------------------------------------------------------------*/


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

    public bool shouldOpenFully; // bool has to be true if the valve is supposed to open fully
    public bool shouldOpenPartially; // bool has to be true if the valve is supposed to open partially
    public Outline leverOutlineColor;

    public bool isDone;

    private void Start()
    {
        
        isDone = false;
    }


    /// <summary>
    /// Method to check the value of knob and convert it to the required ratio.
    /// </summary>
    public void KnobeValue()
    {
        var value = 100f * knob.value;
        knobValueText.text = value.ToString();
        if ((knob.value == 1 && shouldOpenFully) || (knob.value >= 0.45f && shouldOpenPartially))
        {
            leverOutlineColor.OutlineColor = Color.green; //once knob fully open or partially open the outline color changes to green.
            isDone = true;
        }
        else
        {
            leverOutlineColor.OutlineColor = Color.red; //if the knob is not fully open the outline color stays red.
            isDone = false;
        }
    }

    public void SteamValueChange()
    {
        KnobeValue();
        calculatedValues.OnSteamFlowRateChanged(knobValueText.text);
        calculatedValues.UpdateValues();
        Debug.Log(knobValueText.text);
    }

    public void FeedRateChange()
    {
        KnobeValue();
        calculatedValues.OnFeedFlowRateChanged(knob.value.ToString());
        calculatedValues.UpdateValues();
    }

    public void FeedConcentartionChange()
    {
        KnobeValue();
        calculatedValues.OnFeedConcentrationChanged(knob.value.ToString());
        calculatedValues.UpdateValues();
    }
}
