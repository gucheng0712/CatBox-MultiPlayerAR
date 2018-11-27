using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ModelToCollectTheData
[System.Serializable]
public class Model
{
    public const string ID_KEY = "ID";
    public const string FRONT_REQUEST_URL = "http://ar.pixels-pixels.com/";
    public const string FRONT_REQUEST_URL_LOCAL = "http://localhost:8000/";

    [SerializeField] int m_id;
    public int ID { get { return m_id; } set { m_id = value; } } //User Id

    [SerializeField] string m_userName; // Give Player A Name to show at the end of the game
    public string UserName { get { return m_userName; } set { m_userName = value; } }

    [SerializeField] string m_dataFromWeb; // the data received from the webRequest
    public string DataFromWeb { get { return m_dataFromWeb; } set { m_dataFromWeb = value; } }

    [SerializeField] int m_isGameOverFlag; // 0 --> false   1 --> true
    public int IsGameOverFlag { get { return m_isGameOverFlag; } set { m_isGameOverFlag = value; } }

    public TeamSelectionModel teamSelectionModel;

    public Model()
    {
        teamSelectionModel = new TeamSelectionModel();
    }


}
