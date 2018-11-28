using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public class StartMenuController : GameManager<StartMenuController>
{
    public bool finishCheckIfPlayerHasJoinedTeam;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(GetRequestFromWeb("http://ar.pixels-pixels.com/players"));
        }
    }

    public void CheckIfJoinedTeam()
    {
        string url = GameManager_Data.Instance.model.frontRequestURL + "players/";
        StartCoroutine(GetRequestFromWeb(url));
    }

    protected override void EventAfterReceivedData(string s)
    {

        if (!finishCheckIfPlayerHasJoinedTeam)
        {
            GameManager_APIResponses.Instance.playersThisRound = JsonMapper.ToObject<SDictionaryOfStringAndPlayerStatus>(s);
            //foreach (var item in playersThisRound)
            //{
            //    print(item.Key);
            //}
            if (GameManager_APIResponses.Instance.playersThisRound.ContainsKey(GameManager_Data.Instance.model.ID.ToString()))
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
            finishCheckIfPlayerHasJoinedTeam = true;
        }


    }


}
