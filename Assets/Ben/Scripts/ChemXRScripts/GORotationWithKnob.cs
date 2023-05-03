
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
using UnityEngine.XR.Content.Interaction;

public class GORotationWithKnob : MonoBehaviour
{
    public XRLever leverValue;

    private void Update()
    {
        RotateAroundZAxis();
    }
    public void RotateAroundZAxis()
    {
        gameObject.transform.right = leverValue.transform.forward;
    }
}
