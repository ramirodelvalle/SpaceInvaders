using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorNaveJugador : MonoBehaviour
{
    public GameObject nave;
    
    public Vector3 posicionInicialDeLaNave;

    void Start()
    {
        InstanciarNave();
    }

    void InstanciarNave()
    {
        int vidas = GameObject.Find("Scripts").GetComponent<MenuJuego>().vidasJugador;
        nave.GetComponent<Nave>().vidasRestantes = vidas;
        Instantiate(nave, posicionInicialDeLaNave, Quaternion.identity);
    }

    public void PrepararNaveParaJugar(GameObject nave)
    {
        nave.GetComponent<NaveJugador>().estaOperativa = true;
        nave.transform.position = posicionInicialDeLaNave;
        nave.GetComponent<SpriteRenderer>().enabled = true;
        nave.GetComponent<BoxCollider2D>().enabled = true;
    }
}
