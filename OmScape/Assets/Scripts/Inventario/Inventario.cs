using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventario : MonoBehaviour
{
    public bool inventarioActivo;
    public bool recolectado;
    public bool linterna;
    public bool dobleFondo;
    public bool cajonAbierto;
    public bool comicUsado = false;
    public bool cocheUsado = false;
    public bool fusibleAzul = false;
    public bool fusibleVerde = false;
    public bool fusibleRojo = false;
    public bool fusibleBlanco = false;
    public bool fusibleNegro = false;
    public bool fusibleAmarillo = false;
    public bool barrena = false;

    public int tamañoMaximo = 6;

    public GameObject inventorymenu;
    public GameObject crafteoMenu;

    public Sprite foto;
    public Sprite ganzua;
    public slotdeitems[] slotdeitems;

    public Crafteo crafteo;

    void Update()
    {
        if (Input.GetButtonDown("Inventario") && inventarioActivo)  //Comprueba si pulsas la tecla para abrir el inventario y este está activo
        {
            if (crafteo.crafteoActivo) //Si el crafteo está activo devuelve los objetos que estén en el inventario al crafteo y cierra el crafteo, dejando el inventario activo
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
            else //Si el crafteo está desactivado, desactiva también el inventario
            {
                inventorymenu.SetActive(false);
                inventarioActivo = false;
            }
        }
        else if (Input.GetButtonDown("Inventario") && !inventarioActivo) //Si pulsas la tecla para abrir el inventario y este está desactivado, lo activa
        {
            inventorymenu.SetActive(true);
            inventarioActivo = true;
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
            }
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
        if (valorTag.Equals("Sensor"))
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

    public bool InventarioLleno()
    {
        for (int i = 0; i < tamañoMaximo; i++)
        {
            if (!slotdeitems[i].isfull)
            {
                return false;
            }
        }
        return true;
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
