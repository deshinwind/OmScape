using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjetosActivos : MonoBehaviour
{
    public bool bufanda;
    public bool cajaDeFusibles;
    public bool cajon;
    public bool baul;
    public bool candado;
    public bool fusibles;

    public GameObject bufandaO;
    public GameObject cajonO;
    public GameObject boton;

    public Sprite cajonSprit;

    public Inventario inventario;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("H1") && bufandaO == null)
        {
            bufandaO = GameObject.Find("bufanda");
        }
        else if (SceneManager.GetActiveScene().name.Equals("cajon") && cajonO == null)
        {
            cajonO = GameObject.Find("doble");
        }

        /*if (SceneManager.GetActiveScene().name.Equals("H1") && boton == null)
        {
            boton = GameObject.Find("BotonFusibles");
            boton.SetActive(false);
        }*/

        if (candado && cajaDeFusibles && bufanda)
        {
            boton.SetActive(true);
        }

        if (cajonO != null)
        {
            if (cajon)
            {
                cajonO.GetComponent<SpriteRenderer>().sprite = cajonSprit;
            }
        }

    }

    public void Bufanda()
    {
        bufanda = true;
    }

    public void CajaDeFusibles()
    {
        cajaDeFusibles = true;
    }

    public void Cajon()
    {
        cajon = true;
    }

    public void Baul()
    {
        baul = true;
    }

    public void Candado()
    {
        candado = true;
    }

    public void Fusibles()
    {
        fusibles = true;
    }

    public void FuncionControlFusibles()
    {
        for (int i = 0; i < inventario.slotdeitems.Length; i++)
        {
            print(inventario.slotdeitems[i].itemName);
            if (inventario.slotdeitems[i].itemName.Equals("Fusible Azul"))
            {
                print("final");
                fusibles = true;
                break;
            }
        }
    }
}
