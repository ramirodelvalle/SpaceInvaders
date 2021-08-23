using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuJuego : MonoBehaviour
{
    public static MenuJuego esteObjeto = null;
    public int vidasJugador;
    public float segundos = 0;
    public int puntaje;
    public GameObject txtPuntaje;
    public GameObject imgPausa;
    public int cantTotalDeAliens;

    void Start()
    {
        //para llamar la clase desde cualquier lugar
        if (esteObjeto == null) { esteObjeto = this; } else if (esteObjeto != this) { Destroy(gameObject); }

        vidasJugador = PlayerPrefs.GetInt("VidasRestantes");

        ActualizarVidasAlContador(vidasJugador);

        ActualizarPuntaje();
    }

    // Update is called once per frame
    void Update()
    {
        segundos = segundos + Time.timeSinceLevelLoad;
        VerSiApretoTeclaParaPausarJuego();
    }

    public void VerSiApretoTeclaParaPausarJuego()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            PausarJuego();
            MostrarMenuPausa();
        }
    }

    public void MostrarMenuPausa()
    {
        imgPausa.SetActive(true);
    }

    public void PausarJuego()
    {
        Time.timeScale = 0;
    }

    public void ContinuarJuego()
    {
        Time.timeScale = 1;
    }

    public void TerminarJuego()
    {
        GameObject.Find("txtGameOver").GetComponent<Text>().enabled = true;

        PlayerPrefs.SetInt("Puntaje", 0);

        PlayerPrefs.SetInt("VidasRestantes", 3);

        Invoke("VolverAlMenuPrincipal", 2);
    }

    public void ActualizarVidasAlContador(int vidasJugador)
    {
        GameObject.Find("txtContadorVidas").GetComponent<Text>().text = vidasJugador.ToString();
    }

    public void VolverAlMenuPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void ActualizarPuntaje()
    {
        puntaje = PlayerPrefs.GetInt("Puntaje");
        txtPuntaje.GetComponent<Text>().text = puntaje.ToString();
    }

    public void SumarYMostrarPuntajePorNaveAlienDestruida()
    {
        puntaje += 100;
        txtPuntaje.GetComponent<Text>().text = puntaje.ToString();
    }

    public void DescontarNaveAlienPorDestruccion()
    {
        cantTotalDeAliens--;

        VerificarVictoria();
    }

    void VerificarVictoria()
    {
        if (cantTotalDeAliens == 0)
        {
            PlayerPrefs.SetInt("VidasRestantes", vidasJugador);
            PlayerPrefs.SetInt("Puntaje", puntaje);
            SceneManager.LoadScene("ModoJuego");
        }
    }
}
