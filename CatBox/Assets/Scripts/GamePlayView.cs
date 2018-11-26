using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayView : MonoBehaviour {

    public void OnScanBtnPressed()
    {
        SceneManager.LoadScene("ARTest");
       // SceneManager.LoadScene("AR");
    }

    public void OnBackMainSceneBtnPressed()
    {
        SceneManager.LoadScene("MainGame");
    }


    #region Btn Events For testing
    public void OnBlueCapturedPressed(Button btn)
    {
        //todo check if this marker has already been captured by other team
        string markerID = btn.gameObject.GetComponentInChildren<Cat>().catModel.imageTargetID;
        GamePlayController.Instance.SendCapturedMarkerData(Model.s_id, markerID);
    }
    public void OnPinkCapturedPressed(Button btn)
    {
        //todo check if this marker has already been captured by other team
        string markerID = btn.gameObject.GetComponentInChildren<Cat>().catModel.imageTargetID;
        GamePlayController.Instance.SendCapturedMarkerData(Model.s_id, markerID);

    }
    public void OnBrownCapturedPressed(Button btn)
    {
        //todo check if this marker has already been captured by other team
        string markerID = btn.gameObject.GetComponentInChildren<Cat>().catModel.imageTargetID;
        GamePlayController.Instance.SendCapturedMarkerData(Model.s_id, markerID);

    }
    public void OnYellowCapturedPressed(Button btn)
    {
        //todo check if this marker has already been captured by other team
        string markerID = btn.gameObject.GetComponentInChildren<Cat>().catModel.imageTargetID;
        GamePlayController.Instance.SendCapturedMarkerData(Model.s_id, markerID);

    }
    public void OnBlackCapturedPressed(Button btn)
    {
        //todo check if this marker has already been captured by other team
        string markerID = btn.gameObject.GetComponentInChildren<Cat>().catModel.imageTargetID;
        GamePlayController.Instance.SendCapturedMarkerData(Model.s_id, markerID);

    }


    #endregion
}
