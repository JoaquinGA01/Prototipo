using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimacionAparicion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       SpriteRenderer cubeRenderer = GetComponent<SpriteRenderer>();

    // Utilizamos DOTween para hacer que la opacidad del cubo llegue a cero en 1 segundo
    cubeRenderer.DOFade(0f, 1f);
    }
}
