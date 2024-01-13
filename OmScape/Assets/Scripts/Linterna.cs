using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Linterna : MonoBehaviour
{
    public bool linternaActiva = false;

    public Inventario inventario;

    public ObjetosActivos objetosActivos;

    public Sprite linternaSprite;
    public Sprite luzEncendida;
    public Sprite linternaApagada;

    public float chocolate;

    private void Start()
    {
        inventario = GameObject.Find("Inventario").GetComponent<Inventario>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Ordenador") || SceneManager.GetActiveScene().name.Equals("controles") || SceneManager.GetActiveScene().name.Equals("MenuPausa") || SceneManager.GetActiveScene().name.Equals("menuprincipal"))
        {
            LinternaDesactivada();
        }
        if (!objetosActivos.fusibles && !SceneManager.GetActiveScene().name.Equals("Ordenador") && !SceneManager.GetActiveScene().name.Equals("controles") && !SceneManager.GetActiveScene().name.Equals("MenuPausa") && !SceneManager.GetActiveScene().name.Equals("menuprincipal"))
        {
            if (!linternaActiva && inventario.linterna)
            {
                linternaActiva = true;
                LinternaActivada();
            }
            if (linternaActiva)
            {
                Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                posicionRaton.z = chocolate;
                
                transform.position = posicionRaton;
            }
            
        }
    }

    public void LinternaActivada()
    {
        if (inventario.linterna)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = linternaSprite;

            //gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

            Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            posicionRaton.z = 0.5f;

            transform.position = posicionRaton;
        }
        /*else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = linternaApagada;
        }*/
    }

    public void LinternaDesactivada()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = luzEncendida;
        Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        posicionRaton.z = 0.5f;

        transform.position = posicionRaton;
    }
}
