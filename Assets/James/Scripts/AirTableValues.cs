using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTableValues : MonoBehaviour
{
    public void LoadPlayerData()
    {
        StartCoroutine("LoadPlayerNameCoroutine");
    }
    //calls custom load info function in airtableController and waits 1 second for response from airtable server before setting playerName to airtable value
    public IEnumerator LoadPlayerNameCoroutine()
    {
        airtableController.LoadPlayerInfo();
        yield return new WaitForSeconds(1f);
        playerNameInputField.text = playerName;
    }
}
