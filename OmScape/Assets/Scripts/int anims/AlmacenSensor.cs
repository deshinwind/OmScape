using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmacenSensor : MonoBehaviour
{
    private int tamañoMaximo = 3;

    public slotdeitems[] slot;
    public panel panel;
    public Inventario inventario;

    private void Start()
    {
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
    }

    public void ComprobarEscaner()
    {
        if (slot[0].CompareTag(slot[1].tag) && slot[0].CompareTag(slot[2].tag) && slot[0].isfull && slot[0].CompareTag("Sensor"))
        {
            panel.Escanear();
        }
        else
        {
            panel.fallaste();
            if (slot[0].isfull)
            {
                if (slot[0].CompareTag("Untagged"))
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
                if (slot[1].CompareTag("Untagged"))
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
                if (slot[2].CompareTag("Untagged"))
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

    public void AddItemEscaner(string itemname, Sprite itemsprite, string valorTag)    //Añade un item al Sensor
    {
        //crafteado = false;
        for (int i = 0; i < tamañoMaximo; i++)
        {
            if (!slot[i].isfull)
            {
                slot[i].AddItem(itemname, itemsprite);
                slot[i].tag = valorTag;
                //crafteado = true;
                return;
            }
            // HACER UN ELSE QUE HAGA UNA PEQUEÑA ANIMACION O ALGO QUE INDIQUE AL USUARIO QUE EL CRAFTEO ESTÁ LLENO
        }
    }

    public void DeselectAllSlots()      //Deselecciona los slots
    {
        for (int i = 0; i < tamañoMaximo; i++)
        {
            slot[i].selectedshader.SetActive(false);
            slot[i].thisItemSelected = false;
        }
    }
}
