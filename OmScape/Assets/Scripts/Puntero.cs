using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puntero : MonoBehaviour
{
    public GameObject objeto;
    public string[] listaObjetos;
    public bool correcto;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Raycasteo();
        }
    }

    public void Raycasteo()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            ComprobarNombreObjeto(hit);

            if (correcto)
            {
                objeto = GameObject.Find(hit.transform.name);

                if (objeto.name.Equals("NotaFalsa"))
                {
                    objeto.GetComponent<Notas>().MostrarNotaFalsa();
                }
                else if (objeto.name.Contains("N") || objeto.name.Contains("P"))
                {
                    objeto.GetComponent<Notas>().EnviarAlAlmacen();
                }
                else
                {
                    objeto.GetComponent<recolectable>().EnviarAInventario();
                }
                Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
            }
        }
    }

    private void ComprobarNombreObjeto(RaycastHit2D hit)
    {
        correcto = false;

        for (int i = 0; i < listaObjetos.Length; i++)
        {
            if (listaObjetos[i].Equals(hit.transform.name))
            {
                correcto = true;
            }
        }
    }
}
