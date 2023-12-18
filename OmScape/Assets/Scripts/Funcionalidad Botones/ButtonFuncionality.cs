using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFuncionality : MonoBehaviour
{
    public panel panel;
    private void Start()
    {
        FindObjectOfType<Inventario>().ComprobarRepetidos();       //Llamamos a la comprobación de los objetos repetidos al cambiar de escena
        FindObjectOfType<Inventario>().ComprobarFotosRepetidas();
        
        panel = GameObject.Find("Canvas2").GetComponent<panel>();
        panel.desactivada = true;
    }
    public void ButtonExit()
    {
        SceneManager.LoadScene("Exit");
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
