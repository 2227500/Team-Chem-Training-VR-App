using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirtableManager : MonoBehaviour
{
    public CreateRecord createRecord;

    public string tableName;

    public string dummyStringOne;
    public string dummyStringTwo;
    public string dummyStringThree;



    public void LogRecordOnAirtable()
    {
        createRecord.TableName = tableName;
        createRecord.NewRecordJson = 
                                    "{\"fields\": {" +
                                    "\"Dummy Info 1\":\"" + dummyStringOne + "\", " +
                                    "\"Dummy Info 2\":\"" + dummyStringTwo + "\", " +
                                    "\"Dummy Info 3\":\"" + dummyStringThree + "\"" +
                                    "}}";
        createRecord.CreateAirtableRecord();
    }
}
