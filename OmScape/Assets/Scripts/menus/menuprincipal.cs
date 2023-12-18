using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuprincipal : MonoBehaviour
{
    public void jugar()
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene("h1");
    }

    public void Controles()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("controles");

        
    }
    public void Volver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menuprincipal");
    }

    public void salir()
    {
        Application.Quit();
    }
}
