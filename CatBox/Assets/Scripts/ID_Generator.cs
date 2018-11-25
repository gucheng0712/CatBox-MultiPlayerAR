using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID_Generator : MonoBehaviour
{
    const string KEY = "ID";

    public static int s_id;

    void Awake()
    {
        if (PlayerPrefs.HasKey(KEY))
        {
            s_id = PlayerPrefs.GetInt(KEY);
            Debug.Log("Loaded the existing ID: " + s_id);
        }
        else
        {
            CreateID();
        }
    }

    void CreateID()
    {
        s_id = System.Guid.NewGuid().GetHashCode();
        Debug.Log("Created a unique ID: " + s_id);
        PlayerPrefs.SetInt(KEY, s_id);
    }
}
