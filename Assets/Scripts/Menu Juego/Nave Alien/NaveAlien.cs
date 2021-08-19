using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveAlien : MonoBehaviour
{
    public GameObject ObjetoADisparar;
    public Transform PuntoDeDisparo;
    public float fuerzaDelDisparo;
    public GameObject paredIzquierda;
    public GameObject paredDerecha;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains(paredIzquierda.name) || collision.gameObject.name.Contains(paredDerecha.name))
        {
            try
            {
                MovimientoContenedorNavesAlien scriptContenedorNavesAlien = 
                    GameObject.Find("ContenedorNavesAlien").GetComponent<MovimientoContenedorNavesAlien>();

                scriptContenedorNavesAlien.CambiarDireccionDelMovimiento();
                //scriptContenedorNavesAlien.MoverObjetoVerticalmente();
            }
            catch (System.Exception)
            {
                Debug.LogWarning("Objeto no encontrado");
                throw;
            }
        }
    }
}
