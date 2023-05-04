using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using TMPro;

public class HeatExchangerController : MonoBehaviour
{
    public float steamFlowRate = 0.0f; // initial steam flow rate
    public float waterFlowRate = 0.0f; // initial water flow rate
    public float steamTemperature = 0.0f; // initial steam temperature
    public float waterTemperatureInE1 = 0.0f; // initial water temperature at the inlet of E1
    public float waterTemperatureOutE1 = 0.0f; // initial water temperature at the outlet of E1
    public float waterTemperatureOutE2 = 0.0f; // initial water temperature at the outlet of E2

    private float heatTransferCoefficientE1 = 0.0f; // heat transfer coefficient for E1
    private float heatTransferCoefficientE2 = 0.0f; // heat transfer coefficient for E2
    private float densityWater = 1000.0f; // density of water in kg/m^3
    private float specificHeatWater = 4180.0f; // specific heat of water in J/(kg*K)

    public TextMeshPro tI1Value;
    public TextMeshPro tI2Value;
    public TextMeshPro tI3Value;
    public TextMeshPro tI4Value;
    public TextMeshPro tI5Value;
    public TextMeshPro tI6Value;
    //public TextMeshPro steamTemperatureValue;

    public XRKnob steamKnobValue;

    void Start()
    {
        // Initialize the heat transfer coefficients for E1 and E2 based on the
        // specific design and geometry of the heat exchangers.
        heatTransferCoefficientE1 = CalculateHeatTransferCoefficientE1();
        heatTransferCoefficientE2 = CalculateHeatTransferCoefficientE2();
    }

    void Update()
    {
        // Calculate the temperature values for each heat exchanger and display them
        // in the VR UI.
        CalculateWaterTemperatureOutE1();
        CalculateWaterTemperatureOutE2();
        DisplayTemperatures();

        // Control the steam flow rate using the input device.
        ControlSteamFlowRate();
    }

    void CalculateWaterTemperatureOutE1()
    {

        // Calculate the temperature of the water at the outlet of E1 based on the steam temperature,
        // water flow rate, heat transfer coefficient of E1, and physical properties of water such as density
        // and specific heat.
        
        float deltaT = steamTemperature - waterTemperatureInE1; // temperature difference between steam and water
        float q = waterFlowRate * densityWater * specificHeatWater * deltaT; // heat transferred from steam to water
        float uA = heatTransferCoefficientE1 * CalculateSurfaceAreaE1(); // overall heat transfer coefficient times surface area of E1
        float deltaTLogMean = CalculateLogMeanTemperatureDifferenceE1(deltaT); // log mean temperature difference for E1
        waterTemperatureOutE1 = waterTemperatureInE1 + q / (uA * deltaTLogMean); // calculate water temperature at the outlet of E1
        tI2Value.text = waterTemperatureOutE1.ToString();
    }

    void CalculateWaterTemperatureOutE2()
    {
        // Calculate the temperature of the water at the outlet of E2 based on the water
        // flow rate, heat transfer coefficient of E2, and physical properties of water.
        float deltaT = waterTemperatureOutE1 - waterTemperatureOutE2; // temperature difference between water at E1 and E2
        float q = waterFlowRate * densityWater * specificHeatWater * deltaT; // heat transferred from E1 to E2
        float uA = heatTransferCoefficientE2 * CalculateSurfaceAreaE2(); // overall heat transfer coefficient times surface area of E2
        float deltaTLogMean = CalculateLogMeanTemperatureDifferenceE2(deltaT); // log mean temperature difference for E2
        waterTemperatureOutE2 = waterTemperatureOutE2 + q / (uA * deltaTLogMean); // calculate water temperature at the outlet of E2
    }

    void DisplayTemperatures()
    {
        // Display the temperature values for each heat exchanger in the VR UI.
        // These values should be updated every frame in the Update() function.
        Debug.Log("Steam temperature: " + steamTemperature);
        Debug.Log("Water temperature in E1: " + waterTemperatureInE1);
        Debug.Log("Water temperature out E1: " + waterTemperatureOutE1);
        Debug.Log("Water temperature out E2: " + waterTemperatureOutE2);
    }

    void ControlSteamFlowRate()
    {
        // Control the steam flow rate using the input device.
        // This could involve using a valve in the 3D environment, or some other user interface element.
        steamFlowRate = steamKnobValue.value * 100f;  // get the steam flow rate from the input device
        // TODO: update the steam flow rate in the 3D environment based on the input device value
    }

    float CalculateHeatTransferCoefficientE1()
    {
        // Calculate the heat transfer coefficient for E1 based on the specific design and geometry
        // of the heat exchanger. This could involve using empirical correlations or computational
        // fluid dynamics (CFD) simulations to determine the coefficient.
        // TODO: implement this function
        return 0.0f;
    }

    float CalculateHeatTransferCoefficientE2()
    {
        // Calculate the heat transfer coefficient for E2 based on the specific design and geometry
        // of the heat exchanger. This could involve using empirical correlations or computational
        // fluid dynamics (CFD) simulations to determine the coefficient.
        // TODO: implement this function
        return 0.0f;
    }

    float CalculateSurfaceAreaE1()
    {
        // Calculate the surface area of E1 based on the specific design and geometry of the heat exchanger.
        // This could involve using the dimensions of the heat exchanger, such as the length and diameter of
        // the tubes or the size of the heat transfer plates.
        // TODO: implement this function
        return 20.0f;
    }

    float CalculateSurfaceAreaE2()
    {
        // Calculate the surface area of E2 based on the specific design and geometry of the heat exchanger.
        // This could involve using the dimensions of the heat exchanger, such as the length and diameter of
        // the tubes or the size of the heat transfer plates.
        // TODO: implement this function
        return 20.0f;
    }

    float CalculateLogMeanTemperatureDifferenceE1(float deltaT)
    {
        // Calculate the log mean temperature difference for E1 based on the temperature difference between
        // the steam and water and the dimensions of the heat exchanger. This could involve using the length
        // and diameter of the tubes or the size of the heat transfer plates.
        // TODO: implement this function
        return 0.0f;
    }

    float CalculateLogMeanTemperatureDifferenceE2(float deltaT)
    {
        // Calculate the log mean temperature difference for E2 based on the temperature difference between
        // the water at E1 and E2 and the dimensions of the heat exchanger. This could involve using the length
        // and diameter of the tubes or the size of the heat transfer plates.
        // TODO: implement this function
        return 0.0f;
    }

    public void DisplayTextUpdate()
    {
        tI1Value.text = waterTemperatureInE1.ToString();
        //steamTemperatureValue.text = steamTemperature.ToString();
    }
}


