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

 
    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            animator.SetTrigger("estapulsadabufanda");
            Destroy(GetComponent<BoxCollider2D>());
            Invoke("Prueba", 0.15f);

        }
    }
    void Prueba()
    {
        animator.SetTrigger("estapulsadabufanda");
        GameObject.Find("bufanda").GetComponent<SpriteRenderer>().sprite = bufandasprite;

    }

}