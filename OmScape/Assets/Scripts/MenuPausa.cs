using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    private string nombreEscena;

    public void VolverAlJuego()
    {
        SceneManager.LoadScene(GameObject.Find("Menu").GetComponent<NombreUltimaEscena>().nombreEscena);
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("menuprincipal");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
