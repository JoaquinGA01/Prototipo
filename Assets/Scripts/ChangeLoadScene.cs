using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;


public class ChangeLoadScene : MonoBehaviour
{   
    public string nombre_modelo;
    public string InfoPrincipal;
    public List<DatosPartes> data = new List<DatosPartes>();
    public void LoadScene(string sceneName){

        if(nombre_modelo!=null && data!=null){
            PlayerPrefs.SetString("Nombre_Modelo", nombre_modelo);
            PlayerPrefs.SetString("Info_Modelo", InfoPrincipal);
            PlayerPrefs.SetString("Data-JSON", JsonConvert.SerializeObject(data));
        }
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
