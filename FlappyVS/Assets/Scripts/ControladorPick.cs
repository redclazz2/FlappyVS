using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPick : MonoBehaviour
{
    public GameObject pickUp, obstaclePipe;
    void Start()
    {
        InvokeRepeating("Spawn", 0.7f, 0.7f);
        InvokeRepeating("Pipe", 1.55f, 1.55f);
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
    
}
