using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuJuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PausarJuego()
    {
        Time.timeScale = 0;
    }

    public void ContinuarJuego()
    {
        Time.timeScale = 1;
    }
}
