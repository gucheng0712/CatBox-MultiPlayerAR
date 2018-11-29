using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    public CatModel catModel;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {

    }
    void OnMouseDown()
    {
        CheckMarkerControlStatus(catModel.imageTargetID);
        GameManager_Event.Instance.MarkerCaptured(catModel.imageTargetID);
        anim.SetTrigger("Open");
    }



    public void CheckMarkerControlStatus(string imageTargetID)
    {
        string team = GameManager_APIResponses.Instance.playersThisRound[GameManager_Data.Instance.model.ID.ToString()].team;

        switch (MarkerController(imageTargetID))
        {
            case "NEUTRAL":
                // Scanned a neutral marker
                print("Scanned a neutral marker");
                GamePlayController.Instance.canScore = true;
                break;
            case "BLUE":
                if (team == TeamSelectionModel.BLUE_TEAM_NAME)
                {
                    // Scanned a marker that already belongs to this Team.
                    print("Scanned a marker that already belongs to this Team.");
                    GamePlayController.Instance.canScore = false;
                }
                else if (team == TeamSelectionModel.RED_TEAM_NAME)
                {
                    //Scanned a marker that belongs to opposing team.
                    print("Scanned a marker that belongs to opposing team.");
                    GamePlayController.Instance.canScore = true;
                }
                break;
            case "RED":
                if (team == TeamSelectionModel.RED_TEAM_NAME)
                {
                    GamePlayController.Instance.canScore = false;
                    // Scanned a marker that already belongs to this Team.
                    print(" Scanned a marker that already belongs to this Team.");
                }
                else if (team == TeamSelectionModel.BLUE_TEAM_NAME)
                {
                    GamePlayController.Instance.canScore = true;
                    //Scanned a marker that belongs to opposing team.
                    print(" Scanned a marker that belongs to opposing team.");
                }
                break;
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
