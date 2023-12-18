using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.U2D;

public class Notas : MonoBehaviour
{
    //public bool pausado;
    public AlmacenNotas almacen;

    private void Start()
    {
        almacen = GameObject.Find("Canvas2").GetComponent<AlmacenNotas>();
    }

    public void EnviarAlAlmacen()
    {
        almacen.MostrarNota(gameObject.name);
        //Time.timeScale = 0f;
        //pausado = true;
        almacen.ComprobarNota(gameObject.tag, gameObject.name);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    public void MostrarNotaFalsa()
    {
        almacen.MostrarNota(gameObject.name);
    }
}
