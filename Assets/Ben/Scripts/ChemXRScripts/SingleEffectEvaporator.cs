using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleEffectEvaporator : MonoBehaviour
{
    public float feedFlowRate; // Feed flow rate in kg/hr
    public float feedConcentration; // Feed concentration in kg/kg
    public float steamFlowRate; // Steam flow rate in kg/hr
    public float evaporationRate; // Evaporation rate in kg/hr

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
    private float _finalFeedMass;

    

    void Start()
    {
        // Calculate initial properties of feed
        _initialFeedMass = feedFlowRate;
        _initialFeedVolume = _initialFeedMass / feedConcentration;
        _initialFeedDensity = 1000.0f; // Assume density of water
        _initialFeedSpecificHeat = 4.18f; // Assume specific heat of water
        _initialFeedEnthalpy = _initialFeedMass * _initialFeedSpecificHeat * 298.15f; // Assume initial temperature of feed is 25°C
        _initialSteamEnthalpy = 2676.0f; // Enthalpy of saturated steam at 100°C

        // Calculate final properties of feed and evaporated water
        _finalFeedVolume = _initialFeedVolume - evaporationRate;
        _finalFeedDensity = _initialFeedMass / _finalFeedVolume;
        _finalFeedSpecificHeat = 4.18f; // Assume specific heat of water
        _finalFeedEnthalpy = _finalFeedMass * _finalFeedSpecificHeat * 363.15f; // Assume final temperature of feed is 90°C
        _finalEvaporatedMass = evaporationRate;
        _finalEvaporatedEnthalpy = _finalEvaporatedMass * _initialSteamEnthalpy;

        // Calculate heat transfer rate
        _heatTransferRate = _finalFeedEnthalpy - _initialFeedEnthalpy - _finalEvaporatedEnthalpy;

        Debug.Log("Heat transfer rate: " + _heatTransferRate + " kW");
    }

    private void Update()
    {
        
    }
}
