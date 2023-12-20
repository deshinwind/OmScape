using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmacenSensor : MonoBehaviour
{
    private int tama�oMaximo = 3;

    public slotdeitems[] slot;
    public panel panel;
    public panel panel2;
    public Inventario inventario;

    public bool enviado;

    private void Start()
    {
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
        panel2 = GameObject.Find("Canvas2").GetComponent <panel>();
    }

    public void ComprobarEscaner()
    {
        if (slot[0].CompareTag(slot[1].tag) && slot[0].CompareTag(slot[2].tag) && slot[0].isfull && slot[0].CompareTag("Sensor"))
        {
            panel.acertaste();
            panel2.Escanear();
            slot[0].RemoveItem();
            slot[1].RemoveItem();
            slot[2].RemoveItem();

            inventario.comicUsado = true;
            inventario.cocheUsado = true;
        }
        else
        {
            panel.fallaste();
            if (slot[0].isfull)
            {
                if (slot[0].CompareTag("Untagged") || slot[0].CompareTag("NoCraft"))
                {
                    slot[0].RemoveItem();
                }
                else
                {
                    inventario.AddItemFromCraft(slot[0].itemName, slot[0].itemsprite, slot[0].tag);
                    slot[0].RemoveItem();
                }
            }

            if (slot[1].isfull)
            {
                if (slot[1].CompareTag("Untagged") || slot[1].CompareTag("NoCraft"))
                {
                    slot[1].RemoveItem();
                }
                else
                {
                    inventario.AddItemFromCraft(slot[1].itemName, slot[1].itemsprite, slot[1].tag);
                    slot[1].RemoveItem();
                }
            }

            if (slot[2].isfull)
            {
                if (slot[2].CompareTag("Untagged") || slot[2].CompareTag("NoCraft"))
                {
                    slot[2].RemoveItem();
                }
                else
                {
                    inventario.AddItemFromCraft(slot[2].itemName, slot[2].itemsprite, slot[2].tag);
                    slot[2].RemoveItem();
                }
            }
        }
    }

    public void AddItemEscaner(string itemname, Sprite itemsprite, string valorTag)    //A�ade un item al Sensor
    {
        enviado = false;
        for (int i = 0; i < tama�oMaximo; i++)
        {
            if (!slot[i].isfull)
            {
                slot[i].AddItem(itemname, itemsprite);
                slot[i].tag = valorTag;
                enviado = true;
                return;
            }
            // HACER UN ELSE QUE HAGA UNA PEQUE�A ANIMACION O ALGO QUE INDIQUE AL USUARIO QUE EL CRAFTEO EST� LLENO
        }
    }

    public void DeselectAllSlots()      //Deselecciona los slots
    {
        for (int i = 0; i < tama�oMaximo; i++)
        {
            slot[i].selectedshader.SetActive(false);
            slot[i].thisItemSelected = false;
        }
    }
}
