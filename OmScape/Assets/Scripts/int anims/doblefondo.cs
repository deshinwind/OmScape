using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class doblefondo : MonoBehaviour
{
    public GameObject objetos;
    public GameObject notas;

    public Sprite doblefondosprite;

    public Inventario inventario;

    public ObjetosActivos activos;

    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        activos = GameObject.Find("Canvas2").GetComponent<ObjetosActivos>();
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
        if (inventario.dobleFondo)
        {
            objetos.SetActive(true);
            notas.SetActive(true);
        }
    }

    public void Abrir()
    {
        if (inventario.cajonAbierto)
        {
            animator.SetTrigger("doblefondotrigger");
            Destroy(GetComponent<BoxCollider2D>());
            Invoke("AnimacionCajon", 0.15f);
            Invoke("ActivarObjetos", 1f);
        }
        else
        {
            for (int i = 0; i < inventario.tamañoMaximo; i++)
            {
                if (inventario.slotdeitems[i].thisItemSelected)
                {
                    if (inventario.slotdeitems[i].CompareTag("Barrena"))
                    {
                        animator.SetTrigger("doblefondotrigger");
                        Destroy(GetComponent<BoxCollider2D>());
                        Invoke("AnimacionCajon", 0.15f);
                        inventario.slotdeitems[i].RemoveItem();
                        Invoke("ActivarObjetos", 1f);
                        inventario.cajonAbierto = true;
                    }
                }
            }
        }
    }

    void AnimacionCajon()
    {
        animator.SetTrigger("doblefondotrigger");
        GameObject.Find("doble").GetComponent<SpriteRenderer>().sprite = doblefondosprite;
    }

    public void ActivarObjetos()
    {
        objetos.SetActive(true);
        notas.SetActive(true);
        activos.cajon = true;
    }

}
