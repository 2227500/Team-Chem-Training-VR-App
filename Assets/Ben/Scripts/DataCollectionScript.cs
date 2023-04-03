using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollectionScript : MonoBehaviour
{

    public float playtime;
    public string UIResponse;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playtime += Time.deltaTime;

    }

    public void Yes()
    {
        UIResponse = "Yes";
    }

    public void No()
    {
        UIResponse = "No";
    }
}
