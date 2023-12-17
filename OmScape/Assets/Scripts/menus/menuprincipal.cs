using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuprincipal : MonoBehaviour
{
    public void jugar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("H1");
    }
    public void salir()
    {
        Application.Quit();
    }
}
