using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.name.Contains("NaveAlien"))
            {
                if (collision.gameObject.GetComponent<NaveAlien>().colorPropio == gameObject.GetComponent<SpriteRenderer>().color
                    && collision.gameObject.GetComponent<NaveAlien>().estaOperativa)
                {
                    collision.gameObject.GetComponent<NaveAlien>().DestruirNaveAlien();

                    Debug.Log("me destrui explosion");
                    Destroy(gameObject);
                }

                if (collision.gameObject.GetComponent<NaveAlien>().colorPropio != gameObject.GetComponent<SpriteRenderer>().color)
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
