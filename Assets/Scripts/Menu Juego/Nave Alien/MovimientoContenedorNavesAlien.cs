using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoContenedorNavesAlien : MonoBehaviour
{
    bool direccionMovimientoDerecha;
    public float tiempoRestanteParaElMovimiento;
    public float rangoDeTiempo = 0.3f;
    bool yaMovioHaciaAbajo = false;
    float tiempoParaMoverHaciaAbajo = 1;

    void Start()
    {
        direccionMovimientoDerecha = true;
    }

    void Update()
    {
        MoverObjetoHorizontalmente();
        ReiniciarBanderaMovioHaciaAbajo();
    }

    void MoverObjetoHorizontalmente()
    {
        Vector2 posActualContenedorNavesAlien = gameObject.transform.position;
        float medidaDesplazamientoLateral = 0.5f;

        //La nave alien espera el intervalo de tiempo antes de volver a moverse
        if (tiempoRestanteParaElMovimiento < Time.time)
        {
            tiempoRestanteParaElMovimiento = Time.time + rangoDeTiempo;

            //si la direccion no es la derecha multiplico el desplazamiento para que se mueva en negativo(izquierda)
            if (!direccionMovimientoDerecha) medidaDesplazamientoLateral = medidaDesplazamientoLateral * -1f;

            //creo una posicion nueva para el objeto
            Vector2 posNueva = new Vector2(posActualContenedorNavesAlien.x + medidaDesplazamientoLateral,
                                           posActualContenedorNavesAlien.y);

            //y la asigno
            gameObject.transform.position = posNueva;
        }
    }

    public void MoverObjetoVerticalmente()
    {
        if (!yaMovioHaciaAbajo)
        {
            Vector2 posActual = gameObject.transform.position;
            float medidaDesplazamientoVertical = -0.5f;

            Vector2 posNueva = new Vector2(posActual.x,
                                           posActual.y + medidaDesplazamientoVertical);

            gameObject.transform.position = posNueva;

            yaMovioHaciaAbajo = true;
        }
    }

    public void CambiarDireccionDelMovimiento()
    {
        if (!yaMovioHaciaAbajo)
        {
            if (direccionMovimientoDerecha) direccionMovimientoDerecha = false;
            else direccionMovimientoDerecha = true;

            MoverObjetoVerticalmente();

            yaMovioHaciaAbajo = true;
        }
    }

    public void ReiniciarBanderaMovioHaciaAbajo()
    {
        if (Time.time >= tiempoParaMoverHaciaAbajo)
        {
            tiempoParaMoverHaciaAbajo = Time.time + 2;
            yaMovioHaciaAbajo = false;
        }
    }
}
