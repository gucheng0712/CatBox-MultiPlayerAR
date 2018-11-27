using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeamType
{
    Blue = 0,
    Red = 1
}

/// <summary>
/// Data for the Game Lobby
/// </summary>
[System.Serializable]
public class TeamSelectionModel
{
    public const string TEAM_KEY = "Team";

    //public const string FRONT_REQUEST_URL = "http://localhost:8005/
    public const string BLUE_TEAM_NAME = "BLUE";
    public const string RED_TEAM_NAME = "RED";


    [SerializeField] TeamType m_teamType; // 0 --> BLUE   1 --> RED
    public TeamType TeamType { get { return m_teamType; } set { m_teamType = value; } }
}
