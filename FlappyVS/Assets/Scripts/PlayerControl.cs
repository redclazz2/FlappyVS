using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{   
    public float velocity = -3f;
    public int playerNumber = 1;
    public Sprite idleSprite, keyPressedSprite;
    public GameObject puntoAparicion;
    public float playerScore = 0;
    
    private AudioSource[] sonidos;
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRender;
    private KeyCode jumpChecker;
    private Vector2 MovementDir;
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerSpriteRender = gameObject.GetComponent<SpriteRenderer>();
        sonidos = GetComponents<AudioSource>();

        if (playerNumber == 1)
        {
            jumpChecker = KeyCode.S;
            MovementDir = Vector2.right;
            playerSpriteRender.sprite = idleSprite;
        }
        else
        {
            jumpChecker = KeyCode.L;
            MovementDir = Vector2.left;
            playerSpriteRender.sprite = idleSprite;
        }

        transform.position = puntoAparicion.transform.position;
    }
    //Función para actualizar el movimiento del jugador:
    private void playerMovementAct(KeyCode jumpChecker, Vector2 MovementDir)
    {
        transform.Translate( MovementDir * velocity * Time.deltaTime);
        
        if (Input.GetKeyDown(jumpChecker))
        {
            playerRigidBody.velocity = Vector2.up * 6f;
            playerSpriteRender.sprite = keyPressedSprite;
            sonidos[1].Play();
        }

        if (Input.GetKeyUp(jumpChecker))
        {
            playerSpriteRender.sprite = idleSprite;
        }
    }
    void Update()
    {
        playerMovementAct(jumpChecker,MovementDir);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstaculo" || other.gameObject.tag == "Player")
        {
            transform.position = puntoAparicion.transform.position;
            sonidos[0].Play();
        }
        else if (other.gameObject.tag == "CambioDir")
        {
            if (MovementDir == Vector2.left)
            {
                MovementDir = Vector2.right;
            }
            else if (MovementDir == Vector2.right)
            {
                MovementDir = Vector2.left;
            }
        }
    }
}
