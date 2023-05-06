using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;


[System.Serializable]
public class DatosPartes
{
    public string nombre;
    public string informacion;
}

public class ObtenerData : MonoBehaviour
{ //Posición en la que se quiere instanciar el modelo
    public Text title;
    public Text info;
    public GameObject objetoPadre;
    public GameObject botonPrefab;
    private List<DatosPartes> datosBotones;
void Start()
{
    string nombre = PlayerPrefs.GetString("Nombre_Modelo");
    string data = PlayerPrefs.GetString("Data-JSON");
    string info_principal = PlayerPrefs.GetString("Info_Modelo");
    GameObject modeloPrefab = Resources.Load<GameObject>(nombre);
    GameObject modeloInstanciado = Instantiate(modeloPrefab, new Vector3(0,1,5), Quaternion.identity); //Se instancia el prefab del modelo en la posición especificada
    title.text = nombre;
    info.text = info_principal;
    CrearBotones(data);
}
void CrearBotones(string djson)
    {
        datosBotones = JsonConvert.DeserializeObject<List<DatosPartes>>(djson);
        // Creamos un botón por cada objeto en los datos del archivo JSON
        foreach (DatosPartes botonDatos in datosBotones)
        {
            // Creamos un nuevo botón a partir del prefab
            GameObject nuevoBoton = Instantiate(botonPrefab, objetoPadre.transform);

            // Configuramos el texto del botón
            nuevoBoton.GetComponentInChildren<Text>().text = botonDatos.nombre;
        }
    }
}
