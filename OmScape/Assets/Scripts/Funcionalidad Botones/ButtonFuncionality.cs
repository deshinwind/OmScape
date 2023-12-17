using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFuncionality : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<Inventario>().ComprobarRepetidos();       //Llamamos a la comprobación de los objetos repetidos al cambiar de escena
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
        SceneManager.LoadScene("T1");
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

    public void ButtonCama()
    {
        SceneManager.LoadScene("Cama");
    }

    public void ButtonEscritorioEntero()
    {
        SceneManager.LoadScene("Escritorio enterio");
    }

    public void ButtonEscritorioArriba()
    {
        SceneManager.LoadScene("Escritorio arriba");
    }
}
