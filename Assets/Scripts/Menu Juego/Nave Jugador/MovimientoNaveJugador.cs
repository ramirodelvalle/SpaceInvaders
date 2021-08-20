using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNaveJugador : MonoBehaviour
{
    static int velocidadDeDesplazamiento = 15;
   
    void Update()
    {
        MoverObjetoConLasFlechasDireccionales();
    }

    void MoverObjetoConLasFlechasDireccionales()
    {
        //Mover a la izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -9.5)
                transform.Translate(new Vector2(-1, 0) * Time.deltaTime * velocidadDeDesplazamiento);
        }

        //Mover a la derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < 9.5)
                transform.Translate(new Vector2(1, 0) * Time.deltaTime * velocidadDeDesplazamiento);
        }
    }
}
