using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorColisionNaveJugador : MonoBehaviour
{
    public GameObject naveAlien;
    public GameObject laserAlien;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.name.Contains(naveAlien.name) && collision.gameObject.GetComponent<NaveAlien>().estaOperativa
                || collision.gameObject.name.Contains(laserAlien.name))
            {
                //Destroy(gameObject);
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error en " + ex.Message);
            throw;
        }
    }
}
