using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BotonesOrdenador : MonoBehaviour
{
    public GameObject inicio;
    public GameObject narrativa;
    public GameObject posesiones;

    public GameObject[] nar;
    public GameObject[] pos;

    private bool notaActiva;
    private bool comprobarPosesiones = true;
    private bool comprobarNarrativa = true;

    private string nota;

    private AlmacenNotas almacen;

    private void Start()
    {
        almacen = GameObject.Find("Canvas2").GetComponent<AlmacenNotas>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.timeScale == 1)
        {
            if (notaActiva)
            {
                DesactivarNota();
                notaActiva = false;
            }
            else if (narrativa.activeSelf || posesiones.activeSelf)
            {
                Inicio();
            }
            else if (inicio.activeSelf)
            {
                SceneManager.LoadScene("H3");
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

    
    public void NotaNar()
    {
        notaActiva = true;
        nota = EventSystem.current.currentSelectedGameObject.name;
        switch (nota)
        {
            case "N0":
                nar[0].SetActive(true);
                break;
            case "N1":
                nar[1].SetActive(true);
                break;
            case "N2":
                nar[2].SetActive(true);
                break;
            case "N3":
                nar[3].SetActive(true);
                break;
            case "N4":
                nar[4].SetActive(true);
                break;
        }
    }
    public void NotaPos()
    {
        notaActiva = true;
        nota = EventSystem.current.currentSelectedGameObject.name;

        switch (nota)
        {
            case "P0":
                pos[0].SetActive(true);
                break;
            case "P1":
                pos[1].SetActive(true);
                break;
            case "P2":
                pos[2].SetActive(true);
                break;
            case "P3":
                pos[3].SetActive(true);
                break;
            case "P4":
                pos[4].SetActive(true);
                break;
            case "P5":
                pos[5].SetActive(true);
                break;
        }
    }

    public void DesactivarNota()
    {
        switch (nota)
        {
            case "N0":
                nar[0].SetActive(false);
                break;
            case "N1":
                nar[1].SetActive(false);
                break;
            case "N2":
                nar[2].SetActive(false);
                break;
            case "N3":
                nar[3].SetActive(false);
                break;
            case "N4":
                nar[4].SetActive(false);
                break;
            case "P0":
                pos[0].SetActive(false);
                break;
            case "P1":
                pos[1].SetActive(false);
                break;
            case "P2":
                pos[2].SetActive(false);
                break;
            case "P3":
                pos[3].SetActive(false);
                break;
            case "P4":
                pos[4].SetActive(false);
                break;
            case "P5":
                pos[5].SetActive(false);
                break;
        }
    }

    public void Escape()
    {
        SceneManager.LoadScene("H3");
    }
}
