using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustarCamara : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas targetCanvas;

    private void Update()
    {
        if (targetCanvas != null)
        {
            // Ajustar el tamaño de la cámara
            float canvasHeight = targetCanvas.GetComponent<RectTransform>().sizeDelta.y;
            Camera.main.orthographicSize = canvasHeight / 2f;

            // Ajustar la posición de la cámara
            Vector3 canvasPosition = targetCanvas.transform.position;
            Camera.main.transform.position = new Vector3(canvasPosition.x, canvasPosition.y, Camera.main.transform.position.z);
        }
        else
        {
            Debug.LogError("No se ha asignado un objeto Canvas al script de configuración de la cámara.");
        }
    }
}

