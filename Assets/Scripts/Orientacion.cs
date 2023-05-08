using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientacion : MonoBehaviour
{
    public GameObject verticalCanvas;
    public GameObject horizontalCanvas;

    void Start()
    {
        SetCanvasOrientation();
    }
    void Update(){
        SetCanvasOrientation();
    }

    void SetCanvasOrientation()
    {
        if (Screen.width > Screen.height)
        {
            // Mostrar Canvas horizontal y ocultar vertical
            horizontalCanvas.SetActive(true);
            verticalCanvas.SetActive(false);
        }
        else
        {
            // Mostrar Canvas vertical y ocultar horizontal
            horizontalCanvas.SetActive(false);
            verticalCanvas.SetActive(true);
        }
    }
}
