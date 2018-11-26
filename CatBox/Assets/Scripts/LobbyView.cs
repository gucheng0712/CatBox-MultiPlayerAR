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
        LobbyController.Instance.teamType = TeamType.Blue;
    }

    // Choose Red Team
    public void ChooseRedTeamBtnPressed()
    {
        LobbyController.Instance.teamType = TeamType.Red;
    }

    // Team Pick Confirm and Load to next Scene
    public void StartGameBtnPressed()
    {
       LobbyController.Instance.SendJoinedTeamData(LobbyController.Instance.teamType);
    }
    #endregion
}
