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
    public Color colorPropio;
    public bool estaOperativa { get; set; }

    public float tiempoRestanteParaSiguienteDisparo;
    public bool bNaceMuerta;//TODO sacar esto

    private void Start()
    {
        estaOperativa = true;
        tiempoRestanteParaSiguienteDisparo = Random.Range(1f, 3f);

        if (gameObject.name.Contains("_"))
        {
            nombreNaveAlien = gameObject.name.Split('_')[0];
            idNaveAlien = int.Parse(gameObject.name.Split('_')[1]);
        }
        //colorPropio = gameObject.GetComponent<SpriteRenderer>().color;

        gameObject.GetComponent<SpriteRenderer>().color = colorPropio;

        ObjetoExplotar.gameObject.GetComponent<SpriteRenderer>().color = colorPropio;

        if (bNaceMuerta)
        {
            DestruirNaveAlien();
        }
    }

    void Update()
    {
        CalcularTiempoRestanteParaSiguienteDisparo();
    }

    void CalcularTiempoRestanteParaSiguienteDisparo()
    {
        if (tiempoRestanteParaSiguienteDisparo <= Time.time)
        {
            tiempoRestanteParaSiguienteDisparo += Random.Range(1f, 3f);

            if (estaOperativa)
            {
                if (dispararLaser)
                {
                    if (!HayAlgunaNaveAlienPorDebajo())
                    {
                        DispararLaser();
                    }
                }
            }
        }
    }

    public void DispararLaser()
    {
        gameObject.GetComponent<SistemaDisparo>().DispararObjeto(ObjetoADisparar, PuntoDeDisparo, new Vector3(0, fuerzaDelDisparo * -1, 0), 1);
    }

    bool HayAlgunaNaveAlienPorDebajo()
    {
        try
        {
            bool estaOperativaLaNave = false;
            int cantidadDeNavesAlienPorFila = GameObject.Find("Scripts").GetComponent<InstanciadorAliens>().cantAliensPorFila;
            int cantidadFilasDeAliens = GameObject.Find("Scripts").GetComponent<InstanciadorAliens>().cantFilasDeAliens;

            for (int i = 1; i <= cantidadFilasDeAliens; i++)
            {
                GameObject naveDeAbajo = GameObject.Find(nombreNaveAlien + "_" +
                    (idNaveAlien + cantidadDeNavesAlienPorFila * i));
                if (naveDeAbajo != null)
                {
                    estaOperativaLaNave = naveDeAbajo.GetComponent<NaveAlien>().estaOperativa;
                    if (estaOperativaLaNave)
                    {
                        return estaOperativaLaNave;
                    }
                }
            }
            return false;
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.name.Contains(paredIzquierda.name) || collision.gameObject.name.Contains(paredDerecha.name))
            {
                if (estaOperativa)
                {
                    MovimientoContenedorNavesAlien scriptContenedorNavesAlien =
                        GameObject.Find("ContenedorNavesAlien").GetComponent<MovimientoContenedorNavesAlien>();

                    scriptContenedorNavesAlien.CambiarDireccionDelMovimiento();
                }
            }

            if (collision.gameObject.name.Contains(laserNaveJugador.name) && estaOperativa)
            {
                DestruirNaveAlien();
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    public void DestruirNaveAlien()
    {
        estaOperativa = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

        Explotar();
    }

    ///funcion que lanza 4 objetos en las 4 direciones para destruir naves adyacentes del mismo color
    public void Explotar()
    {
        float fuerzaExplosion = 2000;
        List<Vector3> direcciones = new List<Vector3>();
        direcciones.Add(new Vector3(fuerzaExplosion * -1, 0, 0)); //izquierda
        direcciones.Add(new Vector3(fuerzaExplosion * 1, 0, 0)); //derecha
        direcciones.Add(new Vector3(0, fuerzaExplosion * 1, 0)); //arriba
        direcciones.Add(new Vector3(0, fuerzaExplosion * -1, 0)); //abajo

        foreach (var item in direcciones)
        {
            ExplotarEnDireccion(item);
        }
    }

    public void ExplotarEnDireccion(Vector3 direccion)
    {
        ObjetoExplotar.GetComponent<SpriteRenderer>().color = colorPropio;
        ObjetoExplotar.GetComponent<Explosion>().color = colorPropio;
        SistemaDisparo sistemaDisparo = gameObject.AddComponent<SistemaDisparo>();
        sistemaDisparo.DispararObjeto(ObjetoExplotar, gameObject.transform, direccion, 1);
    }
}
