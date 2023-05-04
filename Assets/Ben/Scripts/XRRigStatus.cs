///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This script helps to enable the teleportaion area in the second scene.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit;

public class XRRigStatus : MonoBehaviour
{
    [SerializeField]
    private bool teleportationOpted;
    [SerializeField]
    private TeleportationArea sceneTeleportArea;
    [SerializeField]
    public CheckXRRigStatus xRRigStatus;


    private void Awake()
    {
        //sceneTeleportArea = GameObject.FindObjectOfType<TeleportationArea>();
        xRRigStatus = GameObject.FindObjectOfType<CheckXRRigStatus>();
        Debug.Log("New Scene Loaded");
    }

    private void Start()
    {
        xRRigStatus.IsTeleportMovementSelected();
        ActivateOrDeactiveteTeleportArea();
    }

    /// <summary>
    /// Method to enable or disable teleportation area in the scene.
    /// </summary>
    public void ActivateOrDeactiveteTeleportArea()
    {
        if (xRRigStatus.teleportMovementStatus)
        {
            teleportationOpted = true;
            sceneTeleportArea.enabled = true;
        }
        else if (!xRRigStatus.teleportMovementStatus)
        {
            teleportationOpted = false;
            sceneTeleportArea.enabled = false;
        }
    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(XRRigStatus))]
public class ClassDescription : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("This script helps to enable the teleportaion area in the second scene. " +
            " \n" + "And this script has to be attache dto the second scene.", GUILayout.MinHeight(50));
        base.OnInspectorGUI();
        
    }
}

#endif