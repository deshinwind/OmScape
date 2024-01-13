using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarObjetos : MonoBehaviour
{
    public int rotado;

    public bool mostrandoObjeto;

    public float[] escala;
    public float[] rotacion;

    public GameObject objeto;
    public GameObject pausa;

    public Sprite[] spriteObjeto;

    public Inventario inventario;

    public Crafteo crafteo;

    private void Start()
    {
        crafteo = GameObject.Find("Canvas2").GetComponent<Crafteo>();
    }

    private void Update()
    {
        if (pausa.GetComponent<BoxCollider2D>().enabled)
        {
            Time.timeScale = 0;
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (rotado == 0)
                {
                    objeto.transform.Rotate(new Vector3(0, 0, 0 - rotacion[0]));
                }
                else
                {
                    objeto.transform.Rotate(new Vector3(0, 0, 0 - rotacion[1]));
                }

                mostrandoObjeto = false;
                pausa.GetComponent<BoxCollider2D>().enabled = false;
                objeto.GetComponent<SpriteRenderer>().enabled = false;
                Time.timeScale = 1;
            }
        }
    }

    public void MostrarObjeto(string nombre)
    {
        pausa.GetComponent<BoxCollider2D>().enabled = true;

        objeto.GetComponent<SpriteRenderer>().enabled = true;

        mostrandoObjeto = true;

        switch (nombre)
        {
            case "Coche1":
                objeto.transform.localScale = new Vector3(escala[0], escala[0], escala[0]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[0];
                rotado = 0;
                break;
            case "Coche2":
                objeto.transform.localScale = new Vector3(escala[1], escala[1], escala[1]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[1];
                rotado = 0;
                break;
            case "Coche3":
                objeto.transform.localScale = new Vector3(escala[2], escala[2], escala[2]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[2];
                rotado = 0;
                break;
            case "Destornillador":
                objeto.transform.localScale = new Vector3(escala[3], escala[3], escala[3]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[1]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[3];
                rotado = 1;
                break;
            case "Comic1":
                objeto.transform.localScale = new Vector3(escala[4], escala[4], escala[4]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[4];
                rotado = 0;
                break;
            case "Comic2":
                objeto.transform.localScale = new Vector3(escala[5], escala[5], escala[5]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[5];
                rotado = 0;
                break;
            case "Clip":
                objeto.transform.localScale = new Vector3(escala[0], escala[0], escala[0]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[6];
                rotado = 0;
                break;
            case "Foto1":
                objeto.transform.localScale = new Vector3(escala[3], escala[3], escala[3]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[7];
                rotado = 0;
                break;
            case "Foto2":
                objeto.transform.localScale = new Vector3(escala[3], escala[3], escala[3]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[8];
                rotado = 0;
                break;
            case "FusibleAzul":
                objeto.transform.localScale = new Vector3(escala[4], escala[4], escala[4]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[9];
                rotado = 0;
                break;
            case "FusibleRojo":
                objeto.transform.localScale = new Vector3(escala[4], escala[4], escala[4]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[10];
                rotado = 0;
                break;
            case "FusibleVerde":
                objeto.transform.localScale = new Vector3(escala[4], escala[4], escala[4]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[11];
                rotado = 0;
                break;
            case "FusibleBlanco":
                objeto.transform.localScale = new Vector3(escala[4], escala[4], escala[4]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[12];
                rotado = 0;
                break;
            case "FusibleNegro":
                objeto.transform.localScale = new Vector3(escala[4], escala[4], escala[4]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[13];
                rotado = 0;
                break;
            case "FusibleAmarillo":
                objeto.transform.localScale = new Vector3(escala[4], escala[4], escala[4]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[14];
                rotado = 0;
                break;
            case "Barrena":
                objeto.transform.localScale = new Vector3(escala[4], escala[4], escala[4]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[1]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[15];
                rotado = 1;
                break;
            case "GanzuaCompleta":
                objeto.transform.localScale = new Vector3(escala[4], escala[4], escala[4]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[16];
                rotado = 0;
                break;
            case "FotoCompleta":
                objeto.transform.localScale = new Vector3(escala[3], escala[3], escala[3]);
                objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                rotado = 0;
                objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[17];
                break;
        }
    }
}
