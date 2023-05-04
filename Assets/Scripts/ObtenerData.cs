using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtenerData : MonoBehaviour
{ //Posición en la que se quiere instanciar el modelo

void Start()
{
    string nombre = PlayerPrefs.GetString("Nombre_Modelo");
    Debug.Log(nombre);
    GameObject modeloPrefab = Resources.Load<GameObject>(nombre);
    GameObject modeloInstanciado = Instantiate(modeloPrefab, new Vector3(PlayerPrefs.GetFloat("VectorX"),PlayerPrefs.GetFloat("VectorY"),PlayerPrefs.GetFloat("VectorZ")), Quaternion.identity); //Se instancia el prefab del modelo en la posición especificada
}
}
