using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejadorScenas : MonoBehaviour
{
    public void CargarEscenaModoJuego()
    {
        SceneManager.LoadScene("ModoJuego");
    }

    public void CargarEscenaMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
