using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    private Text texto;
    public void Start(){
        texto = GameObject.FindGameObjectWithTag("Informacion").GetComponent<Text>();
    }
    public void ChangeText()
    {
        Debug.Log(texto.text);
        texto.text = "Nuevo texto"; // Cambia el texto del objeto Text a "Nuevo texto"
    }
}
