using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorParticulasExplosion : MonoBehaviour
{
    public static InstanciadorParticulasExplosion esteObjeto = null;
    public GameObject particulas;
    void Start()
    {
        //para llamar la clase desde cualquier lugar
        if (esteObjeto == null) { esteObjeto = this; } else if (esteObjeto != this) { Destroy(gameObject); }
    }

    void AsignarElColorALasParticulasDeLaExplosion(Color color)
    {
        ParticleSystemRenderer particleRend = particulas.GetComponent<ParticleSystemRenderer>();
        Material particleMat = particleRend.sharedMaterial;
        particleMat.color = color;
    }

    public void CrearParticulasExplosion(Vector3 posicion, Color color)
    {
        AsignarElColorALasParticulasDeLaExplosion(color);
        Instantiate(particulas, posicion, Quaternion.identity);
    }
}
