using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recolectable : MonoBehaviour
{
    [SerializeField] private string itemname;
    [SerializeField] private Sprite sprite;

    private Inventario inventario;

    void Start()
    {
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
    }
    public void EnviarAInventario()     //Envia los objetos de la escena al inventario y los elimina
    {
        inventario.AddItem(gameObject.name, sprite, gameObject.tag);
        if (inventario.recolectado)         //Comprueba que se ha enviado al inventario antes de eliminarlo
        {
            Destroy(gameObject);
        }
    }
}
