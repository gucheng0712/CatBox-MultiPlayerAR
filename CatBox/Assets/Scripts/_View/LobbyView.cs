using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyView : MonoBehaviour
{
    [HideInInspector] public Text remainingTimeText;
    [HideInInspector] public RectTransform bgTrans;
    [HideInInspector] public GameObject gameOverPanel;
    [HideInInspector] public Text gameOverText; 

    private void Start()
    {
        remainingTimeText = transform.Find("TimeRemainingText").GetComponent<Text>();
        bgTrans = transform.Find("BG").GetComponent<RectTransform>();
        gameOverPanel = transform.Find("GameOverPanel").gameObject;
        gameOverText = gameOverPanel.transform.Find("GameOverText").GetComponent<Text>();
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        // todo move scale the map through touch control
    }


    public void OnScanBtnPressed()
    {
        SceneManager.LoadScene("AR-GamePlay");
        // SceneManager.LoadScene("AR-GamePlay");
    }

    public void OnGameOverBtnPressed()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void UpdateRemainingTime(string remainTime)
    {
        remainingTimeText.text = remainTime;
    }
}
