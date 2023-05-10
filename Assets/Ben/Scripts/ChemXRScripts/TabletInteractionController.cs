using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletInteractionController : MonoBehaviour
{

    public GameObject gameObjectToDisable;
    [SerializeField]
    private int numberOfTimesCollided;

    private void Start()
    {

        gameObjectToDisable.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            gameObjectToDisable.SetActive(true);


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObjectToDisable.SetActive(false);
        }
    }
}
