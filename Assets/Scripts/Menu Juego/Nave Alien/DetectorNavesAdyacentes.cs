using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorNavesAdyacentes : MonoBehaviour
{
    public GameObject navePadre;
    public List<GameObject> navesAdyacentes;

    private void Start()
    {
        navePadre = gameObject.transform.parent.gameObject;
        navesAdyacentes = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("DetectorAdyacente"))
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == navePadre.GetComponent<SpriteRenderer>().color)
            {
                navesAdyacentes.Add(collision.gameObject.transform.parent.gameObject);
                Debug.Log("soy nave "+ navePadre.name +" agregue nave del mismo color es la nave " + collision.gameObject.name);
            }
        }
    }

    public void EliminarNavesAdyacentes()
    {
        foreach (var item in navesAdyacentes)
        {
            item.GetComponent<NaveAlien>().DestruirNaveAlien();
        }
    }
}
