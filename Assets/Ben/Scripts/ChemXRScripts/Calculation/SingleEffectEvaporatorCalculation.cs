
// /*--------------------------------------------------------------------------------
// ----------------------------------------------------------------------------------
// Creation Date: #DateTime#
// Author: 2239356@swansea.ac.uk
// Description: ChemXR
// ----------------------------------------------------------------------------------
// --------------------------------------------------------------------------------*/


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Content.Interaction;

public class SingleEffectEvaporatorCalculation : MonoBehaviour
{
    public float feedFlowRate; 
    public float feedConcentration; 
    public float steamFlowRate; 
    public float evaporationRate; 
    public Text feedFlowRateText;
    public Text feedConcentrationText;
    public Text steamFlowRateText;
    public Text evaporationRateText;
    public Text heatTransferRateText;

    private float _initialFeedMass; 
    private float _initialFeedVolume; 
    private float _initialFeedDensity; 
    private float _initialFeedSpecificHeat; 
    private float _initialFeedEnthalpy; 
    private float _initialSteamEnthalpy; 
    private float _finalFeedVolume; 
    private float _finalFeedDensity; 
    private float _finalFeedSpecificHeat; 
    private float _finalFeedEnthalpy; 
    private float _finalEvaporatedMass; 
    private float _finalEvaporatedEnthalpy; 
    private float _heatTransferRate; 

  
    void Start()
    {
        //UpdateValues();
    }


    public void OnFeedFlowRateChanged(string value)
    {
        float.TryParse(value, out feedFlowRate);
        UpdateValues();
        //Debug.Log("Flow rate: " + feedFlowRate);
    }

    public void OnFeedConcentrationChanged(string value)
    {
        float.TryParse(value, out feedConcentration);
        UpdateValues();
    }

    public void OnSteamFlowRateChanged(string value)
    {
        float.TryParse(value, out steamFlowRate);
        UpdateValues();
        Debug.Log("Steam FLow rate: " + steamFlowRate);
        
    }

    public void OnEvaporationRateChanged(string value)
    {
        float.TryParse(value, out evaporationRate);
        UpdateValues();
        //Debug.Log(evaporationRate);
    }

  
    private float _finalFeedMass;
    private float _temperature;

    public void OnTemperatureChanged(string value)
    {
        float.TryParse(value, out _temperature);
        UpdateValues();
    }

    public void UpdateValues()
    {
        // Calculate initial properties of feed
        _initialFeedMass = feedFlowRate;
        _initialFeedVolume = _initialFeedMass / feedConcentration;
        _initialFeedDensity = 1000.0f; // Assume density of water
        _initialFeedSpecificHeat = 4.18f; // Assume specific heat of water
        _initialFeedEnthalpy = _initialFeedMass * _initialFeedSpecificHeat * 298.15f; // Assume initial temperature of feed is 25°C
        _initialSteamEnthalpy = 2676.0f; // Enthalpy of saturated steam at 100°C
        _temperature = 0.0f;

        // Calculate final properties of feed and evaporated water
        _finalFeedVolume = _initialFeedVolume - evaporationRate;
        _finalFeedDensity = _initialFeedMass / _finalFeedVolume;
        _finalFeedSpecificHeat = 4.18f; // Assume specific heat of water
        _finalFeedMass = _finalFeedVolume * _initialFeedDensity;
        _finalFeedEnthalpy = _finalFeedMass * _finalFeedSpecificHeat * 363.15f; // Assume final temperature of feed is 90°C
        _finalEvaporatedMass = evaporationRate;
        _finalEvaporatedEnthalpy = _finalEvaporatedMass * _initialSteamEnthalpy; ;

        // Calculate heat transfer rate
        _heatTransferRate = _finalFeedEnthalpy - _initialFeedEnthalpy - _finalEvaporatedEnthalpy;

        
        // Update UI
        feedFlowRateText.text = feedFlowRate.ToString("0.00") + " kg/hr";
        feedConcentrationText.text = (feedConcentration * 100.0f).ToString("0.00") + " %";
        steamFlowRateText.text = steamFlowRate.ToString("0.00"); // + " kg/hr";
        evaporationRateText.text =  evaporationRate.ToString("0.00") + " kg/hr";
        heatTransferRateText.text =  _heatTransferRate.ToString("0.00") + " kW";
    }

    private void Update()
    {
        //UpdateValues();
    }
}
