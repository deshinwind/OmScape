using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Crafteo : MonoBehaviour
{
    public bool crafteoActivo;
    public bool crafteado;
    public bool fotoCrafteada = false;
    public bool ganzuaCrafteada = false;

    public GameObject crafteoMenu;
    public GameObject inventarioMenu;
    public GameObject prefabFoto;
    public GameObject prefabGanzua;

    public slotdeitems[] slotdeitems;

    public Inventario inventario;

    public MostrarObjetos mostrador;

    private int tamañoMaximo = 2;

    private string tagGanzua = "GanzuaCompleta";
    private string tagFoto = "Sensor";

    void Update()
    {
        if (Input.GetButtonDown("Crafteo") && crafteoActivo)            //Abre el menú de crafteo
        {
            if (slotdeitems[0].isfull)
            {
                AñadirAInventario(0);
                EliminarItem(0);
            }
            if (slotdeitems[1].isfull)
            {
                AñadirAInventario(1);
                EliminarItem(1);
            }

            crafteoMenu.SetActive(false);
            inventarioMenu.SetActive(false);
            crafteoActivo = false;
            inventario.inventarioActivo = false;
        }

        else if (Input.GetButtonDown("Crafteo") && !crafteoActivo)
        {
            crafteoMenu.SetActive(true);
            inventarioMenu.SetActive(true);
            crafteoActivo = true;
            inventario.inventarioActivo = true;
        }
    }

    public void AddItem(string itemname, Sprite itemsprite, string valorTag)    //Añade un item al Crafteo
    {
        crafteado = false;
        for (int i = 0; i < tamañoMaximo; i++)
        {
            if (!slotdeitems[i].isfull)
            {
                slotdeitems[i].AddItem(itemname, itemsprite);
                slotdeitems[i].tag = valorTag;
                crafteado = true;
                return;
            }
            // HACER UN ELSE QUE HAGA UNA PEQUEÑA ANIMACION O ALGO QUE INDIQUE AL USUARIO QUE EL CRAFTEO ESTÁ LLENO
        }
    }

    public void DeselectAllSlots()      //Deselecciona los slots
    {
        for (int i = 0; i < tamañoMaximo; i++)
        {
            slotdeitems[i].selectedshader.SetActive(false);
            slotdeitems[i].thisItemSelected = false;
        }
    }

    //PRUEBA DE CRAFTEO
    public void ComprobarSiCrafteo()
    {
        //Comprueba si los objetos que estan en el crafteo se pueden craftear
        //Si se pueden craftear, envia el objeto crafteado al inventario
        //Si no se puede craftear, devuelve los objetos al inventario
        if (slotdeitems[0].CompareTag(slotdeitems[1].tag) && slotdeitems[0].isfull)
        {
            if (slotdeitems[0].CompareTag("foto"))
            {
                GameObject basura = Instantiate(prefabFoto);
                inventario.AddObjetoCrafteado(basura.name, tagFoto);
                Destroy(basura);
                mostrador.MostrarObjeto("FotoCompleta");
                fotoCrafteada = true;
            }
            else if (slotdeitems[0].CompareTag("ganzua"))
            {
                GameObject basura = Instantiate(prefabGanzua);
                inventario.AddObjetoCrafteado(basura.name, tagGanzua);
                Destroy(basura);
                mostrador.MostrarObjeto("GanzuaCompleta");
                ganzuaCrafteada = true;
            }
            if (slotdeitems[0].CompareTag("ganzua") || slotdeitems[0].CompareTag("foto"))
            {
                EliminarItem(0);
                EliminarItem(1);
            }
        }

        if (slotdeitems[0].isfull)         //Comprueba que haya items en el primer slot del crafateo, lo envia al inventario y lo elimina
        {
            AñadirAInventario(0);
            EliminarItem(0);
        }
        if (slotdeitems[1].isfull)         //Comprueba que haya items en el segundo slot del crafateo, lo envia al inventario y lo elimina
        {
            AñadirAInventario(1);
            EliminarItem(1);
            }
    }
    public void AñadirAInventario(int indice)     //Envia los items del crafteo al inventario
    {
        inventario.AddItemFromCraft(slotdeitems[indice].itemName, slotdeitems[indice].itemsprite, slotdeitems[indice].tag);
    }
    public void EliminarItem(int indice)      //Elimina los items del crafteo
    {
        slotdeitems[indice].RemoveItem();
    }
}
