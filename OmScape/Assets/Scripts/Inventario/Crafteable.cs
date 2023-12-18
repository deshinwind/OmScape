using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Crafteable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string itemname;
    [SerializeField] private Sprite sprite;

    private Crafteo crafteo;
    private panel panel;
    private AlmacenSensor almacen;

    public slotdeitems slot;

    public string itemNameAux;
    public Sprite itemspriteAux;
    public string tagAux;

    void Start()
    {
        crafteo = GameObject.Find("Canvas2").GetComponent<Crafteo>();

        if (SceneManager.GetActiveScene().name.Equals("panel"))
        {
            almacen = GameObject.Find("Canvas").GetComponent<AlmacenSensor>();
            panel = GameObject.Find("Canvas").GetComponent<panel>();
        }
    }

    private void Update()
    {
        if (panel != null && !crafteo.crafteoActivo)
        {

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (panel != null && !crafteo.crafteoActivo)
            {
                EnviarAEscaner();
            }
            else
            {
                EnviarACrafteo();
            }
        }
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
            else
            {
                print("la mamaste");
            }
        }
    }

    public void EnviarAEscaner()
    {
        if (slot.thisItemSelected && slot.isfull)
        {
            almacen.AddItemEscaner(gameObject.GetComponent<slotdeitems>().itemName, slot.itemsprite, gameObject.tag);
        }
    }
}