using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;



public abstract class GameManager<T> : GameManager where T : GameManager<T>
{


    #region Singleton Base
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null) { Instance = (T)this; } else { Destroy(gameObject); }

    }

    protected virtual void OnDestroy()
    {
        Instance = null;
    }
    #endregion


    #region Data Receive Base
    //  Get data From HTTP
    protected virtual IEnumerator GetRequestFromWeb(string url)
    {
        // Create UnityWebRequest and give it the url 
        UnityWebRequest uwr = UnityWebRequest.Get(url);

        yield return uwr.SendWebRequest();

        // Check if has error
        if (uwr.isNetworkError)
        {
            Debug.Log("Error: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);

            EventAfterReceivedData(uwr.downloadHandler.text);
        }
    }

    protected virtual void EventAfterReceivedData(string s)
    {

    }
    #endregion

}

public abstract class GameManager : MonoBehaviour
{

}


