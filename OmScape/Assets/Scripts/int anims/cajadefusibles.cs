using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class cajadefusibles : MonoBehaviour
{
    public Sprite bufandasprite;
    public Sprite cajaDeFusiblesConFusible;
    private Animator animator;
    public ObjetosActivos activo;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        activo = GameObject.Find("Canvas2").GetComponent<ObjetosActivos>();
    }

    void Update()
    {
        if (activo.fusibles && activo.bufanda && activo.cajaDeFusibles && activo.candado)
        {
            Invoke("CambiarSprite", 0.5f);
        }

        if(activo.bufanda && activo.candado)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent <BoxCollider2D>().enabled = false;
        }
    }

    public void CambiarSprite()
    {
        cajaDeFusiblesConFusible = null;
    }

    public void Abrir()
    {
        if (activo.bufanda)
        {
            animator.SetTrigger("cajaclick");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            activo.CajaDeFusibles();
            //Destroy(GetComponent<BoxCollider2D>());
            Invoke("Animacion", 0.15f);
        }
    }

    /*public void Abrir()
    {
        for (int i = 0; i < inventario.tamañoMaximo; i++)
        {
            if (inventario.slotdeitems[i].thisItemSelected)
            {
                if (inventario.slotdeitems[i].CompareTag("Fusible Azul"))
                {
                    animator.SetTrigger("cajaclick");
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    activos.CajaDeFusibles();
                    //Destroy(GetComponent<BoxCollider2D>());
                    Invoke("Animacion", 0.15f);
                }
                else if (inventario.slotdeitems[i].itemName.Contains("Fusible"))
                {
                    inventario.slotdeitems[i].RemoveItem();
                }
            }
        }
    }*/

    void Animacion()
    {
        animator.SetTrigger("cajaclick");
        GameObject.Find("caja de fusibles").GetComponent<SpriteRenderer>().sprite = bufandasprite;

    }

}