using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class bufanda : MonoBehaviour
{
    public Sprite bufandasprite;
    private Animator animator;
    public ObjetosActivos activos;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        activos = GameObject.Find("Canvas2").GetComponent<ObjetosActivos>();
    }

    public void Abrir()
    {
        animator.SetTrigger("estapulsadabufanda");
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        activos.Bufanda();
        //Destroy(GetComponent<BoxCollider2D>());
        Invoke("Animacion", 0.15f);
    }

    void Animacion()
    {
        animator.SetTrigger("estapulsadabufanda");
        GameObject.Find("bufanda").GetComponent<SpriteRenderer>().sprite = bufandasprite;
    }
}