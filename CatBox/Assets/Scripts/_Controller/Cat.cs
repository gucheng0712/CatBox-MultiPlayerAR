using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    public CatModel catModel;
    Animator anim;
    bool m_isBoxOpened;

    Renderer m_renderer;

    void Awake()
    {
        anim = GetComponent<Animator>();
        m_renderer = transform.Find("Flag").GetComponent<Renderer>();
    }
    void OnMouseOver()
    {
        if (GamePlayController.Instance.canOpenBox)
        {
            ChangeMarkerControlStatus(catModel.imageTargetID, ref GamePlayController.Instance.canScore);
            print("Open box");
            GamePlayController.Instance.canOpenBox = false; // make sure player cannot capture the marker repeatly
          
            anim.SetTrigger("Open");
            m_isBoxOpened = true;

            if (GamePlayController.Instance.canScore)
            {
                // change to opposite team
                GameManager_Event.Instance.MarkerCapturedEvents(catModel.imageTargetID);
            }
        }
    }

    void OnMouseDown()
    {
        if (!m_isBoxOpened)
        {
            GamePlayController.Instance.isCountingDown = true;
            print("Mouse On");
        }

    }
    void OnMouseUp()
    {
        GamePlayController.Instance.ResetCountDownTime();
        print("Mouse Left");
    }


    public void ShowMarkControlStatus(string markerControl)
    {
        print(markerControl);
    }


    public void CheckMarkerControlStatus(string imageTargetID)
    {
        if (MarkerController(imageTargetID) == "BLUE")
        {
            m_renderer.material.color = GamePlayController.Instance.blueColor;
        }
        else if (MarkerController(imageTargetID) == "RED")
        {
            m_renderer.material.color = GamePlayController.Instance.redColor;
        }
        else
        {
            m_renderer.material.color = GamePlayController.Instance.neutralColor;
        }
    }


    public void ChangeMarkerControlStatus(string imageTargetID, ref bool canScore)
    {
        string team = GameManager_APIResponses.Instance.playersThisRound[GameManager_Data.Instance.model.ID.ToString()].team;

        switch (MarkerController(imageTargetID))
        {
            case "NEUTRAL":
                // Scanned a neutral marker
                CapturedNeutralCat(team, ref canScore);
                break;
            case "BLUE":
                CaptureBlueTeamCat(team,ref canScore);
                break;
            case "RED":
                CaptureRedTeamCat(team,ref canScore);
                break;
        }
    }

    void CapturedNeutralCat(string team, ref bool canScore )
    {
        print("Scanned a neutral marker");
        canScore = true;
        GamePlayController.Instance.gamePlayView.ShowCaptureNeutralCatMsg();
        if (team == TeamSelectionModel.BLUE_TEAM_NAME)
        {
            // set flag to blue
            RendererUtilities.SetRendererColor(ref m_renderer, GamePlayController.Instance.blueColor);
        }
        else if (team == TeamSelectionModel.RED_TEAM_NAME)
        {
            // set flag to red
            RendererUtilities.SetRendererColor(ref m_renderer, GamePlayController.Instance.redColor);
        }
    }

    void CaptureBlueTeamCat(string team, ref bool canScore)
    {
        if (team == TeamSelectionModel.BLUE_TEAM_NAME)
        {
            // Scanned a marker that already belongs to this Team.
            print("Scanned a marker that already belongs to this Team.");
            canScore = false;
            GamePlayController.Instance.gamePlayView.ShowCaptureSameTeamCatMsg();
        }
        else if (team == TeamSelectionModel.RED_TEAM_NAME)
        {
            //Scanned a marker that belongs to opposing team.
            print("Scanned a marker that belongs to opposing team.");
            canScore = true;
            RendererUtilities.SetRendererColor(ref m_renderer, GamePlayController.Instance.blueColor);
            GamePlayController.Instance.gamePlayView.ShowCaptureOppositeTeamCatMsg();
        }
    }

    void CaptureRedTeamCat(string team, ref bool canScore)
    {
        if (team == TeamSelectionModel.RED_TEAM_NAME)
        {
            canScore = false;
            // Scanned a marker that already belongs to this Team.
            print(" Scanned a marker that already belongs to this Team.");
            GamePlayController.Instance.gamePlayView.ShowCaptureSameTeamCatMsg();

        }
        else if (team == TeamSelectionModel.BLUE_TEAM_NAME)
        {
            canScore = true;
            //Scanned a marker that belongs to opposing team.
            print(" Scanned a marker that belongs to opposing team.");

            GamePlayController.Instance.gamePlayView.ShowCaptureOppositeTeamCatMsg();
            RendererUtilities.SetRendererColor(ref m_renderer, GamePlayController.Instance.redColor);
        }
    }

    string MarkerController(string imageTargetID)
    {
        switch (imageTargetID)
        {
            case "marker01":
                return GameManager_APIResponses.Instance.timeUpdatedResponse.marker01Control;
            case "marker02":
                return GameManager_APIResponses.Instance.timeUpdatedResponse.marker02Control;
            case "marker03":
                return GameManager_APIResponses.Instance.timeUpdatedResponse.marker03Control;
            case "marker04":
                return GameManager_APIResponses.Instance.timeUpdatedResponse.marker04Control;
            case "marker05":
                return GameManager_APIResponses.Instance.timeUpdatedResponse.marker05Control;
        }
        return null;
    }

}
