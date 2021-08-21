using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorExplosion : MonoBehaviour
{
    public GameObject explosion;
    public void CrearExplosion(GameObject objetoADisparar, Transform puntoDelDisparo, Vector3 direccionDelDisparo, float fuerzaDelDisparo)
    {
        GameObject nuevoObjetoADisparar = Instantiate(objetoADisparar, puntoDelDisparo.position, puntoDelDisparo.rotation);

        nuevoObjetoADisparar.GetComponent<Rigidbody2D>().AddForce(direccionDelDisparo * fuerzaDelDisparo);

        Destroy(nuevoObjetoADisparar, 2);
    }
}
