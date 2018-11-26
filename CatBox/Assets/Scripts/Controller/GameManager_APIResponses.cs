using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

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

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // Check timeUpdateData
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PrintTimeUpdateData(timeUpdatedResponse);
        }

        // Check game status in gameplay
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PrintMarkerCaptureData(markerCaptureDataResponse);
        }

        // Check GameStatus game end
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PrintGameOverStatus(gameStatusResponse);
        }



    }

    public void PrintTimeUpdateData(TimeUpdatedResponse res)
    {

        Debug.Log("RemainingTimeMinutes: " + res.RemainingTimeMinutes);
        Debug.Log("RemainingTimeSeconds: " + res.RemainingTimeMinutes);
        Debug.Log("marker01Control: " + res.marker01Control);
        Debug.Log("marker02Control: " + res.marker02Control);
        Debug.Log("marker03Control: " + res.marker03Control);
        Debug.Log("marker04Control: " + res.marker04Control);
        Debug.Log("marker05Control: " + res.marker05Control);
    }

    public void PrintMarkerCaptureData(MarkerCaptureDataResponse res)
    {
        Debug.Log("Captured: " + res.captured);
        Debug.Log("CaptureTeam: " + res.capturedByTeam);
        Debug.Log("CapturedPlayer: " + res.capturedByPlayer);
        Debug.Log("CapturedTimeHours: " + res.capturedTimeHours);
        Debug.Log("CapturedTimeMinutes: " + res.capturedTimeMinutes);
        Debug.Log("CapturedTimeSeconds: " + res.capturedTimeSeconds);

    }

    public void PrintGameOverStatus(GameStatusResponse res)
    {
        Debug.Log("status: " + res.status);
        Debug.Log("winningTeam: " + res.winningTeam);
        Debug.Log("status: " + res.highScorePlayer);
        Debug.Log("status: " + res.highScorePlayerScore);
    }
}


