using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : GameManager<GamePlayController>
{
    public void SendCapturedMarkerData(int id, string markerName)
    {
        StartCoroutine(GetRequestFromWeb(TeamSelectionModel.FRONT_REQUEST_URL_LOCAL + "captured/" + id.ToString() + "/" + markerName));
    }

}
