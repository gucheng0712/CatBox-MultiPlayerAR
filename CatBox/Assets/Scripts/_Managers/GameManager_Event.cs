using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Event : GameManager<GameManager_Event>
{
    public delegate void MarkerCapturedEventHandler(string marker);
    public event MarkerCapturedEventHandler MarkerCapturedEvent;

    public delegate void GameOverEventHandler();
    public event GameOverEventHandler GameOverEvent;

    public void MarkerCaptured(string markerStatus)
    {
        if (MarkerCapturedEvent != null)
        {
            MarkerCapturedEvent(markerStatus);
        }
    }


    public void GameOver()
    {
        if (GameOverEvent != null)
        {
            GameManager_Data.Instance.model.IsGameOverFlag = true;
            GameOverEvent();
        }
    }
}
