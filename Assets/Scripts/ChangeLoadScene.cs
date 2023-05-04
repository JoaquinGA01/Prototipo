using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLoadScene : MonoBehaviour
{   
    public string nombre_modelo;
    public void LoadScene(string sceneName){
        if(nombre_modelo!=null){
            PlayerPrefs.SetString("Nombre_Modelo", nombre_modelo);
 
        }        
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
