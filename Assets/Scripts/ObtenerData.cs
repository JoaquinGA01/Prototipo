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
    private List<DatosPartes> datosBotones;
void Start()
{
    string nombre = PlayerPrefs.GetString("Nombre_Modelo");
            string data = PlayerPrefs.GetString("Data-JSON");
            string info_principal = PlayerPrefs.GetString("Info_Modelo");
            GameObject modeloPrefab = Resources.Load<GameObject>(nombre);
            GameObject modeloInstanciado = Instantiate(modeloPrefab, new Vector3(0,1,5), Quaternion.identity);

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

}