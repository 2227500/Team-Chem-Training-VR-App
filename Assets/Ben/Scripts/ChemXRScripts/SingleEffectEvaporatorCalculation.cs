using UnityEngine;
using UnityEngine.UI;

public class SingleEffectEvaporatorCalculation : MonoBehaviour
{
    public float feedFlowRate = 100.0f; // Feed flow rate in kg/hr
    public float feedConcentration = 0.05f; // Feed concentration in kg/kg
    public float steamFlowRate = 20.0f; // Steam flow rate in kg/hr
    public float evaporationRate = 0.05f; // Evaporation rate in kg/hr
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
    private void Update()
    {
        
    }

    public void OnFeedFlowRateChanged(string value)
    {
        float.TryParse(value, out feedFlowRate);
        UpdateValues();
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
    }

    public void OnEvaporationRateChanged(string value)
    {
        float.TryParse(value, out evaporationRate);
        UpdateValues();
    }

  
    private float _finalFeedMass;
    private float _temperature;

    public void OnTemperatureChanged(string value)
    {
        float.TryParse(value, out _temperature);
        UpdateValues();
    }

    private void UpdateValues()
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

        Debug.Log("Heat transfer rate: " + _heatTransferRate + " kW");

        // Update UI
        feedFlowRateText.text = "Feed flow rate: " + feedFlowRate.ToString("0.00") + " kg/hr";
        feedConcentrationText.text = "Feed concentration: " + (feedConcentration * 100.0f).ToString("0.00") + " %";
        steamFlowRateText.text = "Steam flow rate: " + steamFlowRate.ToString("0.00") + " kg/hr";
        evaporationRateText.text = "Evaporation rate: " + evaporationRate.ToString("0.00") + " kg/hr";
        heatTransferRateText.text = "Heat transfer rate: " + _heatTransferRate.ToString("0.00") + " kW";
    }
}
