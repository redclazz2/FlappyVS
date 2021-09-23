using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPick : MonoBehaviour
{
    public GameObject pickUp;
    void Start()
    {
        InvokeRepeating("Spawn", 0.7f, 0.7f);
    }

    void Spawn()
    {
        float puntoX = Random.Range(-11, 11);
        Instantiate(pickUp, new Vector3(puntoX, 4f, -1), Quaternion.identity);
    }
}
