using UnityEngine;

public class GrayScale : MonoBehaviour
{
    private bool isGray = false;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void OnMouseDown()
    {
        // Cambiar posición de la esfera seleccionada
        transform.position += Vector3.up * 0.5f;

        // Cambiar a escala de grises todas las esferas excepto la seleccionada
        GrayScale[] allGrayScales = FindObjectsOfType<GrayScale>();
        foreach (GrayScale gs in allGrayScales)
        {
            if (gs != this)
            {
                gs.material.SetFloat("_GrayscaleAmount", 1);
                gs.isGray = true;
            }
        }

        // Cambiar la esfera seleccionada a su estado original si ya estaba en escala de grises
        if (isGray)
        {
            material.SetFloat("_GrayscaleAmount", 0);
            isGray = false;
        }
        // Cambiar la esfera seleccionada a escala de grises si no lo estaba
        else
        {
            material.SetFloat("_GrayscaleAmount", 1);
            isGray = true;
        }
    }
}
