using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessDoneUI : MonoBehaviour
{
    public GameObject processDoneUI;

    public WaterController waterController;
    public ConcentratedLiquidrController concentrated;
    public TK1WaterLevel tKWaterLevel;

    private void Start()
    {
        processDoneUI.SetActive(false);
    }
    public void Update()
    {
        if (waterController && concentrated && tKWaterLevel)
        {
            processDoneUI.SetActive(true);
        }
    }
}
