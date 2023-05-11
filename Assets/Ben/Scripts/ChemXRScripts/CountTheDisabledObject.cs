using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTheDisabledObject : MonoBehaviour
{
    public GameObject[] safetyEquipments;
    public int safetyEquipmentNumber;

    public void ContTheSafetyEquipmentToWear()
    {
        for(int i = 0; i< safetyEquipments.Length; i++)
        {
            if (!safetyEquipments[i].activeInHierarchy)
            {
                safetyEquipmentNumber++;
            }
        }
    }
}
