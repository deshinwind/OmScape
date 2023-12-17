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


    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            animator.SetTrigger("candadotrigger");
            Destroy(GetComponent<BoxCollider2D>());
            Invoke("Prueba", 0.15f);

        }
    }
    void Prueba()
    {
        animator.SetTrigger("candadotrigger");
        GameObject.Find("candado").GetComponent<SpriteRenderer>().sprite = candadosprite;

    }

}
