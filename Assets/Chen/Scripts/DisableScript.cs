using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableScript : MonoBehaviour
{
    public GameObject attach;

    private void Start()
    {
        
    }

    public void DisableMyScript()
    {
       attach.SetActive(false);
    }
}
