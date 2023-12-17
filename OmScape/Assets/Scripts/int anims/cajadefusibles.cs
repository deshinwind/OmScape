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


    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            animator.SetTrigger("cajaclick");
            Destroy(GetComponent<BoxCollider2D>());
            Invoke("Prueba", 0.15f);

        }
    }
    void Prueba()
    {
        animator.SetTrigger("cajaclick");
        GameObject.Find("caja de fusibles").GetComponent<SpriteRenderer>().sprite = bufandasprite;

    }

}