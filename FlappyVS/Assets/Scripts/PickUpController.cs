using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickUpController : MonoBehaviour
{
    private SpriteRenderer spriteObjeto;
    public Sprite spriteMoneda, spriteDiamante;
    
    void Start()
    {
        spriteObjeto = GetComponent<SpriteRenderer>();
        float numero = Random.Range(0f, 1f);
        if (numero < 0.1)
        {
            gameObject.tag = "Diamante";
            spriteObjeto.sprite = spriteDiamante;
        }
        else
        {
            gameObject.tag = "Moneda";
            spriteObjeto.sprite = spriteMoneda;
        }
            
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstaculo")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            var scripPuntos = other.gameObject.GetComponent<PlayerControl>();
            if (this.tag =="Diamante")
            {
                scripPuntos.playerScore += 5;
            }
            else
            {
                scripPuntos.playerScore += 1;
            }
            
            Destroy(gameObject);
        }
    }
}
