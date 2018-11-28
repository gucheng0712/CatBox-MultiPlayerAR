using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using LitJson;



public class TeamSelectionController : GameManager<TeamSelectionController>
{
    private void Start()
    {
        LoadTeam();
    }


    public void SendPlayerStatusData()
    {
        string url = GameManager_Data.Instance.model.frontRequestURL + "players/";
        StartCoroutine(GetRequestFromWeb(url));
    }

    // Send the picked Team data to the Server
    public void SendJoinedTeamData(TeamType _teamType)
    {
        SaveTeam();
        switch (_teamType)
        {
            case TeamType.Blue:
                SendJoinedTeamData(GameManager_Data.Instance.model.ID, TeamSelectionModel.BLUE_TEAM_NAME);
                break;
            case TeamType.Red:
                SendJoinedTeamData(GameManager_Data.Instance.model.ID, TeamSelectionModel.RED_TEAM_NAME);
                break;
            default:
                Debug.LogWarning("ERROR: There is no TeamType Named " + GameManager_Data.Instance.model.teamSelectionModel.TeamType);
                break;
        }
    }

    // Overrided Function
    void SendJoinedTeamData(int id, string _teamType)
    {
        string url = GameManager_Data.Instance.model.frontRequestURL + "joined/" + id.ToString() + "/" + _teamType;
        StartCoroutine(GetRequestFromWeb(url));
    }

    protected override void EventAfterReceivedData(string s)
    {
        GameManager_APIResponses.Instance.CheckPlayerStatus();// Check player status after join a game
        SceneManager.LoadScene("Lobby");
    }

    void LoadTeam()
    {
        if (PlayerPrefs.HasKey(TeamSelectionModel.TEAM_KEY))
        {
            GameManager_Data.Instance.model.teamSelectionModel.TeamType = (TeamType)PlayerPrefs.GetInt(TeamSelectionModel.TEAM_KEY);
            Debug.Log("Loaded the existing TeamType: " + GameManager_Data.Instance.model.teamSelectionModel.TeamType);
        }

    }

    void SaveTeam()
    {
        Debug.Log("Save Team: " + GameManager_Data.Instance.model.teamSelectionModel.TeamType);
        PlayerPrefs.SetInt(TeamSelectionModel.TEAM_KEY, (int)GameManager_Data.Instance.model.teamSelectionModel.TeamType);
    }

}
