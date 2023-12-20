using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarJuego : MonoBehaviour
{
    public GameObject pausarJuego;
    public bool pausado;
    
    private void Update()
    {
        if (pausarJuego.GetComponent<BoxCollider2D>().enabled)
        {
            Time.timeScale = 0;
        }
    }

    public void PauseGame()
    {
        pausarJuego.GetComponent<BoxCollider2D>().enabled = true;
    }
}
