using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJugador : MonoBehaviour
{
    public GameObject ObjetoADisparar;
    public Transform PuntoDeDisparo;
    public float fuerzaDelDisparo;

    void Start()
    {

    }

    void Update()
    {
        PulsoTeclaEspacio();
    }

    public void PulsoTeclaEspacio()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SistemaDisparo sistemaDisparo = new SistemaDisparo();
            sistemaDisparo.DispararObjeto(ObjetoADisparar, PuntoDeDisparo, new Vector3(0, fuerzaDelDisparo, 0), 1);
        }
    }
}
