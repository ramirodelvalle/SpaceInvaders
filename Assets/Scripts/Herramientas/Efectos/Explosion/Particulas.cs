using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
{
    void Start()
    {

        Invoke("DestruirObjeto", 0.3f);
    }

    void DestruirObjeto()
    {
        Destroy(gameObject);
    }
}
