using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyView : MonoBehaviour
{

    #region Btn Events
    // Choose Blue Team
    public void ChooseBlueTeamBtnPressed()
    {
        LobbyController.Instance.SendJoinedTeamData(Model.s_id, LobbyModel.BLUE_TEAM_NAME);
        LoadToMainGameScene();
    }

    // Choose Red Team
    public void ChooseRedTeamBtnPressed()
    {
        LobbyController.Instance.SendJoinedTeamData(Model.s_id, LobbyModel.RED_TEAM_NAME);
        LoadToMainGameScene();
    }

    public void LoadToMainGameScene()
    {
        SceneManager.LoadScene("MainGame");
    }
    #endregion
}
