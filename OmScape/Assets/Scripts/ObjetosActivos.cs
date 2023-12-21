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

    public ObjetosActivos activos;

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

        if (SceneManager.GetActiveScene().name.Equals("H1") && boton == null)
        {
            boton = GameObject.Find("BotonFusibles");
            boton.SetActive(false);
        }

        if (cajonO != null)
        {
            if (cajon)
            {
                cajonO.GetComponent<SpriteRenderer>().sprite = cajonSprit;
            }
        }

    }

    public void FuncionControlFusibles()
    {
        for (int i = 0; i < inventario.tamañoMaximo; i++)
        {
            if (inventario.slotdeitems[i].thisItemSelected)
            {
                if (inventario.slotdeitems[i].itemName.Contains("Fusible"))
                {
                    if (inventario.slotdeitems[i].itemName.Equals("Fusible Azul"))
                    {
                        print("final");
                        fusibles = true;
                        boton.SetActive(false);
                        // CAMBIAR LA ANIMACION Y DEJAR EL FUSIBLE PUESTO
                        GameObject.Find("Linterna").GetComponent<Linterna>().LinternaDesactivada();
                    }
                    inventario.slotdeitems[i].RemoveItem();
                }
            }
        }
    }
}
