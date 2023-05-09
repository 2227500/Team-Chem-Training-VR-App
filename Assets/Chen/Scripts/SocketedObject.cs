using UnityEngine;
using UnityEngine.Events;

public class SocketedObject : MonoBehaviour
{
    public GameObject stuff;

    private void Start()
    {


    }

    public void SetToFalse()
    {

        stuff.SetActive(false);


    }
}