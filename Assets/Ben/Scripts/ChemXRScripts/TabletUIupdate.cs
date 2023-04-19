using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Content.Interaction;

public class TabletUIupdate : MonoBehaviour
{
    public XRKnob[] xrKnob;
    public Image[] fullyOpenImage;

    private void Update()
    {
        KnobStatus();
    }


    public void KnobStatus()
    {
        for (int i = 0; i < xrKnob.Length; i++)
        {
            XRKnob xrknobvar = xrKnob[i].GetComponent<XRKnob>();

            if (xrknobvar.value >= 0.9f)
            {
                fullyOpenImage[i].color = Color.white;
            }
            else if(xrknobvar.value >= 0.45f && xrknobvar.value <= 0.55f)
            {
                fullyOpenImage[i].color = Color.yellow;
            }
            else if(xrknobvar.value < 0.45f)
            {
                fullyOpenImage[i].color = Color.red;
            }
        }
    }
}
