using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonFormatter : MonoBehaviour
{
    public static void FromJson<T>(string jsonText, ref T APIResponse)
    {
        APIResponse = JsonUtility.FromJson<T>(jsonText);
    }
}
