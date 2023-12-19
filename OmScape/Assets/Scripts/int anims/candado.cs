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
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
    }

    void Update()
    {
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
        for (int i = 0; i < inventario.tama�oMaximo; i++)
        {
            if (inventario.slotdeitems[i].thisItemSelected)
            {
                if (inventario.slotdeitems[i].CompareTag("GanzuaCompleta"))
                {
                    animator.SetTrigger("candadotrigger");
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    activos.Candado();
                    //Destroy(GetComponent<BoxCollider2D>());
                    Invoke("Animacion", 0.15f);
                }
            }
        }
    }
    void Animacion()
    {
        animator.SetTrigger("candadotrigger");
        GameObject.Find("candado").GetComponent<SpriteRenderer>().sprite = candadosprite;
    }
}
