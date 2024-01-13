using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.U2D;

public class Notas : MonoBehaviour
{
    public AlmacenNotas almacen;

    public AudioClip sonidoHojas;

    private void Start()
    {
        almacen = GameObject.Find("Canvas2").GetComponent<AlmacenNotas>();
    }

    public void EnviarAlAlmacen()
    {
        if (gameObject.name.Equals("NotaFalsa"))
        {
            almacen.MostrarNota(gameObject.name);
        }
        else
        {
            almacen.MostrarNota(gameObject.name);
            almacen.ComprobarNota(gameObject.tag, gameObject.name);
            gameObject.SetActive(false);
        }

        GameObject.Find("ControladorSonido").GetComponent<ControladorSonido>().EjecutarSonido(sonidoHojas);
    }
}
