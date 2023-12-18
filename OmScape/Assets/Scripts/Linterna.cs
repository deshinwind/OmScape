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

    private void Start()
    {
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
    }

    void Update()
    {
        //CambioEscena();

        if (inventario.linterna)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = linternaSprite;
            Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            posicionRaton.z = 0.5f;

            transform.position = posicionRaton;
        }
        /*else
        {
            gameObject.SetActive(false);
        }*/
    }

    /*public void CambioEscena()
    {
        if (SceneManager.GetActiveScene().name.Equals("Ordenador"))
        {
            linternaActiva = false;
        }
        else
        {
            linternaActiva = true;
        }
    }*/
}
