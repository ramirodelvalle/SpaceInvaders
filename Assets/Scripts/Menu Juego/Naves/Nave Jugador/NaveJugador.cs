using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJugador : Nave
{
    public GameObject naveAlien;
    public GameObject laserAlien;
    public bool estaOperativa = true;
    void Update()
    {
        PulsoTeclaEspacio();
    }

    public void PulsoTeclaEspacio()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaOperativa)
        {
            Sonidos.esteObjeto.ReproducirSonidoLaser();
            SistemaDisparo sistemaDisparo = gameObject.GetComponent<SistemaDisparo>();
            sistemaDisparo.DispararObjeto(ObjetoADisparar, PuntoDeDisparo, new Vector3(0, fuerzaDelDisparo, 0), 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.name.Contains(naveAlien.name) && collision.gameObject.GetComponent<NaveAlien>().estaOperativa
                || collision.gameObject.name.Contains(laserAlien.name))
            {
                DestruirNave();
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error en " + ex.Message);
        }
    }

    public void DestruirNave()
    {
        Sonidos.esteObjeto.ReproducirSonidoExplosionNaveJugador();
        estaOperativa = false;
        vidasRestantes--;
        MenuJuego.esteObjeto.vidasJugador--;
        GameObject.Find("Scripts").GetComponent<MenuJuego>().ActualizarVidasAlContador(vidasRestantes);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        InstanciadorParticulasExplosion.esteObjeto.CrearParticulasExplosion(gameObject.transform.position, Color.green);
        if (vidasRestantes == 0)
        {
            MenuJuego.esteObjeto.TerminarJuego();
        }
        else
        {
            Invoke("PosicionarNaveParaJugar", 1);
        }
    }

    void PosicionarNaveParaJugar()
    {
        GameObject.Find("Scripts").GetComponent<InstanciadorNaveJugador>().PrepararNaveParaJugar(gameObject);
    }
}
