using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    public GameObject padre;
    private TextMeshPro texto;
    void Start()
    {
        texto = GetComponent<TextMeshPro>();
        if (padre.GetComponent<PlayerControl>().playerNumber == 1)
        {
            texto.color = Color.green;
        }
        else
        {
            texto.color = Color.magenta;
        }
    }

    private void Update()
    {
        texto.text = padre.GetComponent<PlayerControl>().playerScore.ToString();
    }
}
