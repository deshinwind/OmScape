using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class slotdeitems : MonoBehaviour, IPointerClickHandler
{
    //=====itemslot=====//
    public string itemName;
    public Sprite itemsprite;
    public bool isfull;

    //=====itemslot=====//
    public Image itemimage;

    public GameObject selectedshader;
    public bool thisItemSelected;

    private Inventario inventario;
    private Crafteo crafteo;
    public Sprite spriteAuxiliar;

    private void Start()
    {
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
        crafteo = GameObject.Find("Canvas2").GetComponent<Crafteo>();
    }
    public void AddItem(string itemname, Sprite itemsprite)     //Añade un item al slot (puede ser al inventario o al crafteo)
    {
        this.itemName = itemname;
        this.itemsprite = itemsprite;
        this.isfull = true;

        itemimage.sprite = itemsprite;
    }
    public void RemoveItem()        //Elimina un item del slot (ya sea del inventario o del crafteo)
    {
        this.itemName = null;
        this.itemsprite = spriteAuxiliar;
        this.isfull = false;
        tag = "Untagged";

        itemimage.sprite = spriteAuxiliar;
    }
    public void OnPointerClick(PointerEventData eventData)      //Detecta el click del raton
    {
       if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }
    public void OnLeftClick()       //Selecciona el slot seleccionado (ya sea inventario o crafteo)
    {
        inventario.DeselectAllSlots();
        crafteo.DeselectAllSlots();
        selectedshader.SetActive(true);
        thisItemSelected = true;
    }
}
