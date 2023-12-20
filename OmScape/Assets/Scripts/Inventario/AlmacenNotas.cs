using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AlmacenNotas : MonoBehaviour
{
    public bool[] notasNarrativa;
    public bool[] notasPosesiones;

    public Sprite[] narrativa;
    public Sprite[] posesion;
    public Sprite notaFalsa;

    public GameObject nota;
    public GameObject texto;

    public bool mostrandoNota;
    public bool notaFalsaBool = false;

    public GameObject pausa;

    public readonly int tamañoNarrativa = 5;
    public readonly int tamañoPosesion = 6;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && mostrandoNota && Time.timeScale == 0) 
        {
            pausa.GetComponent<BoxCollider2D>().enabled = false;
            Time.timeScale = 1;
            if (!notaFalsaBool)
            {
                texto.SetActive(true);
                Invoke("Texto", 3f);
            }
            else
            {
                notaFalsaBool = false;
            }

            nota.SetActive(false);
            mostrandoNota = false;
        }
    }

    public void ComprobarNota(string tag, string nombre)
    {
        if (tag.Equals("Narrativa")) { ComprobarNarrativa(nombre); }
        else { ComprobarPosesion(nombre); }
    }

    public void ComprobarNarrativa(string nombre)
    {
        switch (nombre)
        {
            case "N0":
                notasNarrativa[0] = true;
                break;
            case "N1":
                notasNarrativa[1] = true;
                break;
            case "N2":
                notasNarrativa[2] = true;
                break;
            case "N3":
                notasNarrativa[3] = true;
                break;
            case "N4":
                notasNarrativa[4] = true;
                break;
        }
    }
    public void ComprobarPosesion(string nombre)
    {
        switch (nombre)
        {
            case "P0":
                notasPosesiones[0] = true;
                break;
            case "P1":
                notasPosesiones[1] = true;
                break;
            case "P2":
                notasPosesiones[2] = true;
                break;
            case "P3":
                notasPosesiones[3] = true;
                break;
            case "P4":
                notasPosesiones[4] = true;
                break;
            case "P5":
                notasPosesiones[5] = true;
                break;
        }
    }

    public void MostrarNota(string nombre)
    {
        mostrandoNota = true;
        nota.SetActive(true);
        pausa.GetComponent<BoxCollider2D>().enabled = true;

        if (nombre.Equals("NotaFalsa"))
        {
            nota.GetComponent<Image>().sprite = notaFalsa;
            notaFalsaBool = true;
        }
        else if (nombre.Contains("N"))
        {
            switch (nombre)
            {
                case "N0":
                    nota.GetComponent<Image>().sprite = narrativa[0];
                    break;
                case "N1":
                    nota.GetComponent<Image>().sprite = narrativa[1];
                    break;
                case "N2":
                    nota.GetComponent<Image>().sprite = narrativa[2];
                    break;
                case "N3":
                    nota.GetComponent<Image>().sprite = narrativa[3];
                    break;
                case "N4":
                    nota.GetComponent<Image>().sprite = narrativa[4];
                    break;
            }
        }
        else
        {
            switch (nombre)
            {
                case "P0":
                    nota.GetComponent<Image>().sprite = posesion[0];
                    break;
                case "P1":
                    nota.GetComponent<Image>().sprite = posesion[1];
                    break;
                case "P2":
                    nota.GetComponent<Image>().sprite = posesion[2];
                    break;
                case "P3":
                    nota.GetComponent<Image>().sprite = posesion[3];
                    break;
                case "P4":
                    nota.GetComponent<Image>().sprite = posesion[4];
                    break;
                case "P5":
                    nota.GetComponent<Image>().sprite = posesion[5];
                    break;
            }
        }
    }

    public void Texto()
    {
        texto.SetActive(false);
    }
}
