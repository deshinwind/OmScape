using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class candado : MonoBehaviour
{
    public Sprite candadosprite;

    private Animator animator;

    public ObjetosActivos activos;

    public Inventario inventario;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        activos = GameObject.Find("Canvas2").GetComponent<ObjetosActivos>();
        inventario = GameObject.Find("Inventario").GetComponent<Inventario>();
    }

    void Update()
    {
        if (GameObject.Find("Canvas").GetComponent<ButtonFuncionality>().fin)
        {
            gameObject.SetActive(false);
        }
        if (activos.bufanda)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void Abrir()
    {
        for (int i = 0; i < inventario.tamañoMaximo; i++)
        {
            if (inventario.slotdeitems[i].thisItemSelected)
            {
                if (inventario.slotdeitems[i].CompareTag("GanzuaCompleta"))
                {
                    animator.SetTrigger("candadotrigger");
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    activos.candado = true;
                    Invoke("Animacion", 0.15f);
                }
            }
        }
    }
    void Animacion()
    {
        animator.SetTrigger("candadotrigger");
    }
}
