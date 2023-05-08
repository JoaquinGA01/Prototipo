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
        
        datosBotones = JsonConvert.DeserializeObject<List<DatosPartes>>(data);
        // Creamos un botón por cada objeto en los datos del archivo JSON
        foreach (DatosPartes botonDatos in datosBotones)
        {
            GameObject partes = GameObject.Find(botonDatos.nombre);
            escalaActual = partes.transform.localScale;
        }

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
            // Creamos un botón por cada objeto en los datos del archivo JSON
            foreach (DatosPartes botonDatos in datosBotones)
            {
                GameObject partes = GameObject.Find(botonDatos.nombre);
                if (Screen.width > Screen.height)
                {
                    
                        float nuevaEscala = 30.0f / Mathf.Max(escalaActual.x, escalaActual.y, escalaActual.z);
                        Vector3 nuevaEscalaProporcional = escalaActual * nuevaEscala;
                        partes.transform.localScale = nuevaEscalaProporcional;
                        partes.transform.position = new Vector3(-4.5f,0,5);

                        if(botonDatos.nombre+"b"==boton.name){
                            GameObject miObjeto = GameObject.Find(botonDatos.nombre);
                            miObjeto.transform.position = new Vector3(0,0,3);
                            miObjeto.transform.localScale = escalaActual;
                        }
                        Debug.Log(escalaActual);
                }
                else
                {
                        float nuevaEscala = 10.0f / Mathf.Max(escalaActual.x, escalaActual.y, escalaActual.z);
                        Vector3 nuevaEscalaProporcional = escalaActual * nuevaEscala;
                        partes.transform.localScale = nuevaEscalaProporcional;
                        partes.transform.position = new Vector3(-1,0,5);

                        if(botonDatos.nombre+"b"==boton.name){
                            GameObject miObjeto = GameObject.Find(botonDatos.nombre);
                            miObjeto.transform.position = new Vector3(0,1,5);
                            miObjeto.transform.localScale = escalaActual;
                        }
                        Debug.Log(escalaActual);
                    }
                }
            }
            
    }

