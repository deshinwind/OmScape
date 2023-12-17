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

    void Update()
    {
        CambioEscena();

        if (linternaActiva)
        {
            gameObject.SetActive(true);
            Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            posicionRaton.z = 0.5f;

            transform.position = posicionRaton;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void CambioEscena()
    {
        if (SceneManager.GetActiveScene().name.Equals("Ordenador"))
        {
            linternaActiva = false;
        }
        else
        {
            linternaActiva = true;
        }
    }
}
