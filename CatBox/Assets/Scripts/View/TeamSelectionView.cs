using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamSelectionView : MonoBehaviour
{
    #region Btn Events
    // Choose Blue Team
    public void ChooseBlueTeamBtnPressed()
    {
        TeamSelectionController.Instance.teamType = TeamType.Blue;
    }

    // Choose Red Team
    public void ChooseRedTeamBtnPressed()
    {
        TeamSelectionController.Instance.teamType = TeamType.Red;
    }

    // Team Pick Confirm and Load to next Scene
    public void StartGameBtnPressed()
    {
        TeamSelectionController.Instance.SendJoinedTeamData(TeamSelectionController.Instance.teamType);
    }
    #endregion
}
