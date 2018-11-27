using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Data : GameManager<GameManager_Data>
{
    public Model model;

    [SerializeField] bool hasJoinedTeam;
    public bool HasJoinedTeam { get { return hasJoinedTeam; } set { hasJoinedTeam = value; } }


    protected override void Awake()
    {
        base.Awake();
        CreateOrLoadID();
    }

    void CreateOrLoadID()
    {
        if (PlayerPrefs.HasKey(Model.ID_KEY))
        {
            model.ID = PlayerPrefs.GetInt(Model.ID_KEY);
            Debug.Log("Loaded the existing ID: " + model.ID);
        }
        else
        {
            model.ID = System.Guid.NewGuid().GetHashCode();
            Debug.Log("Created a unique ID: " + model.ID);
            PlayerPrefs.SetInt(Model.ID_KEY, model.ID);
        }
    }

}
