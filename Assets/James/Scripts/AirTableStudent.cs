using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AirTableStudent : MonoBehaviour
{
    public string tableName;

    [Header("Scripts")]
    public CreateRecord createRecord;
    public UpdateRecordExample updateRecordExample;

    [Header("Player Name")]
    public TMP_InputField playerNameInputField;
    public TMP_Text playerNameFeedback;
    public string playerName;

    public string bigName;

    [Header("Game Data")]
    public TMP_InputField timePlayedInputField;
    public TMP_InputField scoreInputField;
    public string timePlayed;
    public string score;



    //sets playerName variable to input fields value, then calls custom function from airtable controller
    public void SavePlayerName()
    {
        playerName = playerNameInputField.text;
        //StartCoroutine("LogRecordOnAirtable");
    }

    public void LoadPlayerName()
    {
        StartCoroutine("LoadPlayerNameCoroutine");
    }

    //sets playerName
    public void SavePlayerData()
    {
        playerName = playerNameInputField.text;
    }

    public void LoadPlayerData()
    {
        StartCoroutine("LoadPlayerNameCoroutine");
    }

    //calls custom load info function in airtableController and waits 1 second for response from airtable server before setting playerName to airtable value
    public IEnumerator LoadPlayerNameCoroutine()
    {
        yield return new WaitForSeconds(1f);
        playerNameInputField.text = playerName;
    }

    //sets timePlayed value to what is in the input field (used by inputFields "onEndEdit" event)
    public void UpdateTimePlayedValue()
    {
        timePlayed = timePlayedInputField.text;
    }


    //sets score value to what is in the input field (used by inputFields "onEndEdit" event)
    public void UpdateScoreValue()
    {
        score = scoreInputField.text;
    }

    // Update is called once per frame
    public void LogRecordOnAirtable()
    {
        createRecord.TableName = tableName;
        createRecord.NewRecordJson =
                                    "{\"fields\": {" +
                                    "\"Student Number\":\"" + playerName + "\"" +
                                    "}}";
        createRecord.CreateAirtableRecord();
    }
}
