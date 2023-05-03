
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
using UnityEngine.UI;
using UnityEngine.XR.Content.Interaction;

public class TabletUIupdate : MonoBehaviour
{
    public XRKnob[] fullyOpenXRKnob;
    public Image[] fullyOpenImage;

    public XRKnob[] partiallyOpenXRKnob;
    public Image[] partiallyOpenImage;

    private void Update()
    {
        FullyOpenKnobStatus();
        PartiallyOpenKnobStatus();
    }


    public void FullyOpenKnobStatus()
    {
        for (int i = 0; i < fullyOpenXRKnob.Length; i++)
        {
            XRKnob xrknobvar = fullyOpenXRKnob[i].GetComponent<XRKnob>();

            if (xrknobvar.value >= 0.9f)
            {
                //fullyOpenImage[i].color = Color.white;
            }
            else if (xrknobvar.value >= 0.45f && xrknobvar.value <= 0.55f)
            {
                //fullyOpenImage[i].color = Color.yellow;
            }
            else if (xrknobvar.value < 0.45f)
            {
                //fullyOpenImage[i].color = Color.red;
            }
        }
    }

    public void PartiallyOpenKnobStatus()
    {
        for (int i = 0; i < partiallyOpenXRKnob.Length; i++)
        {
            XRKnob xrknobvar = partiallyOpenXRKnob[i].GetComponent<XRKnob>();

            if (xrknobvar.value >= 0.45f)
            {
                //partiallyOpenImage[i].color = Color.white;
            }
            else if (xrknobvar.value < 0.45f)
            {
                //partiallyOpenImage[i].color = Color.red;
            }
        }
    }
}
