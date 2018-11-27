using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using LitJson;

[System.Serializable]
public class PlayerStatus
{
    public string team;
    public int score;
}

[System.Serializable]
public class TimeUpdatedResponse
{
    public int RemainingTimeMinutes;
    public int RemainingTimeSeconds;

    public string marker01Control;
    public string marker02Control;
    public string marker03Control;
    public string marker04Control;
    public string marker05Control;
}

[System.Serializable]
public class MarkerCaptureDataResponse
{
    public string captured;
    public string capturedByTeam;
    public string capturedByPlayer;
    public int capturedTimeHours;
    public int capturedTimeMinutes;
    public int capturedTimeSeconds;
}

[System.Serializable]
public class GameStatusResponse
{
    public string status;
    public string winningTeam;
    public string highScorePlayer;
    public int highScorePlayerScore;
}

public class GameManager_APIResponses : GameManager<GameManager_APIResponses>
{
    public TimeUpdatedResponse timeUpdatedResponse;
    public MarkerCaptureDataResponse markerCaptureDataResponse;
    public GameStatusResponse gameStatusResponse;

    public Dictionary<string, PlayerStatus> playersThisRound = new Dictionary<string, PlayerStatus>();

    public bool finishCheckIfPlayerHasJoinedTeam;


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(GetRequestFromWeb("http://ar.pixels-pixels.com/players"));
        }
    }

    public void CheckIfHasJoinedTeam()
    {
        string url = Model.FRONT_REQUEST_URL_LOCAL + "players/";
        StartCoroutine(GetRequestFromWeb(url));
    }


    protected override void EventAfterReceivedData(string s)
    {
        playersThisRound = JsonMapper.ToObject<Dictionary<string, PlayerStatus>>(s);
        //foreach (var item in playersThisRound)
        //{
        //    print(item.Key);
        //}

        if (playersThisRound.ContainsKey(GameManager_Data.Instance.model.ID.ToString()))
        {
            Debug.Log("Player Has already joined the team");
            GameManager_Data.Instance.HasJoinedTeam = true;
        }
        else
        {
            Debug.Log("Player hasn't joined the team");
            PlayerPrefs.DeleteKey(TeamSelectionModel.TEAM_KEY);
            GameManager_Data.Instance.HasJoinedTeam = false;
        }

        SceneManager.LoadScene("TeamSelection");
    }


}


