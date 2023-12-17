using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesOrdenador : MonoBehaviour
{
    public GameObject inicio;
    public GameObject narrativa;
    public GameObject posesiones;

    private AlmacenNotas almacen;

    private bool comprobarPosesiones = true;
    private bool comprobarNarrativa = true;

    private void Start()
    {
        almacen = GameObject.Find("Canvas2").GetComponent<AlmacenNotas>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (inicio.activeSelf)
            {
                SceneManager.LoadScene("H3");
            }
            else if (narrativa.activeSelf || posesiones.activeSelf)
            {
                Inicio();
            }
        }
    }
    public void CarpetaNarrativa()
    {
        string nombre;
        inicio.SetActive(false);
        narrativa.SetActive(true);
        if (comprobarNarrativa)
        {
            for (int i = 0; i < almacen.tamañoNarrativa; i++)
            {
                if (!almacen.notasNarrativa[i])
                {
                    nombre = "N" + i;
                    GameObject.Find(nombre).SetActive(false);
                }
            }
            comprobarNarrativa = false;
        }
    }

    public void CarpetaPosesiones()
    {
        string nombre;
        inicio.SetActive(false);
        posesiones.SetActive(true);
        if (comprobarPosesiones)
        {
            for (int i = 0; i < almacen.tamañoPosesion; i++)
            {
                if (!almacen.notasPosesiones[i])
                {
                    nombre = "P" + i;
                    GameObject.Find(nombre).SetActive(false);
                }
            }
            comprobarPosesiones = false;
        }
    }

    public void Inicio()
    {
        narrativa.SetActive(false);
        posesiones.SetActive(false);
        inicio.SetActive(true);
    }

    public void Escape()
    {
        SceneManager.LoadScene("H3");
    }
}
