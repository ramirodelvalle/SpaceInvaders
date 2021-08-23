using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void CargarEscenaModoJuego()
    {
        PlayerPrefs.SetInt("VidasRestantes", 3);
        SceneManager.LoadScene("ModoJuego");
    }
}
