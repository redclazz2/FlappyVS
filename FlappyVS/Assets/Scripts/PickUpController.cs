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
        if (Random.Range(0, 1) == 1)
        {
            tag = "Diamante";
            spriteObjeto.sprite = spriteDiamante;
        }
        else
        {
            tag = "Moneda";
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
            scripPuntos.playerScore++;
            Destroy(this.gameObject);
        }
    }
}
