
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
using UnityEngine.XR.Content.Interaction;


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

    public XRLever pumbSwitch1;
    public XRLever pumbSwitch2;

    public int totalStepsDone;

    [Header("Shut Down")]
    public KnobValueForText[] shutstepOne, shutstepTwo, shutstepThree, shutstepFour, shutstepFive, shutstepSix, shutstepSeven, shutstepEight, shutstepNine, shutstepTen;


    public TabletUIupdate tabletUI;

    private void Update()
    {
        StartStepOneIsDone();
        StartStepTwoIsDone();
        StartStepThreeIsDone();
        StartStepFourIsDone();
        StartStepFiveIsDone();
        StartStepSixIsDone();
        StartStepSevenIsDone();
        StartStepEightIsDone();
        StartStepNineIsDone();
        StartStepTenIsDone();
        StartStepElevenIsDone();
        StartStepTwelveIsDone();
        StartStepThirteenIsDone();
        StartStepFourteenIsDone();
        StartStepFifteenIsDone();
        StartStepSixteenIsDone();

        AllStepsDoneOrNot();
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
                totalStepsDone = 1;
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
                    totalStepsDone = 2;
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
                if (startstepThree[substep].isDone)
                {
                    Debug.Log("Substep three is done" + i);
                    substepdone++;
                    
                }

                if (substepdone == startstepThree.Length)
                {
                    tabletUI.fullyOpenImage[2].color = Color.white;
                    totalStepsDone = 3;
                }
                else
                {
                    tabletUI.fullyOpenImage[2].color = Color.red;
                }
            }
        }
    }

    public void StartStepFourIsDone()
    {
        for (int i = 0; i < startstepFour.Length; i++)
        {
            int substepdone = 0;
            for (int substep = 0; substep < startstepFour.Length; substep++)
            {
                if (startstepFour[substep].isDone)
                {
                    Debug.Log("Substep Four is done" + i);
                    substepdone++;
                    
                }

                if (substepdone == startstepFour.Length)
                {
                    tabletUI.fullyOpenImage[3].color = Color.white;
                    totalStepsDone = 4;
                }
                else
                {
                    tabletUI.fullyOpenImage[3].color = Color.red;
                }
            }
        }
    }

    public void StartStepFiveIsDone()
    {
        for (int i = 0; i < startstepFive.Length; i++)
        {
            int substepdone = 0;
            for (int substep = 0; substep < startstepFive.Length; substep++)
            {
                if (startstepFive[substep].isDone)
                {
                    Debug.Log("Substep five is done" + i);
                    substepdone++;
                    
                }

                if (substepdone == startstepFive.Length)
                {
                    tabletUI.fullyOpenImage[4].color = Color.white;
                    totalStepsDone = 5;
                }
                else
                {
                    tabletUI.fullyOpenImage[4].color = Color.red;
                }
            }
        }
    }

    public void StartStepSixIsDone()
    {
        for (int i = 0; i < startstepSix.Length; i++)
        {
            int substepdone = 0;
            for (int substep = 0; substep < startstepSix.Length; substep++)
            {
                if (startstepSix[substep].isDone)
                {
                    Debug.Log("Substep Six is done" + i);
                    substepdone++;
                }

                if (substepdone == startstepSix.Length)
                {
                    tabletUI.fullyOpenImage[5].color = Color.white;
                    totalStepsDone = 6;
                }
                else
                {
                    tabletUI.fullyOpenImage[5].color = Color.red;
                }
            }
        }
    }

    public void StartStepSevenIsDone()
    {
        for (int i = 0; i < startstepSeven.Length; i++)
        {
            int substepdone = 0;
            for (int substep = 0; substep < startstepSeven.Length; substep++)
            {
                if (startstepSeven[substep].isDone)
                {
                    Debug.Log("Substep Seven is done" + i);
                    substepdone++;
                }

                if (substepdone == startstepSeven.Length)
                {
                    tabletUI.fullyOpenImage[6].color = Color.white;
                    totalStepsDone = 7;
                }
                else
                {
                    tabletUI.fullyOpenImage[6].color = Color.red;
                }
            }
        }
    }

    public void StartStepEightIsDone()
    {
        for (int i = 0; i < startstepEight.Length; i++)
        {
            int substepdone = 0;
            for (int substep = 0; substep < startstepEight.Length; substep++)
            {
                if (startstepEight[substep].isDone)
                {
                    Debug.Log("Substep Eight is done" + i);
                    substepdone++;
                }

                if (substepdone == startstepEight.Length)
                {
                    tabletUI.fullyOpenImage[7].color = Color.white;
                    totalStepsDone = 8;
                }
                else
                {
                    tabletUI.fullyOpenImage[7].color = Color.red;
                }
            }
        }
    }

    public void StartStepNineIsDone()
    {
        for (int i = 0; i < startstepNine.Length; i++)
        {
            int substepdone = 0;
            for (int substep = 0; substep < startstepNine.Length; substep++)
            {
                if (startstepNine[substep].isDone)
                {
                    Debug.Log("Substep Nine is done" + i);
                    substepdone++;
                }

                if (substepdone == startstepNine.Length)
                {
                    tabletUI.fullyOpenImage[8].color = Color.white;
                    totalStepsDone = 9;
                }
                else
                {
                    tabletUI.fullyOpenImage[8].color = Color.red;
                }
            }
        }
    }

    public void StartStepTenIsDone()
    {
        for (int i = 0; i < startstepTen.Length; i++)
        {
            
            for (int substep = 0; substep < startstepTen.Length; substep++)
            {
                
                if (!pumbSwitch1.value)
                {
                    tabletUI.fullyOpenImage[9].color = Color.white;
                    totalStepsDone = 10;
                }
                else
                {
                    tabletUI.fullyOpenImage[9].color = Color.red;
                }
            }
        }
    }


    public void StartStepElevenIsDone()
    {
        for (int i = 0; i < startstepEleven.Length; i++)
        {
            int substepdone = 0;
            for (int substep = 0; substep < startstepEleven.Length; substep++)
            {
                if (startstepEleven[substep].isDone)
                {
                    Debug.Log("Substep Nine is done" + i);
                    substepdone++;
                }

                if (substepdone == startstepEleven.Length)
                {
                    tabletUI.fullyOpenImage[10].color = Color.white;
                    totalStepsDone = 11;
                }
                else
                {
                    tabletUI.fullyOpenImage[10].color = Color.red;
                }
            }
        }
    }


    public void StartStepTwelveIsDone()
    {
        for (int i = 0; i < startstepTwelve.Length; i++)
        {
            int substepdone = 0;
            for (int substep = 0; substep < startstepTwelve.Length; substep++)
            {
                if (startstepTwelve[substep].isDone)
                {
                    Debug.Log("Substep Nine is done" + i);
                    substepdone++;
                }

                if (substepdone == startstepTwelve.Length)
                {
                    tabletUI.fullyOpenImage[11].color = Color.white;
                    totalStepsDone = 12;
                }
                else
                {
                    tabletUI.fullyOpenImage[11].color = Color.red;
                }
            }
        }
    }

    public void StartStepThirteenIsDone()
    {
        for (int i = 0; i < startstepThirteen.Length; i++)
        {
            int substepdone = 0;
            for (int substep = 0; substep < startstepThirteen.Length; substep++)
            {
                if (startstepThirteen[substep].isDone)
                {
                    Debug.Log("Substep Nine is done" + i);
                    substepdone++;
                }

                if (substepdone == startstepThirteen.Length)
                {
                    tabletUI.fullyOpenImage[12].color = Color.white;
                    totalStepsDone = 13;
                }
                else
                {
                    tabletUI.fullyOpenImage[12].color = Color.red;
                }
            }
        }
    }

    public void StartStepFourteenIsDone()
    {
        for (int i = 0; i < startstepFourteen.Length; i++)
        {
            int substepdone = 0;
            for (int substep = 0; substep < startstepFourteen.Length; substep++)
            {
                if (startstepFourteen[substep].isDone)
                {
                    Debug.Log("Substep Nine is done" + i);
                    substepdone++;
                }

                if (substepdone == startstepFourteen.Length)
                {
                    tabletUI.fullyOpenImage[13].color = Color.white;
                    totalStepsDone = 14;
                }
                else
                {
                    tabletUI.fullyOpenImage[13].color = Color.red;
                }
            }
        }
    }


    public void StartStepFifteenIsDone()
    {
        for (int i = 0; i < startstepFifteen.Length; i++)
        {
            
            for (int substep = 0; substep < startstepFifteen.Length; substep++)
            {
             
                if (!pumbSwitch2.value)
                {
                    tabletUI.fullyOpenImage[14].color = Color.white;
                    totalStepsDone = 15;
                }
                else
                {
                    tabletUI.fullyOpenImage[14].color = Color.red;
                }
            }
        }
    }

    public void StartStepSixteenIsDone()
    {
        for (int i = 0; i < startstepSixteen.Length; i++)
        {
            int substepdone = 0;
            for (int substep = 0; substep < startstepSixteen.Length; substep++)
            {
                if (startstepSixteen[substep].isDone)
                {
                    Debug.Log("Substep Nine is done" + i);
                    substepdone++;
                }

                if (substepdone == startstepSixteen.Length)
                {
                    tabletUI.fullyOpenImage[15].color = Color.white;
                    totalStepsDone = 16;
                }
                else
                {
                    tabletUI.fullyOpenImage[15].color = Color.red;
                }
            }
        }
    }

  

    #endregion

    public void AllStepsDoneOrNot()
    {
        if(totalStepsDone == 16)
        {
            Debug.Log("All Steps Done !");
        }
    }
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
