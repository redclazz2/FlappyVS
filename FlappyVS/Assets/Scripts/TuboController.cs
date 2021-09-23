using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuboController : MonoBehaviour
{

    private Vector2 vectorDirector;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate( Vector2.down * 5 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstaculo")
        {
            Destroy(this.gameObject);
        }
    }
}
