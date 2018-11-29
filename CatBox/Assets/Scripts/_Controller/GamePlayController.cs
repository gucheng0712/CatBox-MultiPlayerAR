using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : GameManager<GamePlayController>
{

    public bool canScore;

    public bool isLookingAtMarker;

    void Start()
    {
        GameManager_Event.Instance.MarkerCapturedEvent += SendCapturedMarkerData;
    }


    public void ShowMarkControlStatus(string markerControl)
    {
        print(markerControl);
    }



    public void SendCapturedMarkerData(string markerName)
    {
        if (canScore == true)
        {
            string url = GameManager_Data.Instance.model.frontRequestURL + "captured/" + GameManager_Data.Instance.model.ID.ToString() + "/" + markerName;
            StartCoroutine(GetRequestFromWeb(url)); // todo maybe add event
        }
    }

    protected override void EventAfterReceivedData(string s)
    {

    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameManager_Event.Instance.MarkerCapturedEvent -= SendCapturedMarkerData;
    }
}
