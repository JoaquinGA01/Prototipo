using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;


[System.Serializable]
public class DatosPartes
{
    public string nombre;
    public string informacion;
}

public class ObtenerData : MonoBehaviour
{ //Posición en la que se quiere instanciar el modelo
    public List<Text> title;
    public List<Text> info;
    public List<GameObject> objetoPadre;
    public List<GameObject> botonPrefab;
    public GameObject objetoPadreModelo;
    private List<DatosPartes> datosBotones;
void Start()
{
    string nombre = PlayerPrefs.GetString("Nombre_Modelo");
            string data = PlayerPrefs.GetString("Data-JSON");
            string info_principal = PlayerPrefs.GetString("Info_Modelo");
            GameObject modeloInstanciado = IntanciarModelo(nombre);

            title[1].text = nombre;
            info[1].text = info_principal;

             //Se instancia el prefab del modelo en la posición especificada
            title[0].text = nombre;
            info[0].text = info_principal;
            CrearBotones(data, modeloInstanciado);
   
}
void CrearBotones(string djson, GameObject modelo)
    {
        datosBotones = JsonConvert.DeserializeObject<List<DatosPartes>>(djson);
        // Creamos un botón por cada objeto en los datos del archivo JSON
        for(int i=0;i<2;i++){
        foreach (DatosPartes botonDatos in datosBotones)
        {
            // Creamos un nuevo botón a partir del prefab
            GameObject nuevoBoton = Instantiate(botonPrefab[i], objetoPadre[i].transform);
            //nuevoBoton.GetComponent<Button>().GetComponent<TextChanger>().info = botonDatos.informacion;
            // Configuramos el texto del botón
            nuevoBoton.name = botonDatos.nombre+"b";
            nuevoBoton.GetComponentInChildren<Text>().text = botonDatos.nombre;
        }
        }
        
    }

GameObject IntanciarModelo(string nombre){
    GameObject modeloPrefab = Resources.Load<GameObject>(nombre);
    GameObject modeloInstanciado = Instantiate(modeloPrefab, objetoPadreModelo.transform);
    Renderer renderer = modeloInstanciado.GetComponent<Renderer>();


    float height = modeloPrefab.GetComponent<Renderer>().bounds.size.y;
    float width = modeloPrefab.GetComponent<Renderer>().bounds.size.x;


    if (height > width)
    {
        float scaleY = objetoPadreModelo.transform.localScale.y / renderer.bounds.size.y;
        modeloInstanciado.transform.localScale = new Vector3(scaleY, scaleY, scaleY);
    }
    else if (width > height)
    {
        float scaleX = objetoPadreModelo.transform.localScale.x / renderer.bounds.size.x;
        modeloInstanciado.transform.localScale = new Vector3(scaleX, scaleX, scaleX);
    }
    else
    {
        // Si el alto y el ancho son iguales, no se requiere ajuste de escala
    }
    return modeloInstanciado;
}

}