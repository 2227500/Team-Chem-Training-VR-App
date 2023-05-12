
// /*--------------------------------------------------------------------------------
// ----------------------------------------------------------------------------------
// Creation Date: 12/05/23
// Author: 2239356@swansea.ac.uk
// Description: ChemXR
// ----------------------------------------------------------------------------------
// --------------------------------------------------------------------------------*/


using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public GameObject stepSixButton;
    public GameObject stepNineButton;
    public GameObject stepElevenButton;
    public GameObject stepSeventeenButton;
    public GameObject shutDownButton;

    public XRLever pumbSwitch1;
    public XRLever pumbSwitch2;
    public XRLever eLCBSwitch;

    public int totalStepsDone;

    [Header("Shut Down")]
    public KnobValueForText[] shutstepOne, shutstepTwo, shutstepThree, shutstepFour, shutstepFive, shutstepSix, shutstepSeven, shutstepEight, shutstepNine, shutstepTen;

    private bool isStepOneDone, isStepTwoDone, isStepThreeDone, isStepFourDOne, isStepFiveDOne, isStepSixDone, isStepSevenDone, isStepEightDone, isStepNineDone, isStepTenDone, isStepElevenDone, isStepTwelveDone, isStepThirteenDone, isStepFourteenDone, isStepFifteenDone, isStepSixteenDone, isStepSeventeenDone; 

    public TabletUIupdate tabletUI;

    public GameObject quizPanel;
    private void Start()
    {
        stepSixButton.SetActive(false);
        stepNineButton.SetActive(false);
        stepElevenButton.SetActive(false);
        stepSeventeenButton.SetActive(false);
        startSetupDoneSuccessfully = false;
        quizPanel.SetActive(false);
    }

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
        StartStepSeventeenIsDone();
        AllStartStepsDoneOrNot();

        if (startSetupDoneSuccessfully)
        {
            
            shutDownButton.SetActive(true);
            quizPanel.SetActive(true);
        }

        

    }

    #region Start up of Machine
    /// <summary>
    /// Methods used to check the steps are done or not.
    /// </summary>
    public void StartStepOneIsDone()
    {
        
        for(int i = 0; i<startstepOne.Length; i++)
        {
            startstepOne[i].leverOutlineColor.enabled = true;
        }


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
                isStepOneDone = true;
            }
            else
            {
                tabletUI.fullyOpenImage[0].color = Color.red;
                isStepOneDone = false;
                totalStepsDone = 0;
            }
        }
    }

    public void StartStepTwoIsDone()
    {
        if (isStepOneDone)
        {
            // Outline is getting enabled
            for (int i = 0; i < startstepTwo.Length; i++)
            {
                startstepTwo[i].leverOutlineColor.enabled = true;
            }
        }
        else
        {
            // Outline is getting disabled
            for (int i = 0; i < startstepTwo.Length; i++)
            {
                startstepTwo[i].leverOutlineColor.enabled = false;
            }
        }

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
                    isStepTwoDone = true;
                }
                else
                {
                    tabletUI.fullyOpenImage[1].color = Color.red;
                    isStepTwoDone = false;
                    totalStepsDone = 1;
                }
            }
        }
    }

    public void StartStepThreeIsDone()
    {
        if (isStepTwoDone)
        {
            // Outline is getting enabled
            for (int i = 0; i < startstepThree.Length; i++)
            {
                startstepThree[i].leverOutlineColor.enabled = true;
            }
        }
        else
        {
            // Outline is getting disabled
            for (int i = 0; i < startstepThree.Length; i++)
            {
                startstepThree[i].leverOutlineColor.enabled = false;
            }
        }

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
                    isStepThreeDone = true;
                }
                else
                {
                    tabletUI.fullyOpenImage[2].color = Color.red;
                    isStepThreeDone = false;
                    totalStepsDone = 2;
                }
            }
        }
    }

    public void StartStepFourIsDone()
    {
        if (isStepThreeDone)
        {
            // Outline is getting enabled
            for (int i = 0; i < startstepFour.Length; i++)
            {
                startstepFour[i].leverOutlineColor.enabled = true;
            }
        }
        else
        {
            // Outline is getting disabled
            for (int i = 0; i < startstepFour.Length; i++)
            {
                startstepFour[i].leverOutlineColor.enabled = false;
            }
        }

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
                    isStepFourDOne = true;
                }
                else
                {
                    tabletUI.fullyOpenImage[3].color = Color.red;
                    isStepFourDOne = false;
                    totalStepsDone = 3;
                }
            }
        }
    }

    public void StartStepFiveIsDone()
    {
        if (isStepFourDOne)
        {
            // Outline is getting enabled
            for (int i = 0; i < startstepFive.Length; i++)
            {
                startstepFive[i].leverOutlineColor.enabled = true;
            }
        }
        else
        {
            // Outline is getting disabled
            for (int i = 0; i < startstepFive.Length; i++)
            {
                startstepFive[i].leverOutlineColor.enabled = false;
            }
        }
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
                    isStepFiveDOne = true;
                }
                else
                {
                    tabletUI.fullyOpenImage[4].color = Color.red;
                    isStepFiveDOne = false;
                    totalStepsDone = 4;
                }
            }
        }
    }

    public void StartStepSixIsDone()
    {
        if (isStepFiveDOne)
        {
            stepSixButton.SetActive(true);
            //// Outline is getting enabled
            //for (int i = 0; i < startstepSix.Length; i++)
            //{
            //    startstepSix[i].leverOutlineColor.enabled = true;
            //}
        }
        else
        {
            //stepSixButton.SetActive(false);
            //// Outline is getting disabled
            //for (int i = 0; i < startstepSix.Length; i++)
            //{
            //    startstepSix[i].leverOutlineColor.enabled = false;
            //}
        }
        //for (int i = 0; i < startstepSix.Length; i++)
        //{
        //    int substepdone = 0;
        //    for (int substep = 0; substep < startstepSix.Length; substep++)
        //    {
        //        if (startstepSix[substep].isDone)
        //        {
        //            Debug.Log("Substep Six is done" + i);
        //            substepdone++;
        //        }

        //        if (substepdone == startstepSix.Length)
        //        {
        //            tabletUI.fullyOpenImage[5].color = Color.white;
        //            totalStepsDone = 6;
        //            isStepSixDone = true;
        //        }
        //        else
        //        {
        //            tabletUI.fullyOpenImage[5].color = Color.red;
        //            isStepSixDone = false;
        //            totalStepsDone = 5;
        //        }
        //    }
        //}

        if (isStepSixDone)
        {
            tabletUI.fullyOpenImage[5].color = Color.white;
            totalStepsDone = 6;
            isStepSixDone = true;
        }
        else
        {
            tabletUI.fullyOpenImage[5].color = Color.red;
            isStepSixDone = false;
            totalStepsDone = 5;
        }
    }

    public void StartStepSevenIsDone()
    {
        if (isStepSixDone)
        {
            stepSixButton.SetActive(false);
            // Outline is getting enabled
            for (int i = 0; i < startstepSeven.Length; i++)
            {
                startstepSeven[i].leverOutlineColor.enabled = true;
            }
        }
        else
        {
            // Outline is getting disabled
            for (int i = 0; i < startstepSeven.Length; i++)
            {
                startstepSeven[i].leverOutlineColor.enabled = false;
            }
        }
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
                    isStepSevenDone = true;
                }
                else
                {
                    tabletUI.fullyOpenImage[6].color = Color.red;
                    isStepSevenDone = false;
                }
            }
        }
    }

    public void StartStepEightIsDone()
    {
        if (isStepSevenDone)
        {
            // Outline is getting enabled
            for (int i = 0; i < startstepEight.Length; i++)
            {
                startstepEight[i].leverOutlineColor.enabled = true;
            }
        }
        else
        {
            // Outline is getting disabled
            for (int i = 0; i < startstepEight.Length; i++)
            {
                startstepEight[i].leverOutlineColor.enabled = false;
            }
        }

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
                    isStepEightDone = true;
                }
                else
                {
                    tabletUI.fullyOpenImage[7].color = Color.red;
                    isStepEightDone = false;
                }
            }
        }
    }

    public void StartStepNineIsDone()
    {
        if (isStepEightDone)
        {
            stepNineButton.SetActive(true);
            //// Outline is getting enabled
            //for (int i = 0; i < startstepNine.Length; i++)
            //{
            //    startstepNine[i].leverOutlineColor.enabled = true;
            //}
        }
        else
        {
            stepNineButton.SetActive(false);
            //// Outline is getting disabled
            //for (int i = 0; i < startstepNine.Length; i++)
            //{
            //    startstepNine[i].leverOutlineColor.enabled = false;
            //}
        }

        //for (int i = 0; i < startstepNine.Length; i++)
        //{
        //    int substepdone = 0;
        //    for (int substep = 0; substep < startstepNine.Length; substep++)
        //    {
        //        if (startstepNine[substep].isDone)
        //        {
        //            Debug.Log("Substep Nine is done" + i);
        //            substepdone++;
        //        }

        //        if (substepdone == startstepNine.Length)
        //        {
        //            tabletUI.fullyOpenImage[8].color = Color.white;
        //            totalStepsDone = 9;
        //            isStepNineDone = true;
        //        }
        //        else
        //        {
        //            tabletUI.fullyOpenImage[8].color = Color.red;
        //            isStepNineDone = false;
        //        }
        //    }
        //}

        if (isStepNineDone)
        {
            tabletUI.fullyOpenImage[8].color = Color.white;
            totalStepsDone = 9;
            isStepNineDone = true;
        }
        else
        {
            tabletUI.fullyOpenImage[8].color = Color.red;
            isStepNineDone = false;
            
        }
    }

    public void StartStepTenIsDone()
    {
        if (isStepNineDone)
        {
            stepNineButton.SetActive(false);
            // Outline is getting enabled
            for (int i = 0; i < startstepTen.Length; i++)
            {
                startstepTen[i].leverOutlineColor.enabled = true;
            }
        }
        else
        {
            // Outline is getting disabled
            for (int i = 0; i < startstepTen.Length; i++)
            {
                startstepTen[i].leverOutlineColor.enabled = false;
            }
        }

        for (int i = 0; i < startstepTen.Length; i++)
        {
            
            for (int substep = 0; substep < startstepTen.Length; substep++)
            {
                
                if (!pumbSwitch2.value)
                {
                    tabletUI.fullyOpenImage[9].color = Color.white;
                    totalStepsDone = 10;
                    isStepTenDone = true;
                }
                else
                {
                    tabletUI.fullyOpenImage[9].color = Color.red;
                    isStepTenDone = false;
                }
            }
        }
    }


    public void StartStepElevenIsDone()
    {
        if (isStepTenDone)
        {
            stepElevenButton.SetActive(true);
            //// Outline is getting enabled
            //for (int i = 0; i < startstepEleven.Length; i++)
            //{
            //    startstepEleven[i].leverOutlineColor.enabled = true;
            //}
        }
        else
        {
            stepElevenButton.SetActive(false);
            //// Outline is getting disabled
            //for (int i = 0; i < startstepEleven.Length; i++)
            //{
            //    startstepEleven[i].leverOutlineColor.enabled = false;
            //}
        }

        //for (int i = 0; i < startstepEleven.Length; i++)
        //{
        //    int substepdone = 0;
        //    for (int substep = 0; substep < startstepEleven.Length; substep++)
        //    {
        //        if (startstepEleven[substep].isDone)
        //        {
        //            Debug.Log("Substep Nine is done" + i);
        //            substepdone++;
        //        }

        //        if (substepdone == startstepEleven.Length)
        //        {
        //            tabletUI.fullyOpenImage[10].color = Color.white;
        //            totalStepsDone = 11;
        //            isStepElevenDone = true;
        //        }
        //        else
        //        {
        //            tabletUI.fullyOpenImage[10].color = Color.red;
        //            isStepElevenDone = false;
        //        }
        //    }
        //}

        if (isStepElevenDone)
        {
            tabletUI.fullyOpenImage[10].color = Color.white;
            totalStepsDone = 11;
            //isStepElevenDone = true;
        }
        else
        {
            tabletUI.fullyOpenImage[10].color = Color.red;
            //isStepElevenDone = false;
            
        }
    }


    public void StartStepTwelveIsDone()
    {
        if (isStepElevenDone)
        {
            stepElevenButton.SetActive(false);
            // Outline is getting enabled
            for (int i = 0; i < startstepTwelve.Length; i++)
            {
                startstepTwelve[i].leverOutlineColor.enabled = true;
            }
        }
        else
        {
            // Outline is getting disabled
            for (int i = 0; i < startstepTwelve.Length; i++)
            {
                startstepTwelve[i].leverOutlineColor.enabled = false;
            }
        }
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
        if (isStepTwelveDone)
        {
            // Outline is getting enabled
            for (int i = 0; i < startstepThirteen.Length; i++)
            {
                startstepThirteen[i].leverOutlineColor.enabled = true;
            }
        }
        else
        {
            // Outline is getting disabled
            for (int i = 0; i < startstepThirteen.Length; i++)
            {
                startstepThirteen[i].leverOutlineColor.enabled = false;
            }
        }

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
                    isStepThirteenDone = true;
                }
                else
                {
                    tabletUI.fullyOpenImage[12].color = Color.red;
                    isStepThirteenDone = false;
                }
            }
        }
    }

    public void StartStepFourteenIsDone()
    {
        if (isStepThirteenDone)
        {
            // Outline is getting enabled
            for (int i = 0; i < startstepFourteen.Length; i++)
            {
                startstepFourteen[i].leverOutlineColor.enabled = true;
            }
        }
        else
        {
            // Outline is getting disabled
            for (int i = 0; i < startstepFourteen.Length; i++)
            {
                startstepFourteen[i].leverOutlineColor.enabled = false;
            }
        }

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
                    isStepFourteenDone = true;
                }
                else
                {
                    tabletUI.fullyOpenImage[13].color = Color.red;
                    isStepFourteenDone = false;
                }
            }
        }
    }


    public void StartStepFifteenIsDone()
    {
        if (isStepFourteenDone)
        {
            // Outline is getting enabled
            for (int i = 0; i < startstepFifteen.Length; i++)
            {
                startstepFifteen[i].leverOutlineColor.enabled = true;
            }
        }
        else
        {
            // Outline is getting disabled
            for (int i = 0; i < startstepFifteen.Length; i++)
            {
                startstepFifteen[i].leverOutlineColor.enabled = false;
            }
        }

        for (int i = 0; i < startstepFifteen.Length; i++)
        {
            
            for (int substep = 0; substep < startstepFifteen.Length; substep++)
            {
             
                if (!pumbSwitch1.value)
                {
                    tabletUI.fullyOpenImage[14].color = Color.white;
                    totalStepsDone = 15;
                    isStepFifteenDone = true;
                    Debug.Log("pumpswitch2 " + pumbSwitch1.value);
                }
                else
                {
                    tabletUI.fullyOpenImage[14].color = Color.red;
                    isStepFifteenDone = false;
                }
            }
        }
    }

    public void StartStepSixteenIsDone()
    {
        if (isStepFifteenDone)
        {
            // Outline is getting enabled
            for (int i = 0; i < startstepSixteen.Length; i++)
            {
                startstepSixteen[i].leverOutlineColor.enabled = true;
            }
        }
        else
        {
            // Outline is getting disabled
            for (int i = 0; i < startstepSixteen.Length; i++)
            {
                startstepSixteen[i].leverOutlineColor.enabled = false;
            }
        }
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
                    isStepSixteenDone = true;
                }
                else
                {
                    tabletUI.fullyOpenImage[15].color = Color.red;
                    isStepSixteenDone = false;
                }
            }
        }
    }

    public void StartStepSeventeenIsDone()
    {
        if (isStepSixteenDone)
        {
            stepSeventeenButton.SetActive(true);
            //// Outline is getting enabled
            //for (int i = 0; i < startstepSixteen.Length; i++)
            //{
            //    startstepSixteen[i].leverOutlineColor.enabled = true;
            //}
        }
        else
        {
            stepSeventeenButton.SetActive(false);
            //// Outline is getting disabled
            //for (int i = 0; i < startstepSixteen.Length; i++)
            //{
            //    startstepSixteen[i].leverOutlineColor.enabled = false;
            //}
        }
        //for (int i = 0; i < startstepSixteen.Length; i++)
        //{
        //    int substepdone = 0;
        //    for (int substep = 0; substep < startstepSixteen.Length; substep++)
        //    {
        //        if (startstepSixteen[substep].isDone)
        //        {
        //            Debug.Log("Substep Nine is done" + i);
        //            substepdone++;
        //        }

        //        if (substepdone == startstepSixteen.Length)
        //        {
        //            tabletUI.fullyOpenImage[15].color = Color.white;
        //            totalStepsDone = 17;
        //            isStepSixteenDone = true;
        //            stepSeventeenButton.SetActive(false);
        //        }
        //        else
        //        {
        //            tabletUI.fullyOpenImage[15].color = Color.red;
        //            isStepSixteenDone = false;
        //        }
        //    }
        //}

        if (isStepSeventeenDone)
        {
            tabletUI.fullyOpenImage[16].color = Color.white;
            totalStepsDone = 17;
            isStepSeventeenDone = true;
        }
        else
        {
            tabletUI.fullyOpenImage[16].color = Color.red;
            isStepSeventeenDone = false;
            totalStepsDone = 16;
        }
    }
    public void StepSixDone()
    {
        
        isStepSixDone = true;
        stepSixButton.SetActive(false);
    }

    public void StepNineDone()
    {
        isStepNineDone = true;
        

    }

    public void StepElevenDone()
    {
        isStepElevenDone = true;
        
    }

    public void StepSeventeenDone()
    {
        isStepSeventeenDone = true;

        startSetupDoneSuccessfully = true;
    }
    #endregion //

    //public void ELCB()
    //{
    //    isStepSevenDone = true;
    //    totalStepsDone = 7;

    //}

    public GameObject startUpCompleted;
    public bool startSetupDoneSuccessfully;

    #region StartUpCompletionCelebration
    public void AllStartStepsDoneOrNot()
    {
        if(isStepOneDone && isStepTwoDone && isStepThreeDone && isStepFourDOne && isStepFiveDOne && isStepSixDone && isStepSevenDone && isStepEightDone &&isStepNineDone && isStepTenDone && isStepElevenDone && isStepTwelveDone && isStepThirteenDone && isStepFourteenDone && isStepFifteenDone && isStepSixteenDone && isStepSeventeenDone)
        {
            StartCoroutine(StartUpCelebration());
            startSetupDoneSuccessfully = true;
            Debug.Log("All Steps Done !");
        }
    }

    IEnumerator StartUpCelebration()
    {
        startUpCompleted.SetActive(true);
        yield return new WaitForSeconds(3f);
        startUpCompleted.SetActive(false);
    }

    #endregion

    #region ShutDown Machine

    public bool shutDownStepOne, shutDownStepTwo, shutDownStepThree, shutDownStepFour, shutDownStepFive, shutDownStepSix, shutDownStepSeven, shutDownStepEight, shutDownStepNine, shutDownStepTen;

    public void ShutDownOneIsDone()
    {

        for (int i = 0; i < shutstepOne.Length; i++)
        {
            int substepdone = 0;
            if (!shutstepOne[i].isDone && startSetupDoneSuccessfully)
            {
                substepdone++;
                Debug.Log("Substep one is done");

            }

            if (substepdone == shutstepOne.Length)
            {
                tabletUI.shutDownStatusImage[0].color = Color.white;
                
                shutDownStepOne = true;
            }
            else
            {
                tabletUI.shutDownStatusImage[0].color = Color.red;
                shutDownStepOne = false;
               
            }
        }
    }
    public void ShutDownTwoIsDone()
    {

        for (int i = 0; i < shutstepTwo.Length; i++)
        {
            int substepdone = 0;
            if (!shutstepTwo[i].isDone && startSetupDoneSuccessfully)
            {
                substepdone++;
                Debug.Log("Substep one is done");

            }

            if (substepdone == shutstepTwo.Length)
            {
                tabletUI.shutDownStatusImage[1].color = Color.white;
                
                shutDownStepTwo = true;
            }
            else
            {
                tabletUI.shutDownStatusImage[1].color = Color.red;
                shutDownStepTwo = false;
                
            }
        }
    }
    public void ShutDownThreeIsDone()
    {

        for (int i = 0; i < shutstepThree.Length; i++)
        {

            for (int substep = 0; substep < shutstepThree.Length; substep++)
            {

                if (!pumbSwitch1.value && startSetupDoneSuccessfully)
                {
                    tabletUI.shutDownStatusImage[2].color = Color.white;
                    
                    shutDownStepThree = true;
                }
                else
                {
                    tabletUI.shutDownStatusImage[2].color = Color.red;
                    shutDownStepThree = false;
                }
            }
        }
    }
    public void ShutDownFourIsDone()
    {

        for (int i = 0; i < shutstepFour.Length; i++)
        {

            for (int substep = 0; substep < shutstepFour.Length; substep++)
            {

                if (!pumbSwitch2.value && startSetupDoneSuccessfully)
                {
                    tabletUI.shutDownStatusImage[3].color = Color.white;
                    
                    shutDownStepFour = true;
                }
                else
                {
                    tabletUI.shutDownStatusImage[3].color = Color.red;
                    shutDownStepFour = false;
                }
            }
        }
    }
    public void ShutDownFiveIsDone()
    {

        for (int i = 0; i < shutstepFive.Length; i++)
        {

            for (int substep = 0; substep < shutstepFive.Length; substep++)
            {

                if (!shutstepTwo[i].isDone && startSetupDoneSuccessfully)
                {
                    tabletUI.shutDownStatusImage[4].color = Color.white;
                    
                    shutDownStepFive = true;
                }
                else
                {
                    tabletUI.shutDownStatusImage[4].color = Color.red;
                    shutDownStepFive = false;
                }
            }
        }
    }
    public void ShutDownSixIsDone()
    {

        for (int i = 0; i < shutstepSix.Length; i++)
        {

            for (int substep = 0; substep < shutstepSix.Length; substep++)
            {

                if (!shutstepSix[i].isDone && startSetupDoneSuccessfully)
                {
                    tabletUI.shutDownStatusImage[5].color = Color.white;
                    
                    shutDownStepSix = true;
                }
                else
                {
                    tabletUI.shutDownStatusImage[5].color = Color.red;
                    shutDownStepSix = false;
                }
            }
        }
    }
    public void ShutDownSevenIsDone()
    {

        for (int i = 0; i < shutstepSeven.Length; i++)
        {

            for (int substep = 0; substep < shutstepSeven.Length; substep++)
            {

                if (!shutstepSeven[i].isDone && startSetupDoneSuccessfully)
                {
                    tabletUI.shutDownStatusImage[6].color = Color.white;
                    
                    shutDownStepSeven = true;
                }
                else
                {
                    tabletUI.shutDownStatusImage[6].color = Color.red;
                    shutDownStepSeven = false;
                }
            }
        }
    }
    public void ShutDownEightIsDone()
    {

        for (int i = 0; i < shutstepEight.Length; i++)
        {

            for (int substep = 0; substep < shutstepEight.Length; substep++)
            {

                if (!shutstepEight[i].isDone && startSetupDoneSuccessfully)
                {
                    tabletUI.shutDownStatusImage[7].color = Color.white;
                    
                    shutDownStepEight = true;
                }
                else
                {
                    tabletUI.shutDownStatusImage[7].color = Color.red;
                    shutDownStepEight = false;
                }
            }
        }
    }
    public void ShutDownNineIsDone()
    {

        for (int i = 0; i < shutstepNine.Length; i++)
        {

            for (int substep = 0; substep < shutstepNine.Length; substep++)
            {

                if (!shutstepNine[i].isDone && startSetupDoneSuccessfully)
                {
                    tabletUI.shutDownStatusImage[8].color = Color.white;
                    
                    shutDownStepNine = true;
                }
                else
                {
                    tabletUI.shutDownStatusImage[8].color = Color.red;
                    shutDownStepNine = false;
                }
            }
        }
    }
    public void ShutDownTenIsDone()
    {

        for (int i = 0; i < shutstepTen.Length; i++)
        {

            for (int substep = 0; substep < shutstepTen.Length; substep++)
            {

                if (!shutstepTen[i].isDone && startSetupDoneSuccessfully)
                {
                    tabletUI.shutDownStatusImage[9].color = Color.white;
                    
                    shutDownStepTen = true;
                }
                else
                {
                    tabletUI.shutDownStatusImage[9].color = Color.red;
                    shutDownStepTen = false;
                }
            }
        }
    }

    public void ShutDown()
    {
        for(int i = 0; i<= tabletUI.shutDownStatusImage.Length; i++)
        {
            tabletUI.shutDownStatusImage[i].color = Color.white;
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
