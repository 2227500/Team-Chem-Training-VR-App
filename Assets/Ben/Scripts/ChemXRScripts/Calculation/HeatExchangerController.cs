using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using TMPro;

public class HeatExchangerController : MonoBehaviour
{
    public float steamFlowRate = 0.0f;
    public float waterFlowRate = 0.0f;
    public float steamTemperature = 0.0f; 
    public float waterTemperatureInE1 = 0.0f; 
    public float waterTemperatureOutE1 = 0.0f; 
    public float waterTemperatureOutE2 = 0.0f; 
    public float waterTemperatureOutE3 = 0.0f; 

    public float heatTransferCoefficientE1;
    public float heatTransferCoefficientE2; 
    public float densityWater = 1000.0f; 
    public float specificHeatWater = 4180.0f; 

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
       
        StartCoroutine(DisplayTextUpdate());
    }

    void Update()
    {
        CalculateWaterTemperatureOutE1();
        CalculateWaterTemperatureOutE2();
        CalculateWaterTemperatureOutE3();
        

        ControlSteamFlowRate();
        WaterFlowRate();

        CalculatedFlowRate();
    }

    public void CalculateWaterTemperatureOutE1()
    {
        
        float deltaT = steamTemperature - waterTemperatureInE1; // temperature difference between steam and water
        float q = waterFlowRate * densityWater * specificHeatWater * deltaT; // heat transferred from steam to water
        float uA = heatTransferCoefficientE1 * 33.3f;  // overall heat transfer coefficient times surface area of E1
        float deltaTLogMean = 53.6f; // log mean temperature difference for E1
        waterTemperatureOutE1 = waterTemperatureInE1 + q / (uA * deltaTLogMean); // calculate water temperature at the outlet of E1
        tI2Value.text = waterTemperatureOutE1.ToString("f2");

    }

    public void CalculateWaterTemperatureOutE2()
    {
        float deltaT = waterTemperatureOutE1; // temperature difference between water at E1 and E2
        float q = waterFlowRate * densityWater * specificHeatWater * deltaT; // heat transferred from E1 to E2
        float uA = heatTransferCoefficientE2 * 33.3f;  // overall heat transfer coefficient times surface area of E2
        float deltaTLogMean = 53.6f;  // log mean temperature difference for E2
        waterTemperatureOutE2 = waterTemperatureOutE1 + q / (uA * deltaTLogMean); // calculate water temperature at the outlet of E2
        tI3Value.text = waterTemperatureOutE2.ToString("f2");
        
    }

    public void CalculateWaterTemperatureOutE3()
    {
        float deltaT = waterTemperatureOutE1;// - waterTemperatureOutE2; // temperature difference between water at E1 and E2
        float q = waterFlowRate * densityWater * specificHeatWater * deltaT; // heat transferred from E1 to E2
        float uA = heatTransferCoefficientE2 * 33.3f;  // overall heat transfer coefficient times surface area of E2
        float deltaTLogMean = 53.6f;  // log mean temperature difference for E2
        waterTemperatureOutE3 = waterTemperatureOutE1 + q / (uA * deltaTLogMean); // calculate water temperature at the outlet of E2
        tI4Value.text = waterTemperatureOutE2.ToString("f2");

        Debug.Log("DeltaT3 : " + deltaT);
        Debug.Log("Heat transferred (q)3: " + q);
        Debug.Log(heatTransferCoefficientE2);
        Debug.Log("uA2 : " + uA);
        Debug.Log("Log mean temperature3: " + deltaTLogMean);
        Debug.Log("WaterTemperatureOutE3: " + waterTemperatureOutE2);
        Debug.Log("WaterTemperatureOutE3: " + waterTemperatureOutE1);

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

   

   

    float CalculateSurfaceAreaE1()
    {      
        return 33.3f;
    }

    float CalculateSurfaceAreaE2()
    {
        return 33.3f;
    }

    float CalculateLogMeanTemperatureDifferenceE1(float deltaT)
    {
        float dt1 = steamTemperature - waterTemperatureInE1;
        float dt2 = waterTemperatureOutE1 - waterTemperatureOutE2;
        float LMTDE1 = ((dt1 - dt2) / Mathf.Log(dt1 / dt2));
        deltaT = LMTDE1;
        return deltaT;
    }

    float CalculateLogMeanTemperatureDifferenceE2(float deltaT)
    {
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
        yield return new WaitForSeconds(10f);
        tI1Value.text = waterTemperatureInE1.ToString("F2");
        float t15 = waterTemperatureInE1 + Random.Range(-0.2f, 0.6f);
        tI5Value.text = t15.ToString("F2");
        
        //steamTemperatureValue.text = steamTemperature.ToString();
        float t16 = waterTemperatureOutE2 + Random.Range(3f, 6f);
        tI6Value.text = t16.ToString("F2");
    }
    
    
}


