// /*--------------------------------------------------------------------------------
// ----------------------------------------------------------------------------------
// Creation Date: #DateTime#
// Author: 2239356@swansea.ac.uk
// Description: ChemXR
// ----------------------------------------------------------------------------------
// --------------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script is used to check whether all steps are done.
/// </summary>
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
