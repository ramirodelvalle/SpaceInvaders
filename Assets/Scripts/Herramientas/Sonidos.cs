using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour
{
    public static Sonidos esteObjeto = null;
    AudioClip pulsarBoton = null;
    AudioClip laser = null;
    AudioClip explosionNaveJugador = null;
    AudioClip explosionNaveAlien = null;
    void Start()
    {
        //para llamar la clase desde cualquier lugar
        if (esteObjeto == null) { esteObjeto = this; } else if (esteObjeto != this) { Destroy(gameObject); }

        AsignarAudios();
    }

    void AsignarAudios()
    {
        pulsarBoton = (AudioClip)Resources.Load("sonidos/pulsarBoton");
        laser = (AudioClip)Resources.Load("sonidos/laser");
        explosionNaveJugador = (AudioClip)Resources.Load("sonidos/explosionSciFi");
        explosionNaveAlien = (AudioClip)Resources.Load("sonidos/explosionNaveAlien");
    }

    public void ReproducirSonidoPulsarBoton()
    {
        if (pulsarBoton) AudioSource.PlayClipAtPoint(pulsarBoton, transform.position, 1);
    }

    public void ReproducirSonidoLaser()
    {
        if (pulsarBoton) AudioSource.PlayClipAtPoint(laser, transform.position, 1);
    }

    public void ReproducirSonidoExplosionNaveJugador()
    {
        if (explosionNaveJugador) AudioSource.PlayClipAtPoint(explosionNaveJugador, transform.position, 1);
    }
    
    public void ReproducirSonidoExplosionNaveAlien()
    {
        if (explosionNaveAlien) AudioSource.PlayClipAtPoint(explosionNaveAlien, transform.position, 1);
    }
}
