using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstanciadorAliens : MonoBehaviour
{
    public static InstanciadorAliens esteObjeto;
    public GameObject Alien;
    private Colores Colores;
    public GameObject paredIzquierda;
    public GameObject paredDerecha;
    public int cantAliensPorFila;
    public int cantFilasDeAliens;
    public float posX;
    public float posY;

    void Start()
    {
        //para llamar la clase desde cualquier lugar
        if (esteObjeto == null) { esteObjeto = this; } else if (esteObjeto != this) { Destroy(gameObject); }

        Colores = gameObject.AddComponent<Colores>();

        Invoke("InstanciarTodosLosAliens", 0.5f);
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
        MenuJuego.esteObjeto.cantTotalDeAliens = id;
    }

    void InstanciarUnAlien(Vector3 pos, int id)
    {
        GameObject contenedorNavesAlien = GameObject.Find("ContenedorNavesAlien");

        var nuevaNaveAlien = Instantiate(Alien, pos, Quaternion.identity);
        nuevaNaveAlien.name = "NaveAlien_" + id;
        nuevaNaveAlien.transform.parent = contenedorNavesAlien.transform;

        Color colorAleatorio = Colores.ObtenerColorAleatorio();

        nuevaNaveAlien.GetComponent<NaveAlien>().colorPropio = colorAleatorio;

        nuevaNaveAlien.GetComponent<NaveAlien>().paredIzquierda = paredIzquierda;
        nuevaNaveAlien.GetComponent<NaveAlien>().paredDerecha = paredDerecha;
    }
}
