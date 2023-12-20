using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recolectable : MonoBehaviour
{
    [SerializeField] private string itemname;
    [SerializeField] private Sprite sprite;

    private Inventario inventario;

    void Start()
    {
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
    }
    public void EnviarAInventario()     //Envia los objetos de la escena al inventario y los elimina
    {
        if (gameObject.name.Contains("Fusible"))
        {
            if (gameObject.name.Contains("Azul"))
            {
                inventario.fusibleAzul = true;
                inventario.AddItem(gameObject.name, sprite, gameObject.tag);
            }
            else if (gameObject.name.Contains("Rojo"))
            {
                inventario.fusibleRojo = true;
                inventario.AddItem(gameObject.name, sprite, gameObject.tag);
            }
            else if (gameObject.name.Contains("Verde"))
            {
                inventario.fusibleVerde = true;
                inventario.AddItem(gameObject.name, sprite, gameObject.tag);
            }
            else if (gameObject.name.Contains("Blanco"))
            {
                inventario.fusibleBlanco = true;
                inventario.AddItem(gameObject.name, sprite, gameObject.tag);
            }
            else if (gameObject.name.Contains("Negro"))
            {
                inventario.fusibleNegro = true;
                inventario.AddItem(gameObject.name, sprite, gameObject.tag);
            }
            else if (gameObject.name.Contains("Amarillo"))
            {
                inventario.fusibleAmarillo = true;
                inventario.AddItem(gameObject.name, sprite, gameObject.tag);
            }
        }
        else if (gameObject.name.Equals("Barrena"))
        {
            inventario.barrena = true;
            inventario.AddItem(gameObject.name, sprite, gameObject.tag);
        }
        else
        {
            inventario.AddItem(gameObject.name, sprite, gameObject.tag);
        }
        
        if (inventario.recolectado)         //Comprueba que se ha enviado al inventario antes de eliminarlo
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    public void Linterna()
    {
        inventario.linterna = true;
        
        GameObject.Find("Linterna").transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
