using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class RecargarModelo : MonoBehaviour
{
    private string data;
    private List<DatosPartes> datosBotones;
    private Vector3 escalaActual;
    private Vector3 posicionOriginal;
    private bool bandera;
    
    // Start is called before the first frame update
    void Start()
    {
        data = PlayerPrefs.GetString("Data-JSON");
        datosBotones = JsonConvert.DeserializeObject<List<DatosPartes>>(data);
        bandera = true;        
    }
    public void recargar(){
        
        foreach (DatosPartes botonDatos in datosBotones)
        {
            GameObject partes = GameObject.Find(botonDatos.nombre);
            partes.transform.localScale = escalaActual;
            partes.transform.position = posicionOriginal;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(bandera){
            foreach (DatosPartes botonDatos in datosBotones)
        {
            Debug.Log(botonDatos.nombre);
            GameObject partes = GameObject.Find(botonDatos.nombre);
            escalaActual = partes.transform.localScale;
            posicionOriginal = partes.transform.position;
            Debug.Log(escalaActual);
        }
        bandera = false;
        }
    }
}
