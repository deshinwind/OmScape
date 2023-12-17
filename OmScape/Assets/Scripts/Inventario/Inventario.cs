using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public GameObject inventorymenu;
    public GameObject crafteoMenu;
    public bool inventarioActivo;
    public bool recolectado;
    [SerializeField] private slotdeitems[] slotdeitems;
    [SerializeField] private Crafteo crafteo;

    public GameObject prueba;

    private int tamañoMaximo = 6;

    public Sprite foto;
    public Sprite ganzua;
    
    public static Inventario instancia;

    private List<int> numeros = new List<int>();

    private void Start()
    {
        if (instancia == null)  //Guarda el Canvas del inventario y evita que se dupliquen el resto
        {
            instancia = this;
            if (!gameObject.name.Equals("Canvas"))
            {
                GameObject.DontDestroyOnLoad(this.gameObject);
            }
        }
        else
        {
            if (!gameObject.name.Equals("Canvas"))
            {
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Inventario") && inventarioActivo)  //Abrir y cerrar el inventario
        {
            if (crafteo.crafteoActivo)
            {
                if (crafteo.slotdeitems[0].isfull)
                {
                    crafteo.AñadirAInventario(0);
                    crafteo.EliminarItem(0);
                }
                if (crafteo.slotdeitems[1].isfull)
                {
                    crafteo.AñadirAInventario(1);
                    crafteo.EliminarItem(1);
                }
                crafteoMenu.SetActive(false);
                crafteo.crafteoActivo = false;
            }
            else
            {
                inventorymenu.SetActive(false);
                inventarioActivo = false;
            }
        }
        else if (Input.GetButtonDown("Inventario") && !inventarioActivo)
        {
            inventorymenu.SetActive(true);
            inventarioActivo = true;
        }
    }
    public void ComprobarRepetidos()    //Comprueba si los objetos que están en la escena ya han sido recogidos y los elimina
    {
        prueba = GameObject.Find("Objetos");

        for (int i = 0; i < prueba.transform.childCount; i++)
        {
            for (int j = 0; j < tamañoMaximo; j++)
            {
                if ((prueba.transform.GetChild(i).CompareTag("foto") && crafteo.fotoCrafteada)      //Comprueba si la foto o la ganzua han sido crafteadas
                    || (prueba.transform.GetChild(i).CompareTag("ganzua") && crafteo.ganzuaCrafteada))
                {
                    numeros.Add(i);
                }
                if (prueba.transform.GetChild(i).name.Equals(slotdeitems[j].itemName))
                {
                    numeros.Add(i);
                }
            }
        }
        for (int i = numeros.Count - 1; i >= 0; i--)
        {
            Destroy(prueba.transform.GetChild(numeros[i]).gameObject);
        }
    }
    public void AddItem(string itemname, Sprite itemsprite, string valorTag)    //Añade items del entorno al inventario
    {
        recolectado = false;
        if (!crafteo.crafteoActivo)
        {
            for (int i = 0; i < tamañoMaximo; i++)
            {
                if (!slotdeitems[i].isfull)
                {
                    slotdeitems[i].AddItem(itemname, itemsprite);
                    slotdeitems[i].tag = valorTag;
                    recolectado = true;
                    return;
                }
                // HACER UN ELSE QUE HAGA UNA PEQUEÑA ANIMACION O ALGO QUE INDIQUE AL USUARIO QUE EL CRAFTEO ESTÁ LLENO
            }
            print("La mamaeste no entra wei");
        }
        else
        {
            print("Eso no se hace. Si crafteas no recoges objetos manin");
        }
    }
    public void AddItemFromCraft(string itemname, Sprite itemsprite, string valorTag)   //Añade items del crafteo al inventario
    {
        for (int i = 0; i < tamañoMaximo; i++)
        {
            if (!slotdeitems[i].isfull)
            {
                slotdeitems[i].AddItem(itemname, itemsprite);
                slotdeitems[i].tag = valorTag;
                recolectado = true;
                return;
            }
        }
    }
    public void AddObjetoCrafteado(string itemname, string valorTag)    //Añade el item crafteado al inventario
    {
        if (valorTag.Equals("foto"))
        {
            for (int i = 0; i < tamañoMaximo; i++)
            {
                if (!slotdeitems[i].isfull)
                {
                    slotdeitems[i].AddItem(itemname, foto);
                    slotdeitems[i].tag = valorTag;
                    recolectado = true;
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < tamañoMaximo; i++)
            {
                if (!slotdeitems[i].isfull)
                {
                    slotdeitems[i].AddItem(itemname, ganzua);
                    slotdeitems[i].tag = valorTag;
                    recolectado = true;
                    return;
                }
            }
        }
    }
    public void DeselectAllSlots()  //Deselecciona los slots del inventario
    {
        for (int i = 0; i < tamañoMaximo; i++)
        {
            slotdeitems[i].selectedshader.SetActive(false);
            slotdeitems[i].thisItemSelected = false;
        }
    }
}
