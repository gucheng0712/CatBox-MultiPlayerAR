using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : GameManager<LobbyController> {

    [SerializeField] LobbyView m_lobbyView;


	// Use this for initialization
	void Start () {
        GameManager_Event.Instance.OnTimeUpdated += SyncTimeClock;
        GameManager_Event.Instance.OnGameOver += ShowGameOverView;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void SyncTimeClock()
    {
        TimeUpdatedResponse timeUpdatedResponse = GameManager_APIResponses.Instance.timeUpdatedResponse;
        string remainTime = timeUpdatedResponse.RemainingTimeMinutes.ToString() + " : " + timeUpdatedResponse.RemainingTimeSeconds.ToString();
        m_lobbyView.UpdateRemainingTime(remainTime);
    }

    void ShowGameOverView()
    {
        m_lobbyView.gameOverPanel.SetActive(true);
        string winningTeam = GameManager_APIResponses.Instance.gameStatusResponse.winningTeam;
        m_lobbyView.gameOverText.text = winningTeam + " Team Won!";
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameManager_Event.Instance.OnTimeUpdated -= SyncTimeClock;
        GameManager_Event.Instance.OnGameOver -= ShowGameOverView;
    }
}
