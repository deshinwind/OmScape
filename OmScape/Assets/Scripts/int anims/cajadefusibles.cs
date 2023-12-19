using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class cajadefusibles : MonoBehaviour
{
    public Sprite bufandasprite;
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
        if(activo.bufanda && activo.candado)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent <BoxCollider2D>().enabled = false;
        }
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

    void Animacion()
    {
        animator.SetTrigger("cajaclick");
        GameObject.Find("caja de fusibles").GetComponent<SpriteRenderer>().sprite = bufandasprite;

    }

}