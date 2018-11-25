using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LobbyController : GameManager<LobbyController>
{
 
    protected override void Awake()
    {
        base.Awake();
        CreateOrLoadID();
    }

    public void SendJoinedTeamData(int id, string teamType)
    {
        StartCoroutine(GetRequestFromWeb(LobbyModel.FRONT_JOINREQUEST_URL + id.ToString() + "/" + teamType));
    }

    void CreateOrLoadID()
    {
        if (PlayerPrefs.HasKey(LobbyModel.KEY))
        {
            Model.s_id = PlayerPrefs.GetInt(LobbyModel.KEY);
            Debug.Log("Loaded the existing ID: " + Model.s_id);
        }
        else
        {
            Model.s_id = System.Guid.NewGuid().GetHashCode();
            Debug.Log("Created a unique ID: " + Model.s_id);
            PlayerPrefs.SetInt(LobbyModel.KEY, Model.s_id);
        }
    }
}
