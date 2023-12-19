using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Crafteable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string itemname;
    [SerializeField] private Sprite sprite;

    private Crafteo crafteo;
    private panel panel;
    private AlmacenSensor almacen;
    private AlmacenFusibles alamcenFusibles;
    public GameObject fusiblesInterfaz;

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
    void Update()
    {
        if (alamcenFusibles == null)
        {
            if (SceneManager.GetActiveScene().name.Equals("H1"))
            {
                alamcenFusibles = GameObject.Find("Canvas").GetComponent<AlmacenFusibles>();
                fusiblesInterfaz = GameObject.Find("CrafreoMenu");
                fusiblesInterfaz.SetActive(false);
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
                    EnviarAEscaner();
                }
            }
            else if (!crafteo.crafteoActivo)
            {
                if (SceneManager.GetActiveScene().name.Equals("H1") && fusiblesInterfaz.activeSelf)
                {
                    EnviarAFusible();
                }
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
            itemNameAux = gameObject.name;
            itemspriteAux = slot.itemsprite;
            tagAux = gameObject.tag;
        }
        if (almacen.enviado)
        {
            slot.RemoveItem();
        }
    }

    public void EnviarAFusible()
    {
        if (slot.thisItemSelected && slot.isfull)
        {
            alamcenFusibles.AddItemFusibles(gameObject.GetComponent<slotdeitems>().itemName, slot.itemsprite, gameObject.tag);
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