using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NombreUltimaEscena : MonoBehaviour
{
    public string nombreEscena;
    void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("MenuPausa")) 
        {
            if (nombreEscena == null)
            {
                nombreEscena = SceneManager.GetActiveScene().name;
            }
            else
            {
                if (!nombreEscena.Equals(SceneManager.GetActiveScene().name))
                {
                    nombreEscena = SceneManager.GetActiveScene().name;
                }
            }
        }

        if (Input.GetKeyDown("p"))
        {
            string escena = SceneManager.GetActiveScene().name;
            if (!(escena.Equals("controles") || escena.Equals("MenuPausa") || escena.Equals("menuprincipal") || escena.Equals("Exit")))
            {
                SceneManager.LoadScene("MenuPausa");
            }
        }
    }
}
