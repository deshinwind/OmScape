using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFuncionality : MonoBehaviour
{
    public bool fin;

    //public GameObject fundido;

    public panel panel;

    public ObjetosActivos activos;

    //private float speed = 0.1f;

    private void Start()
    {
        activos = GameObject.Find("Canvas2").GetComponent<ObjetosActivos>();
        panel = GameObject.Find("Canvas2").GetComponent<panel>();
        panel.desactivada = true;
    }

    void Update()
    {
        if (fin)
        {
            //fundido.SetActive(true);
            //fundido.GetComponent<Image>().color = new Color(fundido.GetComponent<Image>().color.r, fundido.GetComponent<Image>().color.g, fundido.GetComponent<Image>().color.b , Mathf.Lerp(fundido.GetComponent<Image>().color.a, 1f, speed));
            //Invoke("Exit", 1f);
            Exit();
        }

        if (SceneManager.GetActiveScene().name.Equals("cajon"))
        {
            if (Input.GetMouseButtonDown(1) && Time.timeScale == 1)
            {
                SceneManager.LoadScene("T3");
            }
        }
        if (SceneManager.GetActiveScene().name.Equals("Baul") || SceneManager.GetActiveScene().name.Equals("Mesita derecha") || SceneManager.GetActiveScene().name.Equals("Mesita izquierda"))
        {
            if (Input.GetMouseButtonDown(1) && Time.timeScale == 1)
            {
                SceneManager.LoadScene("H2");
            }
        }
        if (SceneManager.GetActiveScene().name.Equals("mesaPC"))
        {
            if (Input.GetMouseButtonDown(1) && Time.timeScale == 1)
            {
                SceneManager.LoadScene("H3");
            }
        }
    }

    public bool ComprobarBloqueador()
    {
        if (GameObject.Find("Bloqueo").GetComponent<BoxCollider2D>().enabled)
        {
            return true;
        }
        return false;
    }


    public void Exit()
    {
        SceneManager.LoadScene("Exit");
    }

    public void ButtonExit()
    {
        if (!ComprobarBloqueador())
        {
            if (activos != null)
            {
                if (activos.fusibles)
                {
                    fin = true;
                }
            }
        }
    }
    public void mesapc()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("mesaPC");
    }
    public void ButtonH1()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("H1");
    }

    public void ButtonH2()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("H2");
    }

    public void ButtonH3()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("H3");
    }

    public void ButtonH4()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("H4");
    }

    public void ButtonT1()
    {
        if (!ComprobarBloqueador())
        {
            if (panel != null)
            {
                if (panel.escaneado)
                {
                    SceneManager.LoadScene("T1");
                }
            }
        }
    }

    public void ButtonT2()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("T2");
    }

    public void ButtonT3()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("T3");
    }

    public void ButtonT4()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("T4");
    }

    public void ButtonOrdenador()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("Ordenador");
    }

    public void ButtonBaul()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("Baul");
    }

    public void ButtonMesillaIzquierda()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("Mesita izquierda");
    }

    public void ButtonMesillaDerecha()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("Mesita derecha");
    }

    public void ButtonEscritorioArriba()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("Escritorio arriba");
    }

    public void ButtonSensor()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("panel");
    }
    public void ButtonCajon()
    {
        if (!ComprobarBloqueador())
            SceneManager.LoadScene("cajon");
    }
    
}
