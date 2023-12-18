using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class doblefondo : MonoBehaviour
{
    public Sprite doblefondosprite;
    private Animator animator;

    public Inventario inventario;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            for (int i = 0; i < inventario.tamañoMaximo; i++)
            {
                if (inventario.slotdeitems[i].thisItemSelected)
                {
                    if (inventario.slotdeitems[i].CompareTag("Barrena"))
                    {
                        animator.SetTrigger("doblefondotrigger");
                        Destroy(GetComponent<BoxCollider2D>());
                        Invoke("Prueba", 0.15f);
                    }
                }
            }

        }
    }
    void Prueba()
    {
        animator.SetTrigger("doblefondotrigger");
        GameObject.Find("doble").GetComponent<SpriteRenderer>().sprite = doblefondosprite;

    }

}
