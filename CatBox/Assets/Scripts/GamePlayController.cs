using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : GameManager<GamePlayController>
{
    public void SendCapturedMarkerData(int id, string markerName)
    {
        StartCoroutine(GetRequestFromWeb(LobbyModel.FRONT_REQUEST_URL+ "captured/" + id.ToString() + "/" + markerName));
    }

}
