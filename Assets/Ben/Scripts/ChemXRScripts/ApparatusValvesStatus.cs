using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ApparatusValvesStatus : MonoBehaviour
{
    public XRKnob[] knobStatus;
    public XRPushButton[] pushButtonStatus;
    //public XRLever[] leverStatus;
    public bool isValveFullyOpen;

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
        KnobStatus();
    }

    
    public void KnobStatus()
    {
        for (int i = 0; i < knobStatus.Length; i++)
        {
            XRKnob xrknob = knobStatus[i].GetComponent<XRKnob>();

            if (xrknob.value >=0.9f)
            {
                isValveFullyOpen = true;
            }
        }
    }
}
