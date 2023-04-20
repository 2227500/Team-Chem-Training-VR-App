using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ApparatusValvesStatus : MonoBehaviour
{
    public XRKnob[] knobStatus;
    public XRPushButton[] pushButtonStatus;
    //public XRLever[] leverStatus;


    //[SerializeField]
    //private List<bool> leversBoolValue;
    [SerializeField]
    private List<float> knobValue;

    private void Start()
    {
        //leversBoolValue = new List<bool>();
    }
    private void Update()
    {
        //LeverStatus();
        KnobStatus();
    }

    //public void LeverStatus()
    //{
    //    for(int i = 0; i<leverStatus.Length; i++)
    //    {
    //        XRLever xrlever = leverStatus[i].GetComponent<XRLever>();

    //        if(xrlever != null)
    //        {
    //            //Debug.Log("Status of each lever " + i + xrlever.value);
    //            //leversBoolValue.Add(xrlever.value);
    //            if(i <= leverStatus.Length)
    //            {
    //                Debug.Log("Levers in scene: " + xrlever.name);
    //                leversBoolValue.Add(xrlever.value);
                    
    //            }
    //        }
            
    //    }
    //}
    
    public void KnobStatus()
    {
        for (int i = 0; i < knobStatus.Length; i++)
        {
            XRKnob xrknob = knobStatus[i].GetComponent<XRKnob>();

            if (xrknob != null)
            {
                Debug.Log("Status of each lever " + i + xrknob.value);
                knobValue.Add(xrknob.value);
            }
        }
    }
}
