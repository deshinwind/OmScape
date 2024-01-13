using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recolectable : MonoBehaviour
{
    public string itemname;

    public Inventario inventario;

    public Sprite spriteObjeto; 

    public MostrarObjetos mostrador;

    public AudioClip sonidoObjeto;

    void Start()
    {
        mostrador = GameObject.Find("Mostrador").GetComponent<MostrarObjetos>();
        inventario = GameObject.Find("Inventario").GetComponent<Inventario>();
    }

    public void EnviarAInventario()     //Envia los objetos de la escena al inventario y los elimina
    {
        inventario.AddItem(gameObject.name, spriteObjeto, gameObject.tag);

        if (inventario.recolectado)
        {
            GameObject.Find("ControladorSonido").GetComponent<ControladorSonido>().EjecutarSonido(sonidoObjeto);

            mostrador.MostrarObjeto(gameObject.name);

            if (gameObject.name.Contains("Fusible"))
            {
                if (gameObject.name.Contains("Azul"))
                {
                    inventario.fusibleAzul = true;
                }
                else if (gameObject.name.Contains("Rojo"))
                {
                    inventario.fusibleRojo = true;
                }
                else if (gameObject.name.Contains("Verde"))
                {
                    inventario.fusibleVerde = true;
                }
                else if (gameObject.name.Contains("Blanco"))
                {
                    inventario.fusibleBlanco = true;
                }
                else if (gameObject.name.Contains("Negro"))
                {
                    inventario.fusibleNegro = true;
                }
                else if (gameObject.name.Contains("Amarillo"))
                {
                    inventario.fusibleAmarillo = true;
                }
            }
            else if (gameObject.name.Equals("Barrena"))
            {
                inventario.barrena = true;
            }

            gameObject.SetActive(false);
        }
    }

    public void Linterna()
    {
        inventario.linterna = true;
        gameObject.SetActive(false);
    }
}
