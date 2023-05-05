using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public GameObject[] objectsToChange;

    private List<Renderer> renderersToChange;

    void Start()
    {
        renderersToChange = new List<Renderer>();
        foreach (GameObject obj in objectsToChange)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderersToChange.Add(renderer);
            }
        }
    }

    public void ChangeMaterial()
    {
        foreach (Renderer renderer in renderersToChange)
        {
            renderer.material.color = Color.magenta;
        }
    }
}