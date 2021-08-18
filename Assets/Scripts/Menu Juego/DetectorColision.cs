using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorColision : MonoBehaviour
{
    public GameObject objetoColisionador;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains(objetoColisionador.name))
        {
            Destroy(gameObject);
        }
    }
}
