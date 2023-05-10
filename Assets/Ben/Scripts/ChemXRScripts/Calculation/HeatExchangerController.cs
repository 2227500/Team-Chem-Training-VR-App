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

    public float heatTransferCoefficientE1; // heat transfer coefficient for E1
    public float heatTransferCoefficientE2; // heat transfer coefficient for E2
    public float densityWater = 1000.0f; // density of water in kg/m^3
    public float specificHeatWater = 4180.0f; // specific heat of water in J/(kg*K)

    public bool isPumpOneOn;
    public bool isPumpTwoOn;

    public TextMeshPro tI1Value;
    public TextMeshPro tI2Value;
    public TextMeshPro tI3Value;
    public TextMeshPro tI4Value;
    public TextMeshPro tI5Value;
    public TextMeshPro tI6Value;
    //public TextMeshPro steamTemperatureValue;

    public XRKnob steamKnobValue;
    public XRKnob waterKnobValue;


    public float concLiquidFlowRate;
    public float condensedWaterFlowRate;
    void Start()
    {
        //// Initialize the heat transfer coefficients for E1 and E2 based on the
        //// specific design and geometry of the heat exchangers.
        //heatTransferCoefficientE1 = CalculateHeatTransferCoefficientE1();
        //heatTransferCoefficientE2 = CalculateHeatTransferCoefficientE2();

        StartCoroutine(DisplayTextUpdate());
    }

    void Update()
    {
        CalculateWaterTemperatureOutE1();
        CalculateWaterTemperatureOutE2();

        

        ControlSteamFlowRate();
        WaterFlowRate();

        CalculatedFlowRate();
    }

    public void CalculateWaterTemperatureOutE1()
    {

        // Calculate the temperature of the water at the outlet of E1 based on the steam temperature,
        // water flow rate, heat transfer coefficient of E1, and physical properties of water such as density
        // and specific heat.
        
        float deltaT = steamTemperature - waterTemperatureInE1; // temperature difference between steam and water
        float q = waterFlowRate * densityWater * specificHeatWater * deltaT; // heat transferred from steam to water
        float uA = heatTransferCoefficientE1 * 33.3f; //CalculateSurfaceAreaE1(); // overall heat transfer coefficient times surface area of E1
        float deltaTLogMean = 53.6f; // CalculateLogMeanTemperatureDifferenceE1(deltaT); // log mean temperature difference for E1
        waterTemperatureOutE1 = waterTemperatureInE1 + q / (uA * deltaTLogMean); // calculate water temperature at the outlet of E1
        tI2Value.text = waterTemperatureOutE1.ToString("f2");

        Debug.Log("DeltaT1 : " + deltaT);
        Debug.Log("Heat transferred (q)1: " + q);
        Debug.Log(heatTransferCoefficientE1);
        Debug.Log("uA1 : " + uA);
        Debug.Log("Log mean temperature1: " + deltaTLogMean);
        Debug.Log("WaterTemperatureOutE1: " + waterTemperatureOutE1);
    }

    public void CalculateWaterTemperatureOutE2()
    {
        // Calculate the temperature of the water at the outlet of E2 based on the water
        // flow rate, heat transfer coefficient of E2, and physical properties of water.
        float deltaT = waterTemperatureOutE1;// - waterTemperatureOutE2; // temperature difference between water at E1 and E2
        float q = waterFlowRate * densityWater * specificHeatWater * deltaT; // heat transferred from E1 to E2
        float uA = heatTransferCoefficientE2 * 33.3f; //CalculateSurfaceAreaE2(); // overall heat transfer coefficient times surface area of E2
        float deltaTLogMean = 53.6f; //CalculateLogMeanTemperatureDifferenceE2(deltaT); // log mean temperature difference for E2
        waterTemperatureOutE2 = waterTemperatureOutE1 + q / (uA * deltaTLogMean); // calculate water temperature at the outlet of E2
        tI3Value.text = waterTemperatureOutE2.ToString("f2");

        Debug.Log("DeltaT2 : " + deltaT);
        Debug.Log("Heat transferred (q)2: " + q);
        Debug.Log(heatTransferCoefficientE2);
        Debug.Log("uA2 : " + uA);
        Debug.Log("Log mean temperature2: " + deltaTLogMean);
        Debug.Log("WaterTemperatureOutE2: " + waterTemperatureOutE2);
        Debug.Log("WaterTemperatureOutE1: " + waterTemperatureOutE1);

    }

    public void CalculateWaterTemperatureOutE3()
    {
        // Calculate the temperature of the water at the outlet of E2 based on the water
        // flow rate, heat transfer coefficient of E2, and physical properties of water.
        float deltaT = waterTemperatureOutE1;// - waterTemperatureOutE2; // temperature difference between water at E1 and E2
        float q = waterFlowRate * densityWater * specificHeatWater * deltaT; // heat transferred from E1 to E2
        float uA = heatTransferCoefficientE2 * 33.3f; //CalculateSurfaceAreaE2(); // overall heat transfer coefficient times surface area of E2
        float deltaTLogMean = 53.6f; //CalculateLogMeanTemperatureDifferenceE2(deltaT); // log mean temperature difference for E2
        waterTemperatureOutE2 = waterTemperatureOutE1 + q / (uA * deltaTLogMean); // calculate water temperature at the outlet of E2
        tI3Value.text = waterTemperatureOutE2.ToString("f2");

        Debug.Log("DeltaT2 : " + deltaT);
        Debug.Log("Heat transferred (q)2: " + q);
        Debug.Log(heatTransferCoefficientE2);
        Debug.Log("uA2 : " + uA);
        Debug.Log("Log mean temperature2: " + deltaTLogMean);
        Debug.Log("WaterTemperatureOutE2: " + waterTemperatureOutE2);
        Debug.Log("WaterTemperatureOutE1: " + waterTemperatureOutE1);

    }

    void ControlSteamFlowRate()
    {
        // Control the steam flow rate.
        steamFlowRate = steamKnobValue.value;
        //Debug.Log("Steam FLow Rate: " + steamFlowRate);
    }
    void WaterFlowRate()
    {
        // Control the steam flow rate.
        waterFlowRate = waterKnobValue.value;  // get the steam flow rate from the input device
        //Debug.Log("Steam FLow Rate: " + steamFlowRate);
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
        return 33.3f;
    }

    float CalculateSurfaceAreaE2()
    {
        // Calculate the surface area of E2 based on the specific design and geometry of the heat exchanger.
        // This could involve using the dimensions of the heat exchanger, such as the length and diameter of
        // the tubes or the size of the heat transfer plates.
        // TODO: implement this function
        return 33.3f;
    }

    float CalculateLogMeanTemperatureDifferenceE1(float deltaT)
    {
        // Calculate the log mean temperature difference for E1 based on the temperature difference between
        // the steam and water and the dimensions of the heat exchanger. This could involve using the length
        // and diameter of the tubes or the size of the heat transfer plates.
        // TODO: implement this function
        float dt1 = steamTemperature - waterTemperatureInE1;
        float dt2 = waterTemperatureOutE1 - waterTemperatureOutE2;
        float LMTDE1 = ((dt1 - dt2) / Mathf.Log(dt1 / dt2));
        deltaT = LMTDE1;
        return deltaT;
    }

    float CalculateLogMeanTemperatureDifferenceE2(float deltaT)
    {
        // Calculate the log mean temperature difference for E2 based on the temperature difference between
        // the water at E1 and E2 and the dimensions of the heat exchanger. This could involve using the length
        // and diameter of the tubes or the size of the heat transfer plates.
        // TODO: implement this function
        return 0.0f;
    }

    bool PumpOnOff()
    {
        return true;
    }

    public void CalculatedFlowRate()
    {
        concLiquidFlowRate = waterKnobValue.value - steamKnobValue.value;
        condensedWaterFlowRate = steamKnobValue.value;
    }

    IEnumerator DisplayTextUpdate()
    {
        tI1Value.text = waterTemperatureInE1.ToString("F2");
        float t15 = waterTemperatureInE1 + Random.Range(-0.2f, 0.6f);
        tI5Value.text = t15.ToString("F2");
        //steamTemperatureValue.text = steamTemperature.ToString();
        yield return new WaitForSeconds(10f);
    }
}


