using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSonido : MonoBehaviour
{
    public AudioClip hojas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Narrativa") || collision.CompareTag("Posesiones"))
        {
            //ControladorSonido.instance.EjecutarSonido(hojas);
            //GameObject.Find("ControladorSonido").GetComponent<ControladorSonido>().EjecutarSonido(hojas);
        }
    }
}
