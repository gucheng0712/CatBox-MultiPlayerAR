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

public class LobbyController : GameManager<LobbyController>
{
    public TeamType teamType;

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
                SendJoinedTeamData(Model.s_id, LobbyModel.BLUE_TEAM_NAME);
                break;
            case TeamType.Red:
                SendJoinedTeamData(Model.s_id, LobbyModel.RED_TEAM_NAME);
                break;
            default:
                Debug.LogWarning("ERROR: There is no TeamType Named " +teamType);
                break;
        }
    }
    
    // Overrided Function
    void SendJoinedTeamData(int id, string teamType)
    {
        StartCoroutine(GetRequestFromWeb(LobbyModel.FRONT_REQUEST_URL +"joined/"+ id.ToString() + "/" + teamType));
    }

    protected override IEnumerator GetRequestFromWeb(string url)
    {
        // Create UnityWebRequest and give it the url 
        UnityWebRequest uwr = UnityWebRequest.Get(url);

        yield return uwr.SendWebRequest();

        // Check if has error
        if (uwr.isNetworkError)
        {
            Debug.Log("Error: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            dataFromWeb = uwr.downloadHandler.text;
        }
        SceneManager.LoadScene("MainGame");
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
