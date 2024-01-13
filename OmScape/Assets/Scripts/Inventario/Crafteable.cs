using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Crafteable : MonoBehaviour, IPointerClickHandler
{

    public string itemname;
    public Sprite sprite;
    public string itemNameAux;
    public string tagAux;

    public Sprite itemspriteAux;

    private Crafteo crafteo;

    private panel panel;

    private AlmacenSensor almacen;

    public AlmacenFusibles alamcenFusibles;

    public slotdeitems slot;

    void Start()
    {
        crafteo = GameObject.Find("Canvas2").GetComponent<Crafteo>();
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("panel") && panel == null && almacen == null)
        {
            almacen = GameObject.Find("Canvas").GetComponent<AlmacenSensor>();
            panel = GameObject.Find("Canvas").GetComponent<panel>();
        }

        if (alamcenFusibles == null)
        {
            if (SceneManager.GetActiveScene().name.Equals("H1"))
            {
                alamcenFusibles = GameObject.Find("Canvas").GetComponent<AlmacenFusibles>();
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (panel != null && !crafteo.crafteoActivo)
            {
                if (SceneManager.GetActiveScene().name.Equals("panel"))
                {
                    if (slot.name.Contains("Escaner") && slot.isfull)
                    {
                        EnviarAInventario();
                    }
                    else
                    {
                        EnviarAEscaner();
                    }
                }
            }
            else
            {
                EnviarACrafteo();
            }
        }
    }

    public void EnviarAInventario()
    {
        GameObject.Find("Inventario").GetComponent<Inventario>().AddItemFromCraft(gameObject.GetComponent<slotdeitems>().itemName, slot.itemsprite, gameObject.tag);
        slot.RemoveItem();
    }

    public void EnviarACrafteo()    //Envia el item del inventario al crafteo
    {
        if (crafteo.crafteoActivo)
        {
            if (slot.thisItemSelected && slot.isfull)
            {
                crafteo.AddItem(gameObject.GetComponent<slotdeitems>().itemName, slot.itemsprite, gameObject.tag);
                itemNameAux = gameObject.name;
                itemspriteAux = slot.itemsprite;
                tagAux = gameObject.tag;
                if (crafteo.crafteado)
                {
                    slot.RemoveItem();
                }
            }
        }
    }

    public void EnviarAEscaner()
    {
        if (slot.thisItemSelected && slot.isfull)
        {
            almacen.AddItemEscaner(gameObject.GetComponent<slotdeitems>().itemName, slot.itemsprite, gameObject.tag);
            itemNameAux = gameObject.name;
            itemspriteAux = slot.itemsprite;
            tagAux = gameObject.tag;
        }
        if (almacen.enviado)
        {
            slot.RemoveItem();
        }
    }
}