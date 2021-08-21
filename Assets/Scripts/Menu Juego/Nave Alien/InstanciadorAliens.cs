﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorAliens : MonoBehaviour
{
    public GameObject Alien;
    private Colores Colores;
    public GameObject paredIzquierda;
    public GameObject paredDerecha;
    public int cantTotalDeAliens;
    void Start()
    {
        //cantTotalDeAliens = 0;

        Colores = gameObject.AddComponent<Colores>();

        InstanciarTodosLosAliens();
    }

    void InstanciarUnAlien()
    {
        var newObj2 = Instantiate(Alien, new Vector3(0, 7, 0), Quaternion.identity);
        newObj2.transform.parent = GameObject.Find("ContenedorNavesAliens").transform;
    }

    void InstanciarTodosLosAliens()
    {
        int id = 0;
        float posX = -7;
        float posY = 5;
        Vector3 pos = new Vector3(posX, posY, 0);
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                InstanciarUnAlien(pos, id);
                pos.x += 1.2f;
                id++;
            }
            pos.y += -1;
            pos.x = posX;
        }
        cantTotalDeAliens = id;
    }

    void InstanciarUnAlien(Vector3 pos, int id)
    {
        GameObject contenedorNavesAlien = GameObject.Find("ContenedorNavesAlien");

        var nuevaNaveAlien = GameObject.Instantiate(Alien, pos, Quaternion.identity);
        nuevaNaveAlien.name = "NaveAlien_" + id;
        nuevaNaveAlien.transform.parent = contenedorNavesAlien.transform;

        nuevaNaveAlien.GetComponent<SpriteRenderer>().color = Colores.ObtenerColorAleatorio();
        //nuevaNaveAlien.GetComponent<SpriteRenderer>().color = Color.red;

        nuevaNaveAlien.GetComponent<NaveAlien>().paredIzquierda = paredIzquierda;
        nuevaNaveAlien.GetComponent<NaveAlien>().paredDerecha = paredDerecha;
    }
}
