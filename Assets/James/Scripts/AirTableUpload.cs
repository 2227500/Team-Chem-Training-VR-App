using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
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
    public AirTableBring number;

    //public Keyboard studnetNumber;
   

    public void LogRecordOnAirtable()
    {
        createRecord.TableName = "Student Table";
        createRecord.NewRecordJson =
                                    "{\"fields\": {" +
                                    //"\"Student\":\"" + student.playerName + "\", " +
                                    "\"Student\":\"" + number.studentNumber + "\", " +

                                    "\"Time\":\"" + time.timePlayed + "\", " +
                                    "\"Quiz\":\"" + quiz.score + "\", " +
                                    "\"ValuesIn\":\"" + values.waterTemperatureInE1 + "\", " +
                                    "\"ValuesOut\":\"" + values.waterTemperatureOutE1 + "\", " +
                                    "\"ValuesLFlow\":\"" + values.concLiquidFlowRate + "\", " +
                                    "\"ValuesWFlow\":\"" + values.condensedWaterFlowRate + "\"" +
                                    "}}";
        createRecord.CreateAirtableRecord();
    }

}
