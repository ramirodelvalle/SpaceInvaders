using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDestruccionGruposNavesAlien : MonoBehaviour
{
    int contadorGrupos;
    public List<GrupoAlien> listaGruposAlien;
    private int idContadorNavesAlien;

    public class GrupoAlien
    {
        public int idGrupo { get; set; }
        public Color color { get; set; }
        public List<int> idNaves { get; set; }
        public GrupoAlien() { }
        public GrupoAlien(int idGrupo, Color color)
        {
            this.idGrupo = idGrupo;
            this.color = color;
            this.idNaves = new List<int>();
        }
    }

    void Start()
    {
        idContadorNavesAlien = gameObject.GetComponent<InstanciadorAliens>().cantTotalDeAliens - 1;//menos 1 porque el array arranca en 0
        contadorGrupos = 0;
        listaGruposAlien = new List<GrupoAlien>();
        ComienzoDeAgrupacionDeNavesAlien();
    }

    void ComienzoDeAgrupacionDeNavesAlien()
    {
        //int contadorNavesAlienYaAgregadas = 0;
        Color colorGrupoNaveAlien;
        while (idContadorNavesAlien != -1)
        {
            //1
            GameObject gameObjectNaveAlien = GameObject.Find("NaveAlien_" + (idContadorNavesAlien));
            if (gameObjectNaveAlien != null)
            {
                NaveAlien naveAlien = gameObjectNaveAlien.GetComponent<NaveAlien>();
                colorGrupoNaveAlien = naveAlien.colorPropio;

                //1
                int idGrupo = ExisteNaveEnAlgunGrupo(naveAlien);
                if (idGrupo == -1)//la logica de cuando la nave no esta en ningun grupo
                {
                    //tengo q crear un nuevo grupo de naves para esta nave
                    AgregarNuevoGrupoDeNaves(naveAlien.colorPropio);

                    AgregarNaveAGrupoDeNaves(contadorGrupos, naveAlien);

                    ProcesarSiHayNaveALaIzquierda(naveAlien);

                    contadorGrupos++;
                }
            }
            idContadorNavesAlien--;
        }
    }

    public int ExisteNaveEnAlgunGrupo(NaveAlien naveAlien)
    {
        foreach (GrupoAlien grupo in listaGruposAlien)
        {
            //me fijo en cada grupo de la lista si existe el id de la nave
            if (grupo.idNaves.Contains(naveAlien.idNaveAlien))
            {
                return grupo.idGrupo;
            }
        }
        //si no existe quiere decir q no esta en ningun grupo asignado
        return -1;
    }

    public void AgregarNuevoGrupoDeNaves(Color color)
    {
        listaGruposAlien.Add(new GrupoAlien(contadorGrupos, color));
    }

    public void AgregarNaveAGrupoDeNaves(int idGrupo, NaveAlien naveAlien)
    {
        listaGruposAlien.Find(x => x.idGrupo == idGrupo).idNaves.Add(naveAlien.idNaveAlien);
    }

    public int ObtenerIdDelGrupoDeLaNave(NaveAlien naveAlien)
    {
        foreach (var grupo in listaGruposAlien)
        {
            foreach (var ids in grupo.idNaves)
            {
                if (naveAlien.idNaveAlien == ids)
                {
                    return grupo.idGrupo;
                }
            }
        }
        return -1;
    }

    public void ProcesarSiHayNaveALaIzquierda(NaveAlien naveAlien)
    {
        int idNaveABuscar = naveAlien.idNaveAlien + 1;
        if (idNaveABuscar < idContadorNavesAlien)
        {
            GameObject naveIzquierda = GameObject.Find("NaveAlien_" + idNaveABuscar);
            if (naveIzquierda != null)
            {
                //me fijo si esta en la misma fila
                if(naveAlien.transform.position.y == naveIzquierda.transform.position.y)
                {
                    //y si es del mismo color
                    if (naveAlien.colorPropio == naveIzquierda.GetComponent<NaveAlien>().colorPropio)
                    {
                        //ahora me fijo si no esta ya agregada al grupo

                    }
                    
                }
            }
        }
    }

    public void ActualizarGrupoDeNaves(int idGrupo, NaveAlien naveAlien)
    {

    }

    //public int ProcesarNaveParaAlgunGrupo(NaveAlien naveAlien)
    //{
    //    if (ExisteNaveEnAlgunGrupo(color, idNave) == -1)//no existe en ningun grupo
    //    {
    //        listaGruposAlien.Add(new GrupoAlien(contadorGrupos, color, idNave));
    //        return contadorGrupos++;
    //    }
    //    return -1;
    //}
    //quedaria listaGruposAlien[0].idNave = 3

    //crea un nuevo grupo de algun color en especifico

}
