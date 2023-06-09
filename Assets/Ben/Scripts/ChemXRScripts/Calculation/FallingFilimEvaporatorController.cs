//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.XR.Content.Interaction;

//public class FallingFilimEvaporatorController : MonoBehaviour
//{
//    public XRKnob heatTransferCoefficientKnob;
//    public XRKnob temperatureDifferenceKnob;

//    public float temperaturePrecision = 0.1f; // Example value for temperature measurement precision
//    public float flowratePrecision = 0.05f; // Example value for flowrate measurement precision
//    public float pressurePrecision = 0.01f; // Example value for pressure measurement precision

//    private float heatTransferCoefficient;
//    private float temperatureDifference;

//    private float overallHeatTransferCoefficient;
//    private float heatTransferRate;
//    private float heatTransferArea;

//    private float steadyStateTime;
//    private bool isSteadyStateReached = false;
//    private List<float> temperatureData;

//    private List<float> varyingParameterData;
//    private List<float> overallHeatTransferCoefficientData;
//    private List<float> steamEconomyData;

//    private Coroutine steadyStateCoroutine;

//    private void Start()
//    {
//        temperatureData = new List<float>();
//        varyingParameterData = new List<float>();
//        overallHeatTransferCoefficientData = new List<float>();
//        steamEconomyData = new List<float>();

//        // Initialize initial values
//        heatTransferCoefficient = heatTransferCoefficientKnob.value;
//        temperatureDifference = temperatureDifferenceKnob.value;

//        // Start coroutine to monitor steady state
//        steadyStateCoroutine = StartCoroutine(MonitorSteadyState());
//    }

//    private void Update()
//    {
//        // Check if the knob values have changed
//        if (heatTransferCoefficient != heatTransferCoefficientKnob.value ||
//            temperatureDifference != temperatureDifferenceKnob.value)
//        {
//            // Update the knob values
//            heatTransferCoefficient = heatTransferCoefficientKnob.value;
//            temperatureDifference = temperatureDifferenceKnob.value;

//            // Calculate new values
//            CalculateValues();
//        }
//    }

//    private IEnumerator MonitorSteadyState()
//    {
//        while (true)
//        {
//            float currentTemperature = ReadTemperature(); // Example method to read the current temperature

//            if (!isSteadyStateReached && IsSteadyState(currentTemperature))
//            {
//                isSteadyStateReached = true;
//                steadyStateTime = Time.time;
//                CollectSteadyStateData();
//            }

//            if (isSteadyStateReached)
//            {
//                CollectSteadyStateData();
//            }

//            yield return null;
//        }
//    }

//    private bool IsSteadyState(float currentTemperature)
//    {
//        // Compare current temperature with previous temperature data
//        for (int i = 0; i < temperatureData.Count; i++)
//        {
//            if (Mathf.Abs(currentTemperature - temperatureData[i]) > temperaturePrecision)
//            {
//                return false;
//            }
//        }

//        return true;
//    }

//    private void CollectSteadyStateData()
//    {
//        float currentTemperature = ReadTemperature(); // Example method to read the current temperature

//        temperatureData.Add(currentTemperature);
//        varyingParameterData.Add(heatTransferCoefficient); // Update with the appropriate varying parameter

//        // Perform calculations for overall heat transfer coefficient (U) and steam economy
//        CalculateOverallHeatTransferCoefficient();
//        CalculateSteamEconomy();

//        // Update visual representation or store data as needed
//        UpdateVisuals();
//    }

//    private void CalculateValues()
//    {
//        // Step 1: Calculate the overall heat transfer coefficient (U)
//        overallHeatTransferCoefficient = heatTransferCoefficient;
//        overallHeatTransferCoefficient = heatTransferCoefficient * 100f; // Scale the knob value as needed

//        // Step 2: Calculate the heat transfer rate (Q)
//        float heatTransferRateMultiplier = 1000f; // Adjust this value based on your scaling needs
//        heatTransferRate = overallHeatTransferCoefficient * heatTransferRateMultiplier;

//        // Step 3: Calculate the heat transfer area (A)
//        float heatTransferAreaMultiplier = 0.1f; // Adjust this value based on your scaling needs
//        heatTransferArea = heatTransferRate / (overallHeatTransferCoefficient * temperatureDifference * heatTransferAreaMultiplier);

//        // Update the visual representation or use the calculated values as needed
//        UpdateVisuals();

//        // Collect data for overall heat transfer coefficient (U) and steam economy
//        CollectOverallHeatTransferCoefficientData();
//        CollectSteamEconomyData();
//    }

//    private void CalculateOverallHeatTransferCoefficient()
//    {
//        // Perform mass and energy balances to determine the overall heat transfer coefficient (U) at each operating condition
//        // You can implement your specific calculations here based on the experiment setup and conditions
//        float U = ...; // Perform calculations based on mass and energy balances
//        overallHeatTransferCoefficientData.Add(U);
//    }

//    private void CollectOverallHeatTransferCoefficientData()
//    {
//        // Collect data for overall heat transfer coefficient (U) based on the varying parameter
//        // You can store or visualize the data as needed
//        // Use the varyingParameterData list and overallHeatTransferCoefficientData list
//    }

//    private void CalculateSteamEconomy()
//    {
//        // Perform calculations to determine the steam economy at different conditions
//        // You can implement your specific calculations here based on the experiment setup and conditions
//        float steamEconomy = ...; // Perform calculations based on water vaporized per kilogram of steam fed
//        steamEconomyData.Add(steamEconomy);
//    }

//    private void CollectSteamEconomyData()
//    {
//        // Collect data for steam economy based on the varying parameter
//        // You can store or visualize the data as needed
//        // Use the varyingParameterData list and steamEconomyData list
//    }

//    private float ReadTemperature()
//    {
//        // Example method to read the temperature from the temperature indicator or sensor
//        // Replace this with your own implementation based on your hardware or simulation setup
//        float temperature = 0f;
//        return temperature;
//    }

//    private void UpdateVisuals()
//    {
//        // Update the visual representation of the falling film evaporator with the calculated values
//        // For example, you can update the scale or position of objects to represent the heat transfer area, or change the color based on the heat transfer rate.
//    }
//}