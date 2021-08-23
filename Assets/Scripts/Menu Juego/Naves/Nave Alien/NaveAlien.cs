using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveAlien : Nave
{
    public GameObject ObjetoExplotar;
    public GameObject paredIzquierda;
    public GameObject paredDerecha;
    public GameObject laserNaveJugador;
    public bool dispararLaser;
    string nombreNaveAlien;
    public int idNaveAlien;
    public Color colorPropio;
    public bool estaOperativa;
    public float tiempoRestanteParaSiguienteDisparo;

    private void Start()
    {
        estaOperativa = true;
        tiempoRestanteParaSiguienteDisparo = Time.timeSinceLevelLoad + Random.Range(1f, 3f);

        if (gameObject.name.Contains("_"))
        {
            nombreNaveAlien = gameObject.name.Split('_')[0];
            idNaveAlien = int.Parse(gameObject.name.Split('_')[1]);
        }

        gameObject.GetComponent<SpriteRenderer>().color = colorPropio;

        ObjetoExplotar.gameObject.GetComponent<SpriteRenderer>().color = colorPropio;

        AsignarVidaSegunColor();
    }

    void Update()
    {
        CalcularTiempoRestanteParaSiguienteDisparo();
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

            AlSerImpactadoPorLaserDelJugador(collision);
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    void AlSerImpactadoPorLaserDelJugador(Collider2D collision)
    {
        if (collision.gameObject.name.Contains(laserNaveJugador.name) && estaOperativa)
        {
            vidasRestantes--;
            if (vidasRestantes == 0)
            {
                DestruirNaveAlien();
            }
        }
    }

    void CalcularTiempoRestanteParaSiguienteDisparo()
    {
        if (tiempoRestanteParaSiguienteDisparo <= Time.timeSinceLevelLoad)
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
            int cantidadFilasDeAliens = InstanciadorAliens.esteObjeto.cantAliensPorFila;

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

    public void DestruirNaveAlien()
    {
        InstanciadorParticulasExplosion.esteObjeto.CrearParticulasExplosion(gameObject.transform.position, colorPropio);

        Sonidos.esteObjeto.ReproducirSonidoExplosionNaveAlien();
        estaOperativa = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        MenuJuego.esteObjeto.SumarYMostrarPuntajePorNaveAlienDestruida();
        MenuJuego.esteObjeto.DescontarNaveAlienPorDestruccion();
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
        SistemaDisparo sistemaDisparo = gameObject.GetComponent<SistemaDisparo>();
        sistemaDisparo.DispararObjeto(ObjetoExplotar, gameObject.transform, direccion, 1);
    }

    void AsignarVidaSegunColor()
    {
        try
        {
            vidasRestantes = 1;
            if (colorPropio == Color.red || colorPropio == Color.yellow) vidasRestantes = 2;
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
}
