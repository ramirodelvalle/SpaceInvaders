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
    public GameObject laserNaveJugador;
    public bool dispararLaser;
    string nombreNaveAlien;
    int posNaveAlien;
    Color colorPropio;
    public bool estaOperativa { get; set; }

    public float tiempoRestanteParaSiguienteDisparo;

    private void Start()
    {
        estaOperativa = true;
        tiempoRestanteParaSiguienteDisparo = 3;

        if (gameObject.name.Contains("_"))
        {
            nombreNaveAlien = gameObject.name.Split('_')[0];
            posNaveAlien = int.Parse(gameObject.name.Split('_')[1]);
        }
        colorPropio = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        CalcularTiempoRestanteParaSiguienteDisparo();
    }

    void CalcularTiempoRestanteParaSiguienteDisparo()
    {
        if (tiempoRestanteParaSiguienteDisparo <= Time.time)
        {
            tiempoRestanteParaSiguienteDisparo = Time.time + Random.Range(1, 1);

            if (!HayAlgunaNaveAlienPorDebajo())
            {
                if (dispararLaser)
                {
                    DispararLaser();
                }
            }
        }
    }

    public void DispararLaser()
    {
        SistemaDisparo sistemaDisparo = gameObject.AddComponent<SistemaDisparo>();
        sistemaDisparo.DispararObjeto(ObjetoADisparar, PuntoDeDisparo, new Vector3(0, fuerzaDelDisparo * -1, 0), 1);
    }

    bool HayAlgunaNaveAlienPorDebajo()
    {
        try
        {
            bool estaOperativaLaNave = false;
            int cantidadDeNavesAlienPorFila = 13;

            GameObject naveDeAbajo = GameObject.Find(nombreNaveAlien + "_" + (posNaveAlien + cantidadDeNavesAlienPorFila));
            if (naveDeAbajo != null)
            {
                estaOperativaLaNave = naveDeAbajo.GetComponent<NaveAlien>().estaOperativa;
            }

            return estaOperativaLaNave;
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains(paredIzquierda.name) || collision.gameObject.name.Contains(paredDerecha.name))
        {
            try
            {
                MovimientoContenedorNavesAlien scriptContenedorNavesAlien =
                    GameObject.Find("ContenedorNavesAlien").GetComponent<MovimientoContenedorNavesAlien>();

                scriptContenedorNavesAlien.CambiarDireccionDelMovimiento();
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }

        if (collision.gameObject.name.Contains(laserNaveJugador.name))
        {
            try
            {
                DestruirNaveAlien();
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }
    }

    void DestruirNavesAlienAdyacentes()
    {
        try
        {
            bool estaOperativaLaNave = false;
            Color colorNaveAlien;
            int cantidadDeNavesAlienPorFila = 2;
            NaveAlien scriptNaveAlien;

            GameObject naveDeArriba = GameObject.Find(nombreNaveAlien + "_" + (posNaveAlien - cantidadDeNavesAlienPorFila));
            if (naveDeArriba != null)
            {
                scriptNaveAlien = naveDeArriba.GetComponent<NaveAlien>();
                estaOperativaLaNave = naveDeArriba.GetComponent<NaveAlien>().estaOperativa;
                colorNaveAlien = naveDeArriba.GetComponent<SpriteRenderer>().color;
                if (estaOperativaLaNave && colorPropio == colorNaveAlien)
                {
                    scriptNaveAlien.DestruirNavesAlienAdyacentes();
                }
            }

            GameObject naveDeLaDerecha = GameObject.Find(nombreNaveAlien + "_" + (posNaveAlien + 1));
            if (naveDeLaDerecha != null)
            {
                scriptNaveAlien = naveDeLaDerecha.GetComponent<NaveAlien>();
                scriptNaveAlien.DestruirNavesAlienAdyacentes();
            }

            GameObject naveDeLaIzquierda = GameObject.Find(nombreNaveAlien + "_" + (posNaveAlien - 1));
            if (naveDeLaIzquierda != null)
            {
                scriptNaveAlien = naveDeLaIzquierda.GetComponent<NaveAlien>();
                scriptNaveAlien.DestruirNavesAlienAdyacentes();
            }
            DestruirNaveAlien();
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    void DestruirNaveAlien()
    {
        estaOperativa = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
