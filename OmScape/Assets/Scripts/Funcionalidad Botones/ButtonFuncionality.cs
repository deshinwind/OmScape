using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFuncionality : MonoBehaviour
{
    public bool fin;

    public GameObject fundido;

    public panel panel;

    public ObjetosActivos activos;

    private float speed = 0.1f;

    private void Start()
    {
        if (gameObject.name.Equals("Canvas"))
        {
            FindObjectOfType<Inventario>().ComprobarRepetidos();       //Llamamos a la comprobación de los objetos repetidos al cambiar de escena
            FindObjectOfType<Inventario>().ComprobarFotosRepetidas();
        }
        activos = GameObject.Find("Canvas2").GetComponent<ObjetosActivos>();
        panel = GameObject.Find("Canvas2").GetComponent<panel>();
        panel.desactivada = true;
    }

    void Update()
    {
        if (fin)
        {
            print("ey");
            fundido.SetActive(true);
            fundido.GetComponent<Image>().color = new Color(fundido.GetComponent<Image>().color.r, fundido.GetComponent<Image>().color.g, fundido.GetComponent<Image>().color.b , Mathf.Lerp(fundido.GetComponent<Image>().color.a, 1f, speed));
            Invoke("Exit", 1f);
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

    public void Exit()
    {
        SceneManager.LoadScene("Exit");
    }

    public void ButtonExit()
    {
        if (activos  != null)
        {
            if (activos.fusibles)
            {
                fin = true;
            }
        }
    }
    public void mesapc()
    {
        SceneManager.LoadScene("mesaPC");
    }
    public void ButtonH1()
    {
        SceneManager.LoadScene("H1");
    }

    public void ButtonH2()
    {
        SceneManager.LoadScene("H2");
    }

    public void ButtonH3()
    {
        SceneManager.LoadScene("H3");
    }

    public void ButtonH4()
    {
        SceneManager.LoadScene("H4");
    }

    public void ButtonT1()
    {
        if (panel != null)
        {
            if (panel.escaneado)
            {
                SceneManager.LoadScene("T1");
            }
        }
    }

    public void ButtonT2()
    {
        SceneManager.LoadScene("T2");
    }

    public void ButtonT3()
    {
        SceneManager.LoadScene("T3");
    }

    public void ButtonT4()
    {
        SceneManager.LoadScene("T4");
    }

    public void ButtonOrdenador()
    {
        SceneManager.LoadScene("Ordenador");
    }

    public void ButtonBaul()
    {
        SceneManager.LoadScene("Baul");
    }

    public void ButtonMesillaIzquierda()
    {
        SceneManager.LoadScene("Mesita izquierda");
    }

    public void ButtonMesillaDerecha()
    {
        SceneManager.LoadScene("Mesita derecha");
    }

    public void ButtonEscritorioArriba()
    {
        SceneManager.LoadScene("Escritorio arriba");
    }

    public void ButtonSensor()
    {
        SceneManager.LoadScene("panel");
    }
    public void ButtonCajon()
    {
        SceneManager.LoadScene("cajon");
    }
}
