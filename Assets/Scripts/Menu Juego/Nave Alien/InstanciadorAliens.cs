﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorAliens : MonoBehaviour
{
    public GameObject Alien;
    private Colores Colores;
    public GameObject paredIzquierda;
    public GameObject paredDerecha;

    void Start()
    {
        Colores = gameObject.AddComponent<Colores>();

        InstanciarContenedorNavesAlien();

        InstanciarTodosLosAliens();
    }

    void InstanciarContenedorNavesAlien()
    {
        GameObject contenedorNavesAlien = new GameObject("ContenedorNavesAliens");
        contenedorNavesAlien.transform.position = new Vector3(0, 0, 0);
    }

    void InstanciarUnAlien()
    {
        var newObj2 = Instantiate(Alien, new Vector3(0, 7, 0), Quaternion.identity);
        newObj2.transform.parent = GameObject.Find("ContenedorNavesAliens").transform;
    }

    void InstanciarTodosLosAliens()
    {
        float posX = -7;
        float posY = 5;
        Vector3 pos = new Vector3(posX, posY, 0);
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                InstanciarUnAlien(pos);
                pos.x += 1.2f;
            }
            pos.y += -1;
            pos.x = posX;
        }
    }

    void InstanciarUnAlien(Vector3 pos)
    {
        GameObject contenedorNavesAlien = GameObject.Find("ContenedorNavesAlien");

        var nuevaNaveAlien = GameObject.Instantiate(Alien, pos, Quaternion.identity);
        nuevaNaveAlien.transform.parent = contenedorNavesAlien.transform;

        nuevaNaveAlien.GetComponent<SpriteRenderer>().color = Colores.ObtenerColorAleatorio();

        nuevaNaveAlien.GetComponent<NaveAlien>().paredIzquierda = paredIzquierda;
        nuevaNaveAlien.GetComponent<NaveAlien>().paredDerecha = paredDerecha;
    }
}
