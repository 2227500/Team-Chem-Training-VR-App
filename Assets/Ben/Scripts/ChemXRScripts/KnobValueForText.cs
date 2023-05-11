
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
    public XRLever pumbSwitch1;
    public XRLever pumbSwitch2;
    public bool shouldOpenFully; // bool has to be true if the valve is supposed to open fully
    public bool shouldOpenPartially; // bool has to be true if the valve is supposed to open partially
    public Outline leverOutlineColor;

    public bool isDone;

    
    private void Start()
    {
        
        isDone = false;

        
    }

    public void NullBugFix()
    {
        if(pumbSwitch1 == null)
        {
            Debug.Log("Pump switch one");
        }
        if(pumbSwitch2 == null)
        {
            Debug.Log("Pump swaict one not assigned");
        }
        

        
    }
    /// <summary>
    /// Method to check the value of knob and convert it to the required ratio.
    /// </summary>
    public void KnobeValue()
    {
        //converting the value to the required decimals
        var value = 100f * knob.value;
        knobValueText.text = value.ToString("f2");
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

    public void LeverValuePump1()
    {
        if (pumbSwitch1.value)
        {
            isDone = true;
        }
        else
        {
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
        //call the method to update the knob value.
        KnobeValue();
        calculatedValues.OnFeedFlowRateChanged(knob.value.ToString());
        calculatedValues.UpdateValues();
    }

    public void FeedConcentartionChange()
    {
        KnobeValue();
        //taking the knob rotation value for calculation.
        calculatedValues.OnFeedConcentrationChanged(knob.value.ToString());
        calculatedValues.UpdateValues();
    }

    public void V1()
    {
        KnobeValue();
        //taking the knob rotation value for calculation.
        calculatedValues.OnFeedConcentrationChanged(knob.value.ToString());
        calculatedValues.UpdateValues();
    }
}
