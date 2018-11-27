using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuView : MonoBehaviour
{

    public void OnStartBtnPressed()
    {
        GameManager_APIResponses.Instance.CheckIfHasJoinedTeam();
    }
}
