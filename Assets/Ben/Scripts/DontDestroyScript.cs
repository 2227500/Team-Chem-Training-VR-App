///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This scripts keeps the gameobject loaded to next scene.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    // Do not detstroy the gameobject attached with this object
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


}
