using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class MostrarObjetos : MonoBehaviour
{
    public int rotado;

    public bool mostrandoObjeto;

    public float[] escala;
    public float[] rotacion;

    public Vector2[] posicion;

    public GameObject objeto;
    public GameObject pausa;

    public Sprite[] spriteObjeto;

    public Inventario inventario;

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

                pausa.GetComponent<BoxCollider2D>().enabled = false;
                objeto.GetComponent<SpriteRenderer>().enabled = false;
                Time.timeScale = 1;
            }
        }
    }

    public void MostrarObjeto(string nombre)
    {
        if (!inventario.InventarioLleno())
        {
            pausa.GetComponent<BoxCollider2D>().enabled = true;

            objeto.GetComponent<SpriteRenderer>().enabled = true;

            mostrandoObjeto = true;

            switch (nombre)
            {
                case "Coche 1":
                    objeto.transform.position = new Vector3(posicion[0].x, posicion[0].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[0], escala[0], escala[0]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[0];
                    rotado = 0;
                    break;
                case "Coche 2":
                    objeto.transform.position = new Vector3(posicion[0].x, posicion[0].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[1], escala[1], escala[1]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[1];
                    rotado = 0;
                    break;
                case "Coche 3":
                    objeto.transform.position = new Vector3(posicion[1].x, posicion[1].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[2], escala[2], escala[2]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[2];
                    rotado = 0;
                    break;
                case "Destornillador":
                    objeto.transform.position = new Vector3(posicion[4].x, posicion[4].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[3], escala[3], escala[3]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[1]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[3];
                    rotado = 1;
                    break;
                case "Comic 1":
                    objeto.transform.position = new Vector3(posicion[2].x, posicion[2].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[4], escala[4], escala[4]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[4];
                    rotado = 0;
                    break;
                case "Comic 2":
                    objeto.transform.position = new Vector3(posicion[4].x, posicion[4].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[5], escala[5], escala[5]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[5];
                    rotado = 0;
                    break;
                case "Clip":
                    objeto.transform.position = new Vector3(posicion[3].x, posicion[3].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[6], escala[6], escala[6]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[6];
                    rotado = 0;
                    break;
                case "Foto 1":
                    objeto.transform.position = new Vector3(posicion[4].x, posicion[4].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[3], escala[3], escala[3]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[7];
                    rotado = 0;
                    break;
                case "Foto 2":
                    objeto.transform.position = new Vector3(posicion[4].x, posicion[4].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[3], escala[3], escala[3]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[8];
                    rotado = 0;
                    break;
                case "Fusible Azul":
                    objeto.transform.position = new Vector3(posicion[4].x, posicion[4].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[6], escala[6], escala[6]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[9];
                    rotado = 0;
                    break;
                case "Fusible Rojo":
                    objeto.transform.position = new Vector3(posicion[4].x, posicion[4].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[6], escala[6], escala[6]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[10];
                    rotado = 0;
                    break;
                case "Fusible Verde":
                    objeto.transform.position = new Vector3(posicion[4].x, posicion[4].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[6], escala[6], escala[6]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[11];
                    rotado = 0;
                    break;
                case "Fusible Blanco":
                    objeto.transform.position = new Vector3(posicion[4].x, posicion[4].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[6], escala[6], escala[6]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[12];
                    rotado = 0;
                    break;
                case "Fusible Negro":
                    objeto.transform.position = new Vector3(posicion[4].x, posicion[4].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[6], escala[6], escala[6]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[13];
                    rotado = 0;
                    break;
                case "Fusible Amarillo":
                    objeto.transform.position = new Vector3(posicion[4].x, posicion[4].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[6], escala[6], escala[6]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[14];
                    rotado = 0;
                    break;
                case "Barrena":
                    objeto.transform.position = new Vector3(posicion[4].x, posicion[4].y, 0.4f);
                    objeto.transform.localScale = new Vector3(escala[6], escala[6], escala[6]);
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[1]));
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[15];
                    rotado = 1;
                    break;
                case "GanzuaCompleta":
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[16];
                    break;
                case "FotoCompleta":
                    objeto.transform.Rotate(new Vector3(0, 0, rotacion[0]));
                    rotado = 0;
                    objeto.GetComponent<SpriteRenderer>().sprite = spriteObjeto[17];
                    break;
            }
        }
    }
}
