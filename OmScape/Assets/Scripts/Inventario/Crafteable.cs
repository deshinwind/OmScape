using UnityEngine;
using UnityEngine.EventSystems;

public class Crafteable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string itemname;
    [SerializeField] private Sprite sprite;

    private Crafteo crafteo;

    public slotdeitems slot;

    public string itemNameAux;
    public Sprite itemspriteAux;
    public string tagAux;

    void Start()
    {
        crafteo = GameObject.Find("Canvas2").GetComponent<Crafteo>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            EnviarACrafteo();
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
}