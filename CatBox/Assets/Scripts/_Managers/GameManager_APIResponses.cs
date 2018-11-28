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

    public SDictionaryOfStringAndPlayerStatus playersThisRound = new SDictionaryOfStringAndPlayerStatus();



    public void CheckPlayerStatus()
    {
        string url = GameManager_Data.Instance.model.frontRequestURL + "players/";
        StartCoroutine(GetRequestFromWeb(url));
    }

    protected override void EventAfterReceivedData(string s)
    {
        playersThisRound = JsonMapper.ToObject<SDictionaryOfStringAndPlayerStatus>(s);
    }


}



