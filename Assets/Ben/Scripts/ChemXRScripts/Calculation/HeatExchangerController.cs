using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using TMPro;

public class HeatExchangerController : MonoBehaviour
{
    public float steamFlowRate;
    public float waterFlowRate;

    public float steamTemperature;
    public float waterTemperatureInE1; 
    public float waterTemperatureOutE1; 
    public float waterTemperatureOutE2; 
    public float waterTemperatureOutE3;
    public float _waterTemperatureOutE1;
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
        float deltaT = steamTemperature - waterTemperatureInE1;
        float Q = waterFlowRate * 2 * densityWater * specificHeatWater * deltaT;
        Debug.Log(waterFlowRate);
        heatTransferCoefficientE1 = Q / deltaT;

        float uA = heatTransferCoefficientE1 * 45.3f /100;  // overall heat transfer coefficient times surface area of E1

        float dt1 = steamTemperature - waterTemperatureInE1;
        float dt2 = waterTemperatureOutE1 - (waterTemperatureOutE1 - 0.01f);
        float LMTDE1 = ((dt1 - dt2) / Mathf.Log(dt1 / dt2));
        float deltaTLogMean = LMTDE1; // log mean temperature difference for E1
        Debug.Log(deltaTLogMean);
        waterTemperatureOutE1 = 2.5f * waterTemperatureInE1 + Q / (uA * 13.3f);
        _waterTemperatureOutE1 = 2 * (waterTemperatureInE1 + (Q / (waterFlowRate * specificHeatWater))) / 10000;
        Debug.Log(_waterTemperatureOutE1);
        tI2Value.text = _waterTemperatureOutE1.ToString("f2");
        tI3Value.text = waterTemperatureOutE1.ToString("f2");
        Debug.Log(waterTemperatureOutE1);
    }

    public void CalculateWaterTemperatureOutE2()
    {
        float deltaT = waterTemperatureOutE1; // temperature difference between water at E1 and E2
        float Q = steamFlowRate * 2.5f * densityWater * specificHeatWater * deltaT; // heat transferred from E1 to E2
        heatTransferCoefficientE2 = Q / deltaT;
        Debug.Log(steamFlowRate);
        float uA = heatTransferCoefficientE2 * 33.3f;  // overall heat transfer coefficient times surface area of E2
        float deltaTLogMean = CalculateLogMeanTemperatureDifferenceE2(deltaT);  // log mean temperature difference for E2
        Debug.Log(deltaTLogMean);
        //float waterTemperatureInE2 = steamTemperature - (q / (steamFlowRate * specificHeatWater)); 
        waterTemperatureOutE2 = waterTemperatureOutE1 - Q / (uA * 3.3f); // calculate water temperature at the outlet of E2
        tI6Value.text = (waterTemperatureOutE2 / 2f).ToString("f2");      
    }

    public void CalculateWaterTemperatureOutE3()
    {
        float deltaT = waterTemperatureInE1;// - waterTemperatureOutE2; // temperature difference between water at E1 and E2
        float Q = waterFlowRate * densityWater * specificHeatWater * deltaT; // heat transferred from E1 to E2

        float uA = heatTransferCoefficientE2 * 13.3f;  // overall heat transfer coefficient times surface area of E2
        float deltaTLogMean = 1.6f;  // log mean temperature difference for E2

        waterTemperatureOutE3 = _waterTemperatureOutE1 - Q / (uA * deltaTLogMean); // calculate water temperature at the outlet of E2
        tI4Value.text = (waterTemperatureOutE3 / 2f).ToString("f2");
    }

    void ControlSteamFlowRate()
    {
        // Control the steam flow rate.
        steamFlowRate = steamKnobValue.value *100;
        //Debug.Log("Steam FLow Rate: " + steamFlowRate);
    }
    void WaterFlowRate()
    {
        // Control the steam flow rate.
        waterFlowRate = waterKnobValue.value * 100;  // get the steam flow rate from the input device
        //Debug.Log("Steam FLow Rate: " + waterFlowRate);
    }


    float CalculateLogMeanTemperatureDifferenceE1()
    {
        float dt1 = steamTemperature - waterTemperatureInE1;
        float dt2 = waterTemperatureOutE1 - (waterTemperatureOutE1 - 0.01f);
        float LMTDE1 = ((dt1 - dt2) / Mathf.Log(dt1 / dt2));
        Debug.Log(LMTDE1);
        return LMTDE1;
    }

    float CalculateLogMeanTemperatureDifferenceE2(float deltaT)
    {
        float dt1 = waterTemperatureInE1;
        float dt2 = waterTemperatureOutE1 - waterTemperatureOutE2;
        float LMTDE2 = ((dt1 - dt2) / Mathf.Log(dt1 / dt2));
        
        return LMTDE2;
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
        float t15 = waterTemperatureInE1 + Random.Range(-2.2f, -1.6f);
        tI5Value.text = t15.ToString("F2");
        
        //steamTemperatureValue.text = steamTemperature.ToString();
        float t16 = waterTemperatureOutE2 - Random.Range(3f, 6f);
        tI6Value.text = t16.ToString("F2");
    }
    
    
}


