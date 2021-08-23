using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserJugador : MonoBehaviour
{
    public GameObject naveAlien;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.name.Contains(naveAlien.name) && collision.gameObject.GetComponent<NaveAlien>().estaOperativa)
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
