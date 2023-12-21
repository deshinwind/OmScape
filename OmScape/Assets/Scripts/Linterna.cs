using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Linterna : MonoBehaviour
{
    public bool linternaActiva;

    public Inventario inventario;

    public ObjetosActivos objetosActivos;

    public Sprite linternaSprite;
    public Sprite luzEncendida;
    public Sprite linternaApagada;

    private void Start()
    {
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Ordenador"))
        {
            LinternaDesactivada();
        }
        if (!objetosActivos.fusibles && !SceneManager.GetActiveScene().name.Equals("Ordenador"))
        {
            LinternaActivada();
        }

    }

    public void LinternaActivada()
    {
        if (inventario.linterna)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = linternaSprite;
            Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            posicionRaton.z = 0.5f;

            transform.position = posicionRaton;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = linternaApagada;
        }
    }

    public void LinternaDesactivada()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = luzEncendida;
        Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        posicionRaton.z = 0.5f;

        transform.position = posicionRaton;
    }
}
