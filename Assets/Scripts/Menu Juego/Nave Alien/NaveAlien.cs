using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveAlien : MonoBehaviour
{
    public GameObject ObjetoADisparar;
    public GameObject ObjetoExplotar;
    public Transform PuntoDeDisparo;
    public float fuerzaDelDisparo;
    public GameObject paredIzquierda;
    public GameObject paredDerecha;
    public GameObject laserNaveJugador;
    public bool dispararLaser;
    string nombreNaveAlien;
    public int idNaveAlien;
    public Color colorPropio { get; set; }
    public bool estaOperativa { get; set; }

    public float tiempoRestanteParaSiguienteDisparo;

    private void Start()
    {
        estaOperativa = true;
        tiempoRestanteParaSiguienteDisparo = 3;

        if (gameObject.name.Contains("_"))
        {
            nombreNaveAlien = gameObject.name.Split('_')[0];
            //idNaveAlien = int.Parse(gameObject.name.Split('_')[1]);
        }
        colorPropio = gameObject.GetComponent<SpriteRenderer>().color;

        ObjetoExplotar.gameObject.GetComponent<SpriteRenderer>().color = colorPropio;
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

            GameObject naveDeAbajo = GameObject.Find(nombreNaveAlien + "_" + (idNaveAlien + cantidadDeNavesAlienPorFila));
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
                Debug.Log("me destrui");
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }
    }

    public void DestruirNaveAlien()
    {
        estaOperativa = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

        Explotar();
    }

    public void Explotar()
    {
        List<Vector3> direcciones = new List<Vector3>();
        direcciones.Add(new Vector3(fuerzaDelDisparo * -1, 0, 0));//izquierda
        direcciones.Add(new Vector3(fuerzaDelDisparo * 1, 0, 0));//derecha
        direcciones.Add(new Vector3(0, fuerzaDelDisparo * 1, 0));//arriba
        direcciones.Add(new Vector3(0, fuerzaDelDisparo * -1, 0));//abajo

        foreach (var item in direcciones)
        {
            ExplotarEnDireccion(item);
        }
    }

    public void ExplotarEnDireccion(Vector3 direccion)
    {
        ObjetoExplotar.GetComponent<SpriteRenderer>().color = colorPropio;
        SistemaDisparo sistemaDisparo = gameObject.AddComponent<SistemaDisparo>();
        sistemaDisparo.DispararObjeto(ObjetoExplotar, gameObject.transform, direccion, 1);
    }
}
