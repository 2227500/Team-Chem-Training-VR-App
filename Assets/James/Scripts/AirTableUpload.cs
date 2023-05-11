using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class AirTableUpload : MonoBehaviour
{
    public string tableName;

    [Header("Scripts")]
    public CreateRecord createRecord;
    public UpdateRecordExample updateRecordExample;

    public AirTableStudent student;
    public AirTableTime time;
    public ChemQuiz quiz;
    public HeatExchangerController values;

    public void LogRecordOnAirtable()
    {
        createRecord.TableName = tableName;
        createRecord.NewRecordJson =
                                    "{\"fields\": {" +
                                    "\"Student\":\"" + student.playerName + "\", " +
                                    "\"Time\":\"" + time.timePlayed + "\", " +
                                    "\"Quiz\":\"" + quiz.score + "\", " +
                                    "\"ValuesIn\":\"" + values.waterTemperatureInE1 + "\"" +
                                    "\"ValuesOut\":\"" + values.waterTemperatureOutE1 + "\"" +
                                    "\"ValuesLFlow\":\"" + values.concLiquidFlowRate + "\"" +
                                    "\"ValuesWFlow\":\"" + values.condensedWaterFlowRate + "\"" +
                                    "}}";
        createRecord.CreateAirtableRecord();
    }

    //sets the table we want to look at, then request all the data from that table
    //public void ListAllEntries()
    //{
    //    listRecords.TableName = "Experiment";
    //    listRecords.GetAirtableTableRecords();
    //}
}
