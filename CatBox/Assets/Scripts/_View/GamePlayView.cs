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
}
