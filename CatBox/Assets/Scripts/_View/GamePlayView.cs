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
    public void OnBlueCapturedPressed(Button btn)
    {
        //todo check if this marker has already been captured by other team
        string markerID = btn.gameObject.GetComponentInChildren<Cat>().catModel.imageTargetID;
        GamePlayController.Instance.SendCapturedMarkerData(GameManager_Data.Instance.model.ID, markerID);
    }
    public void OnPinkCapturedPressed(Button btn)
    {
        //todo check if this marker has already been captured by other team
        string markerID = btn.gameObject.GetComponentInChildren<Cat>().catModel.imageTargetID;
        GamePlayController.Instance.SendCapturedMarkerData(GameManager_Data.Instance.model.ID, markerID);

    }
    public void OnBrownCapturedPressed(Button btn)
    {
        //todo check if this marker has already been captured by other team
        string markerID = btn.gameObject.GetComponentInChildren<Cat>().catModel.imageTargetID;
        GamePlayController.Instance.SendCapturedMarkerData(GameManager_Data.Instance.model.ID, markerID);

    }
    public void OnYellowCapturedPressed(Button btn)
    {
        //todo check if this marker has already been captured by other team
        string markerID = btn.gameObject.GetComponentInChildren<Cat>().catModel.imageTargetID;
        GamePlayController.Instance.SendCapturedMarkerData(GameManager_Data.Instance.model.ID, markerID);

    }
    public void OnBlackCapturedPressed(Button btn)
    {
        //todo check if this marker has already been captured by other team
        string markerID = btn.gameObject.GetComponentInChildren<Cat>().catModel.imageTargetID;
        GamePlayController.Instance.SendCapturedMarkerData(GameManager_Data.Instance.model.ID, markerID);

    }


    #endregion
}
