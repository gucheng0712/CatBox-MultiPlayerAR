using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : GameManager<GamePlayController>
{
    public bool canScore;
    public bool isCountingDown;
    public bool canOpenBox;

    public GamePlayView gamePlayView;
    float coolDown = 5f;
    float oneOverCoolDown;
    float currentTime;
    
    public Color blueColor =  new Color(0,151,255,255);
    public Color redColor = new Color(255,73,79,255);
    public Color neutralColor =  new Color(255,255,255,255);

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        GameManager_Event.Instance.OnMarkerCaptured += SendCapturedMarkerData;
        oneOverCoolDown = 1 / coolDown; // because division is more expensive so preset it, for slider constant update value
    }

    void Update()
    {
        if (isCountingDown)
        {
            currentTime += Time.deltaTime;
            gamePlayView.openBoxProgressBar.value = currentTime * oneOverCoolDown; 
            if (currentTime > coolDown)
            {
                isCountingDown = false;
                canOpenBox = true;
            }
        }
    }

    public void ResetCountDownTime()
    {
        isCountingDown = false;
        currentTime = 0f;
        gamePlayView.openBoxProgressBar.value = 0;
    }

    // Send the Captured marker to server, increase the score(in server)
    public void SendCapturedMarkerData(string markerName)
    {
        if (canScore == true)
        {
            string url = GameManager_Data.Instance.model.frontRequestURL + "captured/" + GameManager_Data.Instance.model.ID.ToString() + "/" + markerName;
            StartCoroutine(GetRequestFromWeb(url));
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
       // GameManager_Event.Instance.OnMarkerCaptured -= SendCapturedMarkerData;
    }
}
