using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baul : MonoBehaviour
{
    public GameObject objetos;
    public GameObject notas;

    public Inventario inventario;

    public Sprite baulsprite;
    
    public ObjetosActivos activos;

    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        activos = GameObject.Find("Canvas2").GetComponent<ObjetosActivos>();
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
        if (inventario.dobleFondo)
        {
            objetos.SetActive(true);
            notas.SetActive(true);
        }
    }

    public void Abrir()
    {
        animator.SetTrigger("baul");
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        activos.baul = true;

        Invoke("Animacion", 0.15f);
        Invoke("ActivarObjetos", 0.5f);
    }

    void Animacion()
    {
        animator.SetTrigger("baul");
        GameObject.Find("baul").GetComponent<SpriteRenderer>().sprite = baulsprite;
    }

    public void ActivarObjetos()
    {
        objetos.SetActive(true);
        notas.SetActive(true);
        activos.cajon = true;
    }
}
