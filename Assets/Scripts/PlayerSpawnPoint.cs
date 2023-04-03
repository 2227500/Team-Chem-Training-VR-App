///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This scripts spawns gameobject to the position of the gameobject attached with this script.

using UnityEngine;
using System;
using System.Collections;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject player;
 

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        player.GetComponent<Transform>().position = gameObject.transform.position;
    }


}

