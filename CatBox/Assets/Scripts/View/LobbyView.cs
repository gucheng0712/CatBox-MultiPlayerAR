using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyView : MonoBehaviour
{
    public void OnScanBtnPressed()
    {
        SceneManager.LoadScene("GamePlayTest");
        // SceneManager.LoadScene("AR-GamePlay");
    }
}
