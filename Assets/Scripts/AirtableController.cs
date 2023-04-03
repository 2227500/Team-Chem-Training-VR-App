using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


public class AirtableController : MonoBehaviour
{
    [Header("Scripts")]
    public CreateRecord createRecord;
    public DataCollectionScript dataCollectionScript;

    //tells create record the table name and feeds it the Json string containing the data from the sceneController script, then initiates the createAirtableRecordFunction
    public void CreateGameDataEntry()
    {
        createRecord.TableName = "GameData";
        createRecord.NewRecordJson = "{\"fields\": {" +
                                    "\"TimePlayed\":\"" + dataCollectionScript.playtime + "\", " +
                                    "\"UIResponse\":\"" + dataCollectionScript.UIResponse + "\", " +
                                    "}}";
        createRecord.CreateAirtableRecord();
    }
}
