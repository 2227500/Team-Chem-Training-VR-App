using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class FloatingMeter : MonoBehaviour
{
    public Vector3 vectorYAxis;
    public XRKnob xRKnob;
    
    public float speed = 5f;

    private float previousValue;

    private void Start()
    {
        previousValue = xRKnob.value;
    }

    private void Update()
    {
        float currentValue = xRKnob.value;
        float delta = currentValue - previousValue;
        previousValue = currentValue;

        Vector3 movement = new Vector3(0f, delta, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
