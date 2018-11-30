using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayView : MonoBehaviour
{
    [HideInInspector] public Slider openBoxProgressBar;
    [HideInInspector]  GameObject backBtnGO;
    [HideInInspector]  GameObject markerCaptureNotifyPanel;
    [HideInInspector]  Text markerCaptureNotify;

    private void Start()
    {
        backBtnGO = transform.Find("BackToMainSceneBtn").gameObject;
        openBoxProgressBar = GetComponentInChildren<Slider>();
        markerCaptureNotifyPanel = transform.Find("MarkerCaptureNotifyPanel").gameObject;
        markerCaptureNotify = markerCaptureNotifyPanel.transform.Find("NotifyText").GetComponent<Text>();
        markerCaptureNotifyPanel.SetActive(false); // Initialize as invisible
    }



    public void OnStayBtnPressed()
    {
        markerCaptureNotifyPanel.SetActive(false);
        backBtnGO.SetActive(true);
    }

    public void OnBackMainSceneBtnPressed()
    {
        SceneManager.LoadScene("Lobby");
    }


    public void ShowCaptureNeutralCatMsg()
    {
        StartCoroutine(CaptureNeutralCatRoutine());
    }
    public IEnumerator CaptureNeutralCatRoutine()
    {
        yield return new WaitForSeconds(3f);
        markerCaptureNotifyPanel.SetActive(true);
        backBtnGO.SetActive(false);
        markerCaptureNotify.text = "You Adopt a Homeless Cat! You are a Good Person";
    }

    public void ShowCaptureSameTeamCatMsg()
    {
        StartCoroutine(CaptureSameTeamCatRoutine());
    }
    public IEnumerator CaptureSameTeamCatRoutine()
    {
        yield return new WaitForSeconds(3f);
        markerCaptureNotifyPanel.SetActive(true);
        backBtnGO.SetActive(false);
        markerCaptureNotify.text = "This is Your Friend's Cat! You can't Take It";
    }

    public void ShowCaptureOppositeTeamCatMsg()
    {
        StartCoroutine(CaptureOppositeTeamCatMsgRoutine());
    }
     IEnumerator CaptureOppositeTeamCatMsgRoutine()
    {
        yield return new WaitForSeconds(3f);
        markerCaptureNotifyPanel.SetActive(true);
        backBtnGO.SetActive(false);
        markerCaptureNotify.text = "You Rescued the Kitty from a Evil Organization!";
    }
}
