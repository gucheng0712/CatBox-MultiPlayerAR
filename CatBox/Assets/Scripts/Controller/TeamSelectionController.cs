using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public enum TeamType
{
    Blue,
    Red
}

public class TeamSelectionController : GameManager<TeamSelectionController>
{
    [HideInInspector] public TeamType teamType;

    protected override void Awake()
    {
        base.Awake();
        CreateOrLoadID();
    }

    // Send the picked Team data to the Server
    public void SendJoinedTeamData(TeamType _teamType)
    {
        switch (_teamType)
        {
            case TeamType.Blue:
                SendJoinedTeamData(Model.s_id, TeamSelectionModel.BLUE_TEAM_NAME);
                break;
            case TeamType.Red:
                SendJoinedTeamData(Model.s_id, TeamSelectionModel.RED_TEAM_NAME);
                break;
            default:
                Debug.LogWarning("ERROR: There is no TeamType Named " + teamType);
                break;
        }
    }

    // Overrided Function
    void SendJoinedTeamData(int id, string _teamType)
    {
        string url = TeamSelectionModel.FRONT_REQUEST_URL_LOCAL + "joined/" + id.ToString() + "/" + _teamType;
        StartCoroutine(GetRequestFromWeb(url, "Lobby"));
    }


    void CreateOrLoadID()
    {
        if (PlayerPrefs.HasKey(TeamSelectionModel.KEY))
        {
            Model.s_id = PlayerPrefs.GetInt(TeamSelectionModel.KEY);
            Debug.Log("Loaded the existing ID: " + Model.s_id);
        }
        else
        {
            Model.s_id = System.Guid.NewGuid().GetHashCode();
            Debug.Log("Created a unique ID: " + Model.s_id);
            PlayerPrefs.SetInt(TeamSelectionModel.KEY, Model.s_id);
        }
    }
}
