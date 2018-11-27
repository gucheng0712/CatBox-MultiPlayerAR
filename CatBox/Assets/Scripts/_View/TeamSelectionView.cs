using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeamSelectionView : MonoBehaviour
{
    [SerializeField] GameObject m_noTeamParent;
    [SerializeField] GameObject m_hasTeamParent;

    private void Awake()
    {
        if (GameManager_Data.Instance.HasJoinedTeam == true)
        {
            m_hasTeamParent.SetActive(true);
            m_noTeamParent.SetActive(false);
        }
        else
        {
            m_hasTeamParent.SetActive(false);
            m_noTeamParent.SetActive(true);
        }
    }

    #region Btn Events
    // Choose Blue Team
    public void ChooseBlueTeamBtnPressed()
    {
        GameManager_Data.Instance.model.teamSelectionModel.TeamType = TeamType.Blue;
        TeamSelectionController.Instance.SendJoinedTeamData(GameManager_Data.Instance.model.teamSelectionModel.TeamType);
    }

    // Choose Red Team
    public void ChooseRedTeamBtnPressed()
    {
        GameManager_Data.Instance.model.teamSelectionModel.TeamType = TeamType.Red;
        TeamSelectionController.Instance.SendJoinedTeamData(GameManager_Data.Instance.model.teamSelectionModel.TeamType);
    }

    // Team Pick Confirm and Load to next Scene
    public void PlayBtnPressed()
    {
        TeamSelectionController.Instance.SendJoinedTeamData(GameManager_Data.Instance.model.teamSelectionModel.TeamType);
    }
    #endregion
}
