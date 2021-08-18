using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorAliens : MonoBehaviour
{
    public GameObject Alien;
    // Start is called before the first frame update
    void Start()
    {
        InstanciarUnAlien();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstanciarTodosLosAliens()
    {
        Vector3 pos = new Vector3(0, 10, 0);
        Instantiate(Alien, pos, Quaternion.identity);
    }

    void InstanciarUnAlien()
    {
        Vector3 pos = new Vector3(8, 5, 0);
        Instantiate(Alien, pos, Quaternion.identity);
    }
}
