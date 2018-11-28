using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : GameManager<GamePlayController>
{

    public bool canScore;

    public float currentTime;
    public bool isCountingDown;

    void Start()
    {
        GameManager_Event.Instance.MarkerCapturedEvent += SendCapturedMarkerData;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCountDown();
        }

        if (isCountingDown == true)
        {
            CountDown(5);
        }

    }

    public void StartCountDown()
    {
        currentTime = Time.time;
        isCountingDown = true;
    }

    void CountDown(float cd)
    {
        if ((Time.time - currentTime) > cd)
        {
            currentTime = Time.time;
            isCountingDown = false;
            print("finishCountdown");
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameManager_Event.Instance.MarkerCapturedEvent -= SendCapturedMarkerData;
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

    public void ShowMarkControlStatus(string markerControl)
    {
        print(markerControl);
    }

    public void CheckMarkerControlStatus(string markerControl)
    {
        string team = GameManager_APIResponses.Instance.playersThisRound[GameManager_Data.Instance.model.ID.ToString()].team;

        switch (markerControl)
        {
            case "NEUTRAL":
                // Scanned a neutral marker
                print("Scanned a neutral marker");
                canScore = true;
                break;
            case "BLUE":
                if (team == "BLUE")
                {
                    // Scanned a marker that already belongs to this Team.
                    print(" Scanned a marker that already belongs to this Team.");
                    canScore = false;
                }
                else if (team == "RED")
                {
                    //Scanned a marker that belongs to opposing team.
                    print(" Scanned a marker that belongs to opposing team.");
                    canScore = true;
                }
                break;
            case "RED":
                if (team == "RED")
                {
                    canScore = false;
                    // Scanned a marker that already belongs to this Team.
                    print(" Scanned a marker that already belongs to this Team.");
                }
                else if (team == "BLUE")
                {
                    canScore = true;
                    //Scanned a marker that belongs to opposing team.
                    print(" Scanned a marker that belongs to opposing team.");
                }
                break;
            default:
                break;
        }
    }


}
