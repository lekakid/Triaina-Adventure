using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSolver : MonoBehaviour
{
    public int WidthRatio = 9;
    public int HeightRatio = 16;

    Vector2 lastResolution;

    void Start()
    {
        lastResolution = new Vector2(Screen.width, Screen.height);
        ResizeRect();
    }

    void Update() {
        if(lastResolution.x != Screen.width || lastResolution.y != Screen.height) {
            lastResolution = new Vector2(Screen.width, Screen.height);
            ResizeRect();
        }
    }

    void ResizeRect() {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)WidthRatio / HeightRatio);
        float scalewidth = 1f / scaleheight;
        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        camera.rect = rect;
    }

    void OnPreCull() => GL.Clear(true, true, Color.black);

    
}