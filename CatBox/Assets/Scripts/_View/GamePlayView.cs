using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayView : MonoBehaviour
{

    public void OnBackMainSceneBtnPressed()
    {
        SceneManager.LoadScene("Lobby");
    }

    #region Btn Events For testing

    public void OnBlackCapturedPressed(Button btn)
    {
        CaptureMarker(btn, GameManager_APIResponses.Instance.timeUpdatedResponse.marker01Control);
    }

    public void OnBlueCapturedPressed(Button btn)
    {
        CaptureMarker(btn, GameManager_APIResponses.Instance.timeUpdatedResponse.marker02Control);
    }

    public void OnBrownCapturedPressed(Button btn)
    {
        CaptureMarker(btn, GameManager_APIResponses.Instance.timeUpdatedResponse.marker03Control);
    }

    public void OnPinkCapturedPressed(Button btn)
    {
        CaptureMarker(btn, GameManager_APIResponses.Instance.timeUpdatedResponse.marker04Control);
    }

    public void OnYellowCapturedPressed(Button btn)
    {
        CaptureMarker(btn, GameManager_APIResponses.Instance.timeUpdatedResponse.marker05Control);
    }

    void CaptureMarker(Button btn, string markerControl)
    {
        GamePlayController.Instance.StartCountDown();
        GamePlayController.Instance.ShowMarkControlStatus(markerControl);
        if (GamePlayController.Instance.isCountingDown == false)
        {
            GamePlayController.Instance.CheckMarkerControlStatus(markerControl);

            string markerID = btn.gameObject.GetComponentInChildren<Cat>().catModel.imageTargetID;
            GameManager_Event.Instance.MarkerCaptured(markerID);
        }
    }

    #endregion
}
