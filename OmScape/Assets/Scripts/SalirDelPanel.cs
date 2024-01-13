using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirDelPanel : MonoBehaviour
{
    public AlmacenSensor almacen;
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.timeScale == 1)
        {
            if (almacen.slot[0].isfull)
            {
                GameObject.Find("Inventario").GetComponent<Inventario>().AddItemFromCraft(almacen.slot[0].itemName, almacen.slot[0].itemsprite, almacen.slot[0].tag);
            }
            if (almacen.slot[1].isfull)
            {
                GameObject.Find("Inventario").GetComponent<Inventario>().AddItemFromCraft(almacen.slot[1].itemName, almacen.slot[1].itemsprite, almacen.slot[1].tag);
            }
            if (almacen.slot[2].isfull)
            {
                GameObject.Find("Inventario").GetComponent<Inventario>().AddItemFromCraft(almacen.slot[2].itemName, almacen.slot[2].itemsprite, almacen.slot[2].tag);
            }

            SceneManager.LoadScene("H2");
        }
    }
}
