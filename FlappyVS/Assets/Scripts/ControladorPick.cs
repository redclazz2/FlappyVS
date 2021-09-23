using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ControladorPick : MonoBehaviour
{
    public GameObject pickUp, obstaclePipe;
    public float timeRemaining = 180;
    public bool timerIsRunning = false;
    public TextMeshPro timerText;

    public GameObject Player1, Player2;

    private AudioSource[] sonidos;
    private float minutes,seconds;
    void Start()
    {
        InvokeRepeating("Spawn", 0.7f, 0.7f);
        InvokeRepeating("Pipe", 1.55f, 1.55f);
        timerIsRunning = true;

        sonidos = GetComponents<AudioSource>();
    }

    void Spawn()
    {
        float puntoX = Random.Range(-11, 11);
        Instantiate(pickUp, new Vector3(puntoX, 4f, -1), Quaternion.identity);
    }
    void Pipe()
    {
        float puntoX = Random.Range(-7.6f, 7.6f);
        
        Instantiate(obstaclePipe, new Vector3(puntoX, 8f, -1), Quaternion.identity);
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0.1f)
            {
                timeRemaining -= Time.deltaTime;
                minutes = Mathf.FloorToInt(timeRemaining / 60);
                float seconds = Mathf.FloorToInt(timeRemaining % 60);

                timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
            }
            else
            {
                if (Player1.GetComponent<PlayerControl>().playerScore ==
                    Player2.GetComponent<PlayerControl>().playerScore)
                {
                    timeRemaining = 30;
                    timerText.text = string.Format("TIEMPO EXTRA: {0:00}:{1:00}",minutes,seconds);
                    sonidos[0].Stop();
                    sonidos[1].Stop();
                    sonidos[0].Play();
                    sonidos[1].Play();
                }
                else
                {   
                    sonidos[0].Stop();
                    sonidos[1].Stop();
                    timerIsRunning = false;
                    Time.timeScale = 0;
                }
                
            }
        }
    }
}
