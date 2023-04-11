using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGuide : MonoBehaviour
{
    public Transform targetObject;
    public float arrowDistance = 1f;
    public float arrowSize = 0.1f;

    private Transform cameraTransform;
    private Vector3 arrowOffset;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        arrowOffset = new Vector3(0, -1f, arrowDistance);
    }

    void LateUpdate()
    {
        Vector3 targetPosition = targetObject.position;
        targetPosition.y += arrowSize / 2;
        transform.position = cameraTransform.position + arrowOffset;
        transform.LookAt(targetPosition);
    }
}

