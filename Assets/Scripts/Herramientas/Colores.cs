using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colores : MonoBehaviour
{
    //Entre azul amarrillo verde rojo
    public Color ObtenerColorAleatorio()
    {
        Color[] colores = new Color[] { Color.blue, Color.yellow, Color.green, Color.red };
        Color colorElegido = colores[Random.Range(0, colores.Length)];

        return colorElegido;
    }
}
