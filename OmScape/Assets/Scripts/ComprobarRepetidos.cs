using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComprobarRepetidos : MonoBehaviour
{
    private string nombreEscena;

    private GameObject objeto;
    public GameObject nota;

    public AlmacenNotas almacenNotas;

    public AlmacenObjetos almacenObjetos;

    private List<int> numeroObjeto;
    private List<int> numeroNota;

    private void Update()
    {
        if (nombreEscena == null)
        {
            nombreEscena = SceneManager.GetActiveScene().name;
        }
        else
        {
            if (!nombreEscena.Equals(SceneManager.GetActiveScene().name))
            {
                nombreEscena = SceneManager.GetActiveScene().name;
                ComprobarFotosRepetidas();
                ComprobarObjetosRepetidos();
            }
        }
    }

    public void ComprobarFotosRepetidas() //Este método comprueba si las fotos que están en la escena que acabamos de entrar ya las hemos recogido para no volver a mostrarlas
    {
        numeroNota = new List<int>();
        nota = GameObject.Find("Notas");

        for (int i = 0; i < nota.transform.childCount; i++) //Hace un repaso por todas las notas que hay en la escena contando los "hijos" que tiene el objeto Notas
        {
            if (nota.transform.GetChild(i).name.Contains("P")) //Si la nota es de posesión, comprueba la nota en la lista de notasPosesiones y, si está en la lista, añade la posición de esta nota como hijo del objeto Notas
            {
                switch (nota.transform.GetChild(i).name)
                {
                    case "P0":
                        if (almacenNotas.notasPosesiones[0]) { numeroNota.Add(i); }
                        break;
                    case "P1":
                        if (almacenNotas.notasPosesiones[1]) { numeroNota.Add(i); }
                        break;
                    case "P2":
                        if (almacenNotas.notasPosesiones[2]) { numeroNota.Add(i); }
                        break;
                    case "P3":
                        if (almacenNotas.notasPosesiones[3]) { numeroNota.Add(i); }
                        break;
                    case "P4":
                        if (almacenNotas.notasPosesiones[4]) { numeroNota.Add(i); }
                        break;
                    case "P5":
                        if (almacenNotas.notasPosesiones[5]) { numeroNota.Add(i); }
                        break;
                }
            }
            else if (nota.transform.GetChild(i).name.Contains("N")) // Si la nota es de narrativa, en vez de comprobar en la lista de notasPosesiones, lo hace en la de notasNarrativa
            {
                switch (nota.transform.GetChild(i).name)
                {
                    case "N0":
                        if (almacenNotas.notasNarrativa[0]) { numeroNota.Add(i); }
                        break;
                    case "N1":
                        if (almacenNotas.notasNarrativa[1]) { numeroNota.Add(i); }
                        break;
                    case "N2":
                        if (almacenNotas.notasNarrativa[2]) { numeroNota.Add(i); }
                        break;
                    case "N3":
                        if (almacenNotas.notasNarrativa[3]) { numeroNota.Add(i); }
                        break;
                    case "N4":
                        if (almacenNotas.notasNarrativa[4]) { numeroNota.Add(i); }
                        break;
                }
            }
        }
        for (int i = 0; i < numeroNota.Count; i++) //Una vez revisado todas las notas de la escena, vamos recorriendo la lista auxiliar donde hemos almacenado la posición de cada nota revisada
        {
            nota.transform.GetChild(numeroNota[i]).gameObject.SetActive(false); //Desactivamos cada nota que ya haya sido leida
        }

        if (SceneManager.GetActiveScene().name.Equals("Baul") || SceneManager.GetActiveScene().name.Equals("cajon")) //Si la escena es la del Baul o la del Cajon, desactivamos el objeto Notas, ya que no deben de verse
                                                                                                                     //si el baul o el cajón están cerrados
        {
            nota.SetActive(false);
        }
    }

    public void ComprobarObjetosRepetidos()    //Comprueba si los objetos que están en la escena ya han sido recogidos y los desactiva
    {
        numeroObjeto = new List<int>();
        objeto = GameObject.Find("Objetos");

        for (int i = 0; i < objeto.transform.childCount; i++) //Comprobamos cada objeto de la escena actual
        {
            if (!objeto.transform.GetChild(i).name.Equals("Bufanda") && !objeto.transform.GetChild(i).name.Equals("CajaDeFusibles"))
            {
                almacenObjetos.ComprobarObjeto(objeto.transform.GetChild(i).name);
                if (almacenObjetos.objetoRecogido[(int)(EnumObjetos)System.Enum.Parse(typeof(EnumObjetos), objeto.transform.GetChild(i).name)])
                {
                    numeroObjeto.Add(i);
                }
            }
        }

        for (int i = 0; i < numeroObjeto.Count; i++) //Desactivamos cada objeto que haya sido recogido
        {
            objeto.transform.GetChild(numeroObjeto[i]).gameObject.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name.Equals("Baul") || SceneManager.GetActiveScene().name.Equals("cajon")) //Si la escena es el Baul o el Cajon desactivamos todos los objetos
        {
            objeto.SetActive(false);
        }
    }
}
