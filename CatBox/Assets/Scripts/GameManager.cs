using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class GameManager<T> : GameManager where T:GameManager<T>
{
    public static T Instance { get; private set; }

    [HideInInspector]public string dataFromWeb;

    public Model m_model;

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)this;
        }
        else
        {
           Destroy(gameObject);
        }

        m_model = new Model();
    }

    protected virtual void OnDestroy()
    {
        Instance = null;
    }

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

}

public abstract class GameManager : MonoBehaviour
{

}


