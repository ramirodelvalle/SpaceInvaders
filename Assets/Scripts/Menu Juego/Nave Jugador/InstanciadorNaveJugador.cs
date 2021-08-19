using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorNaveJugador : MonoBehaviour
{
    public GameObject Nave;

    void Start()
    {
        InstanciarNave();
    }

    void InstanciarNave()
    {
        Vector3 pos = new Vector3(0, -5, 0);
        Instantiate(Nave, pos, Quaternion.identity);
    }
}
