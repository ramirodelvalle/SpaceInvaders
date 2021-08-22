using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorAliens : MonoBehaviour
{
    public GameObject Alien;
    private Colores Colores;
    public GameObject paredIzquierda;
    public GameObject paredDerecha;
    public int cantTotalDeAliens;
    public int cantAliensPorFila;
    public int cantFilasDeAliens;
    public float posX;
    public float posY;
    void Start()
    {
        //cantTotalDeAliens = 0;

        Colores = gameObject.AddComponent<Colores>();

        InstanciarTodosLosAliens();
    }

    void InstanciarTodosLosAliens()
    {
        int id = 0;
        Vector3 pos = new Vector3(posX, posY, 0);
        for (int i = 0; i < cantFilasDeAliens; i++)
        {
            for (int j = 0; j < cantAliensPorFila; j++)
            {
                InstanciarUnAlien(pos, id);
                pos.x += 1.8f;
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

        Color colorAleatorio = Colores.ObtenerColorAleatorio();
        //nuevaNaveAlien.GetComponent<SpriteRenderer>().color = colorAleatorio;
        //nuevaNaveAlien.GetComponent<SpriteRenderer>().color = Color.red;

        nuevaNaveAlien.GetComponent<NaveAlien>().colorPropio = colorAleatorio;

        nuevaNaveAlien.GetComponent<NaveAlien>().paredIzquierda = paredIzquierda;
        nuevaNaveAlien.GetComponent<NaveAlien>().paredDerecha = paredDerecha;
    }
}
