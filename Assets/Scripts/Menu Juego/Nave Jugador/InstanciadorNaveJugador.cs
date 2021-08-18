using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorNaveJugador : MonoBehaviour
{
    public GameObject Nave;
    // Start is called before the first frame update
    void Start()
    {
        InstanciarNave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstanciarNave()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        Instantiate(Nave, pos, Quaternion.identity);
    }
}
