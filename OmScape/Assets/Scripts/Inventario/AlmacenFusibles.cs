using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlmacenFusibles : MonoBehaviour
{
    public slotdeitems slot;

    public Inventario inventario;
    public ObjetosActivos activos;
    public GameObject interfaz;
    public CameraZoomController zoomController;

    public bool enviado;
    public bool desactivada = true;


    void Start()
    {
        zoomController = GameObject.Find("Zoom").GetComponent<CameraZoomController>();
        activos = GameObject.Find("Canvas2").GetComponent<ObjetosActivos>();
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
    }

    void Update()
    {
        if (zoomController.zoomCheck[1] && activos.bufanda && activos.candado && activos.cajaDeFusibles)
        {
            interfaz.SetActive(true);
        }
        else
        {
            interfaz.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name.Equals("H2"))
        {
            if (activos.fusibles)
            {
                if (desactivada)
                {
                    GameObject.Find("puerta").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/interfaz/vacio");
                    desactivada = false;
                }
            }
        }
    }

    public void AddItemFusibles(string itemname, Sprite itemsprite, string valorTag)    //Añade un item al Sensor
    {
        enviado = false;
            if (!slot.isfull)
            {
                slot.AddItem(itemname, itemsprite);
                slot.tag = valorTag;
                enviado = true;
            }
    }

    public void ComprobarFusible()
    {
        if (slot.CompareTag("FusibleBueno"))
        {
            slot.RemoveItem();
            activos.Fusibles();
        }
        if (slot.isfull)
        {
            if (slot.CompareTag("FusibleMalo"))
            {
                slot.RemoveItem();
            }
            else
            {
                inventario.AddItemFromCraft(slot.itemName, slot.itemsprite, slot.tag);
                slot.RemoveItem();
            }
        }
    }
}
