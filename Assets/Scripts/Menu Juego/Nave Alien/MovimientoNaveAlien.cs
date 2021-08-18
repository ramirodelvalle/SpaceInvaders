using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNaveAlien : MonoBehaviour
{
    bool direccionMovimientoDerecha;
    public float tiempoRestanteParaElMovimiento;
    public float rangoDeTiempo = 0.3f;

    void Start()
    {
        direccionMovimientoDerecha = true;
    }

    void Update()
    {
        MoverObjeto();
        
    }

    void MoverObjeto()
    {
        Vector2 posActual = gameObject.transform.position;
        float medidaDesplazamientoLateral = 0.5f;
        float medidaDesplazamientoVertical = -0.5f;

        float nuevaPosicionY = 0;

        //La nave alien espera el intervalo de tiempo antes de volver a moverse
        if (tiempoRestanteParaElMovimiento < Time.time)
        {
            tiempoRestanteParaElMovimiento = Time.time + rangoDeTiempo;

            //si la nave alien llega a los extremos de la pantalla cambia el movimiento de derecha a izquierda o vice versa
            if (posActual.x >= 9.5)
            {
                direccionMovimientoDerecha = false;
                nuevaPosicionY = medidaDesplazamientoVertical;
            }
            else if (posActual.x <= -9.5)
            {
                direccionMovimientoDerecha = true;
                nuevaPosicionY = medidaDesplazamientoVertical;
            }

            //si la direccion no es la derecha multiplico el desplazamiento para que se mueva en negativo(izquierda)
            if (!direccionMovimientoDerecha) medidaDesplazamientoLateral = medidaDesplazamientoLateral * -1f;

            Vector2 posNueva = new Vector2(posActual.x + medidaDesplazamientoLateral,
                                           posActual.y + nuevaPosicionY);

            gameObject.transform.position = posNueva;
        }
    }
}
