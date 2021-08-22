using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Color color;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.name.Contains("NaveAlien"))
            {
                if (collision.gameObject.GetComponent<NaveAlien>().colorPropio == color
                    && collision.gameObject.GetComponent<NaveAlien>().estaOperativa)
                {
                    collision.gameObject.GetComponent<NaveAlien>().DestruirNaveAlien();

                    Destroy(gameObject);
                }

                if (collision.gameObject.GetComponent<NaveAlien>().colorPropio != color)
                {
                    Destroy(gameObject);
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
        }               
    }
}
