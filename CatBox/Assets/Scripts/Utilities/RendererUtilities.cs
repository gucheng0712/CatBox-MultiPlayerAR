using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererUtilities : MonoBehaviour {

    public static void SetRendererColor(ref Renderer _renderer, Color col)
    {
        _renderer.material.color = col;
    }
}
