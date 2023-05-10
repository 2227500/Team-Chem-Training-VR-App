
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
    public float feedFlowRate; // Feed flow rate in kg/hr
    public float feedConcentration; // Feed concentration in kg/kg
    public float steamFlowRate; // Steam flow rate in kg/hr
    public float evaporationRate; // Evaporation rate in kg/hr
    public Text feedFlowRateText;
    public Text feedConcentrationText;
    public Text steamFlowRateText;
    public Text evaporationRateText;
    public Text heatTransferRateText;

    private float _initialFeedMass; // Initial mass of feed
    private float _initialFeedVolume; // Initial volume of feed
    private float _initialFeedDensity; // Initial density of feed
    private float _initialFeedSpecificHeat; // Initial specific heat of feed
    private float _initialFeedEnthalpy; // Initial enthalpy of feed
    private float _initialSteamEnthalpy; // Initial enthalpy of steam
    private float _finalFeedVolume; // Final volume of feed
    private float _finalFeedDensity; // Final density of feed
    private float _finalFeedSpecificHeat; // Final specific heat of feed
    private float _finalFeedEnthalpy; // Final enthalpy of feed
    private float _finalEvaporatedMass; // Final mass of evaporated water
    private float _finalEvaporatedEnthalpy; // Final enthalpy of evaporated water
    private float _heatTransferRate; // Heat transfer rate in kW

  
    void Start()
    {
        UpdateValues();
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

        //Debug.Log("Heat transfer rate: " + _heatTransferRate + " kW");
        //Debug.Log("Final Evaporated Enthalpy: " + _finalEvaporatedEnthalpy);
        //Debug.Log("Final Evaporated Mass: " + _finalEvaporatedMass);
        //Debug.Log("Final Feed Density: " + _finalFeedDensity);
        //Debug.Log("Final Feed Enthalpy: " + _finalFeedEnthalpy);
        //Debug.Log("Final Feed Mass: " + _finalFeedMass);
        //Debug.Log("Final Feed Specific Heat: " + _finalFeedSpecificHeat);
        //Debug.Log("Final Feed Volume: " + _finalFeedVolume);

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
