using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTheDisabledObject : MonoBehaviour
{
    public GameObject[] safetyEquipments;

    public GameObject restrictor;
    public int safetyEquipmentNumber;


    private void Update()
    {
        ContTheSafetyEquipmentToWear();
    }

    public void ContTheSafetyEquipmentToWear()
    {
        foreach(GameObject equip in safetyEquipments)
        {

            if (!equip.activeInHierarchy)
            {

                safetyEquipmentNumber++;
            }
        }

        if(safetyEquipmentNumber >= safetyEquipments.Length)
        {
            restrictor.SetActive(false);
        }
        else if(safetyEquipmentNumber <= safetyEquipments.Length)
        {
            restrictor.SetActive(true);
        }
    }
}
