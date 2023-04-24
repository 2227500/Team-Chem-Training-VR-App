using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AirTableTime : MonoBehaviour
{
    public string tableName;

    [Header("Scripts")]
    public CreateRecord createRecord;
    public UpdateRecordExample updateRecordExample;

    public string bigName;

    [Header("Game Data")]
    public string timePlayed;

    public float timeValue = 0.0f;
    public TextMeshProUGUI timePlayedInputField;

    private bool timerRunning = false;


    void Update()
    {
        if (timerRunning)
        {
            timeValue += Time.deltaTime;
            timePlayedInputField.text = "Time: " + timeValue.ToString("f2");
        }
    }

    public void ToggleTimer()
    {
        timerRunning = !timerRunning;
    }


    //sets playerName variable to input fields value, then calls custom function from airtable controller
    public void SavePlayerTime()
    {
        timePlayed = timePlayedInputField.text;
        StartCoroutine("LogRecordOnAirtable");
    }

    public void LoadPlayerTime()
    {
        StartCoroutine("LoadPlayerNameCoroutine");
    }

    //sets playerName
    public void SavePlayerData()
    {
        timePlayed = timePlayedInputField.text;
    }

    //sets timePlayed value to what is in the input field (used by inputFields "onEndEdit" event)
    public void UpdateTimePlayedValue()
    {
        timePlayed = timePlayedInputField.text;
    }

    public void LoadPlayerData()
    {
        StartCoroutine("LoadPlayerTimeCoroutine");
    }

    //calls custom load info function in airtableController and waits 1 second for response from airtable server before setting playerName to airtable value
    public IEnumerator LoadPlayerTimeCoroutine()
    {
        yield return new WaitForSeconds(1f);
        timePlayedInputField.text = timePlayed;
    }


    // Update is called once per frame
    public void LogRecordOnAirtable()
    {
        createRecord.TableName = tableName;
        createRecord.NewRecordJson =
                                    "{\"fields\": {" +
                                    "\"Student Time\":\"" + timePlayed + "\"" +
                                    "}}";
        createRecord.CreateAirtableRecord();
    }
}