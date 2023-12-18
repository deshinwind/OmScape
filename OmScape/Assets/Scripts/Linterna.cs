using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Linterna : MonoBehaviour
{
    //public GameObject linterna;
    public bool linternaActiva;
    public Inventario inventario;

    public Sprite linternaSprite;
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
        else
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
    }

    public void LinternaDesactivada()
    {
        if (inventario.linterna)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = linternaApagada;
            Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            posicionRaton.z = 0.5f;

            transform.position = posicionRaton;
        }
    }
}
