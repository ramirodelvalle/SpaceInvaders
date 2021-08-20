using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorNavesAdyacentes : MonoBehaviour
{
    public GameObject navePadre;
    NaveAlien scriptNavePadre;
    private void Start()
    {
        scriptNavePadre = navePadre.GetComponent<NaveAlien>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!scriptNavePadre.estaOperativa)
        {
            try
            {
                Destroy(gameObject);
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }
    }
}
