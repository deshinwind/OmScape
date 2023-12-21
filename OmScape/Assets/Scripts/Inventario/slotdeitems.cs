using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class slotdeitems : MonoBehaviour, IPointerClickHandler
{
    public bool isfull;
    public bool thisItemSelected;

    public string itemName;

    public GameObject selectedshader;

    public Sprite itemsprite;
    public Sprite spriteAuxiliar;

    public Image itemimage;

    private Inventario inventario;

    private Crafteo crafteo;

    private AlmacenSensor almacen;
    

    private void Start()
    {
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
        crafteo = GameObject.Find("Canvas2").GetComponent<Crafteo>();

        if (SceneManager.GetActiveScene().name.Equals("panel"))
        {
            almacen = GameObject.Find("Canvas").GetComponent<AlmacenSensor>();
        }
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
        if (almacen != null)
        {
            almacen.DeselectAllSlots();
        }
        inventario.DeselectAllSlots();
        crafteo.DeselectAllSlots();
        selectedshader.SetActive(true);
        thisItemSelected = true;
    }
}
