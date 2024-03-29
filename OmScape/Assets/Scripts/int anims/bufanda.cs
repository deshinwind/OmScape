using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class bufanda : MonoBehaviour
{
    public ObjetosActivos activos;

    public Sprite bufandasprite;
    
    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        activos = GameObject.Find("Canvas2").GetComponent<ObjetosActivos>();
        activos.bufanda = false;
        activos.candado = false;
        activos.cajaDeFusibles = false;
    }

    public void Abrir()
    {
        animator.SetTrigger("estapulsadabufanda");
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        activos.bufanda = true;
        Invoke("Animacion", 0.15f);
    }

    void Animacion()
    {
        animator.SetTrigger("estapulsadabufanda");
    }
}