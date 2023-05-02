
// /*--------------------------------------------------------------------------------
// ----------------------------------------------------------------------------------
// Creation Date: #DateTime#
// Author: 2239356@swansea.ac.uk
// Description: ChemXR
// ----------------------------------------------------------------------------------
// --------------------------------------------------------------------------------*/


using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class StepsCategorisation : MonoBehaviour
{
    [Header("Start Up")]
    public KnobValueForText[] startstepOne;
    public KnobValueForText[] startstepTwo;
    public KnobValueForText[] startstepThree;
    public KnobValueForText[] startstepFour;
    public KnobValueForText[] startstepFive;
    public KnobValueForText[] startstepSix;
    public KnobValueForText[] startstepSeven;
    public KnobValueForText[] startstepEight;
    public KnobValueForText[] startstepNine;
    public KnobValueForText[] startstepTen;
    public KnobValueForText[] startstepEleven;
    public KnobValueForText[] startstepTwelve;
    public KnobValueForText[] startstepThirteen;
    public KnobValueForText[] startstepFourteen;
    public KnobValueForText[] startstepFifteen;
    public KnobValueForText[] startstepSixteen;
    public KnobValueForText[] startstepSeventeen;

    [Header("Shut Down")]
    public KnobValueForText[] shutstepOne, shutstepTwo, shutstepThree, shutstepFour, shutstepFive, shutstepSix, shutstepSeven, shutstepEight, shutstepNine, shutstepTen;


    public TabletUIupdate tabletUI;

    private void Update()
    {
        StartStepOneIsDone();
        StartStepTwoIsDone();
    }

    #region Start up of Machine
    public void StartStepOneIsDone()
    {
        for(int i = 0; i < startstepOne.Length; i++)
        {
            int substepdone = 0;
            if (startstepOne[i].isDone)
            {
                substepdone++;
                Debug.Log("Substep one is done");
                
            }

            if(substepdone == startstepOne.Length)
            {
                tabletUI.fullyOpenImage[0].color = Color.white;
            }
            else
            {
                tabletUI.fullyOpenImage[0].color = Color.red;
            }
        }
    }

    public void StartStepTwoIsDone()
    {
        for (int i = 0; i < startstepTwo.Length; i++)
        {
            int substepdone = 0;
            for (int substep = 0; substep < startstepTwo.Length; substep++)
            {
                
                if (startstepTwo[substep].isDone)
                {
                    Debug.Log("Substep two is done" + i);
                    substepdone++;
                }

                if (substepdone == startstepTwo.Length)
                {
                    tabletUI.fullyOpenImage[1].color = Color.white;
                }
                else
                {
                    tabletUI.fullyOpenImage[1].color = Color.red;
                }
            }
        }
    }

    public void StartStepThreeIsDone()
    {
        for (int i = 0; i < startstepThree.Length; i++)
        {
            int substepdone = 0;
            for (int substep = 0; substep < startstepThree.Length; substep++)
            {
                if (startstepTwo[substep].isDone)
                {
                    Debug.Log("Substep two is done" + i);
                    substepdone++;
                }

                if (substepdone == startstepThree.Length)
                {
                    tabletUI.fullyOpenImage[2].color = Color.white;
                }
                else
                {
                    tabletUI.fullyOpenImage[2].color = Color.red;
                }
            }
        }
    }
    #endregion


}

#if UNITY_EDITOR


[CustomEditor(typeof(StepsCategorisation))]
public class ToolTipForClass : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Script controls the UI update according to the steps done.");
        base.OnInspectorGUI();
    }
}

#endif
