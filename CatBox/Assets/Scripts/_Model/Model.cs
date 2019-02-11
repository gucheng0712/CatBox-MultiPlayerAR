using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ModelToCollectTheData
[System.Serializable]
public class Model
{
    public const string ID_KEY = "ID";
    //public const string FRONT_REQUEST_URL = "http://ar.pixels-pixels.com/";
    public string frontRequestURL = "http://127.0.0.1:8000/";

    [SerializeField] int m_id;// User Id
    public int ID { get { return m_id; } set { m_id = value; } }

    [SerializeField] string m_userName; // Give Player A Name to show at the end of the game, and when capture the marker
    public string UserName { get { return m_userName; } set { m_userName = value; } }

    [SerializeField] string m_dataFromWeb; // the data received from the webRequest
    public string DataFromWeb { get { return m_dataFromWeb; } set { m_dataFromWeb = value; } }

    [SerializeField] bool m_isGameOverFlag;
    public bool IsGameOverFlag { get { return m_isGameOverFlag; } set { m_isGameOverFlag = value; } }

    public TeamSelectionModel teamSelectionModel;

    public Model()
    {
        teamSelectionModel = new TeamSelectionModel();
    }


}
