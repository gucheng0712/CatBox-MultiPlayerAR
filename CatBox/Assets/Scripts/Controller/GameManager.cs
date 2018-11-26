using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public abstract class GameManager<T> : GameManager where T : GameManager<T>
{
    public static T Instance { get; private set; }
    [HideInInspector] public string dataFromWeb;

    public Model m_model;

    protected virtual void Awake()
    {
        if (Instance == null) { Instance = (T)this; } else { Destroy(gameObject); }

        // Initialize all Game Data
        m_model = new Model();
    }

    protected virtual void OnDestroy()
    {
        Instance = null;
    }


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
            dataFromWeb = uwr.downloadHandler.text;
        }
    }

    // Override Function for GetRequestFromWeb can load to another scene after getting the request
    protected virtual IEnumerator GetRequestFromWeb(string url, string sceneName)
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
            dataFromWeb = uwr.downloadHandler.text;
            SceneManager.LoadScene(sceneName);
        }
    }

}

public abstract class GameManager : MonoBehaviour
{

}


