using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuView : MonoBehaviour
{
    [SerializeField] GameObject m_clickToContinueBtnGO;
    [SerializeField] GameObject m_loadingTextGO;

    private void Start()
    {
        m_clickToContinueBtnGO.SetActive(false);// initiallize m_clickToContinueBtnGO as false;
        m_loadingTextGO.SetActive(true); // Initiallize loading image as true;
        StartMenuController.Instance.CheckIfJoinedTeam();// Check player status to determine if he has already joined a team in this game
        StartCoroutine(CheckJoinedTeamRoutine());
    }

    IEnumerator CheckJoinedTeamRoutine()
    {
        yield return new WaitForSeconds(3f);
        if (StartMenuController.Instance.finishCheckIfPlayerHasJoinedTeam == true)
        {
            m_loadingTextGO.SetActive(false);
            m_clickToContinueBtnGO.SetActive(true);
            // Make the SetActive function only call once
            StartMenuController.Instance.finishCheckIfPlayerHasJoinedTeam = false;
        }
    }

    public void OnClickToContinueBtnPressed()
    {
        SceneManager.LoadScene("TeamSelection");
    }
}
