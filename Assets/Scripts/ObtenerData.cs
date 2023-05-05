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
    GameObject modeloInstanciado = Instantiate(modeloPrefab, new Vector3(0,2,5), Quaternion.identity); //Se instancia el prefab del modelo en la posición especificada
}
}
