using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAlien : MonoBehaviour
{
    public GameObject objetoColisionador;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.name.Contains(objetoColisionador.name))
            {
                Destroy(gameObject);
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error en " + ex.Message);
        }
    }
}
