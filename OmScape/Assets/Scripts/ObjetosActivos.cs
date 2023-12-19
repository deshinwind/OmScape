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

    public GameObject bufandaO;
    public GameObject cajonO;

    public Sprite cajonSprit;

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

        if (bufandaO != null)
        {
            if (bufanda)
            {
                Invoke("OrdenBufanda", 0.5f);
            }
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

    public void OrdenBufanda()
    {
        bufandaO.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
}
