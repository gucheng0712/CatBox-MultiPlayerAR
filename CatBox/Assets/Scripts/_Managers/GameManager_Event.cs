using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Event : GameManager<GameManager_Event>
{
    public delegate void MarkerCapturedEventHandler(string marker);
    public event MarkerCapturedEventHandler OnMarkerCaptured;

    public delegate void TimeUpdatedEventHandler();
    public event TimeUpdatedEventHandler OnTimeUpdated;

    public delegate void GameOverEventHandler();
    public event GameOverEventHandler OnGameOver;

    public void MarkerCapturedEvents(string markerStatus)
    {
        if (OnMarkerCaptured != null)
        {
            OnMarkerCaptured(markerStatus);
        }
    }

    public void TimeUpdatedEvents()
    {
        if (OnTimeUpdated != null)
        {
            OnTimeUpdated();
        }
    }

    public void GameOverEvents()
    {
        if (OnGameOver != null)
        {
            GameManager_Data.Instance.model.IsGameOverFlag = true;
            OnGameOver();
        }
    }
}
