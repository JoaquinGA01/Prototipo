using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

public class TextChanger : MonoBehaviour
{
    
    private Text texto;
    public string info;
    private List<DatosPartes> datosBotones;
    public Button boton; 
    private string data;
    private bool bandera;
    Vector3 escalaActual;

    public void Start(){
        texto = GameObject.FindGameObjectWithTag("Informacion").GetComponent<Text>();
        info = PlayerPrefs.GetString("Info_Modelo");
        data = PlayerPrefs.GetString("Data-JSON");
        bandera=true;
    }
    public void ChangeText()
    {
        texto.text = obtenerInfo();
        movermodelo(); // Cambia el texto del objeto Text a "Nuevo texto"
    }
    public string obtenerInfo(){
        datosBotones = JsonConvert.DeserializeObject<List<DatosPartes>>(data);
        // Creamos un botón por cada objeto en los datos del archivo JSON
        foreach (DatosPartes botonDatos in datosBotones)
        {
            if (boton.name == botonDatos.nombre+"b"){
                return botonDatos.informacion;
            }
        }
        return "";
    }
    public void movermodelo(){
            datosBotones = JsonConvert.DeserializeObject<List<DatosPartes>>(data);
            GameObject modeloInstanciado =  GameObject.Find(PlayerPrefs.GetString("Nombre_Modelo")+"(Clone)");
            Debug.Log(modeloInstanciado.name);
            Animator animator = modeloInstanciado.GetComponent<Animator>();
            // Creamos un botón por cada objeto en los datos del archivo JSON
            foreach (DatosPartes botonDatos in datosBotones)
            {
                if (boton.name == botonDatos.nombre+"b"){
                animator.SetTrigger(botonDatos.nombre);
                }
            }            
    }

}