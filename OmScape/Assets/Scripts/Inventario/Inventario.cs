using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventario : MonoBehaviour
{
    public bool inventarioActivo;
    public bool recolectado;
    public bool linterna;
    public bool dobleFondo;
    public bool cajonAbierto;
    public bool comicUsado = false;
    public bool cocheUsado = false;
    public bool fusibleAzul = false;
    public bool fusibleVerde = false;
    public bool fusibleRojo = false;
    public bool fusibleBlanco = false;
    public bool fusibleNegro = false;
    public bool fusibleAmarillo = false;
    public bool barrena = false;

    public int tamañoMaximo = 6;

    public GameObject inventorymenu;
    public GameObject crafteoMenu;
    public GameObject objeto;
    public GameObject nota;

    public Sprite foto;
    public Sprite ganzua;
    public slotdeitems[] slotdeitems;

    public Crafteo crafteo;

    public AlmacenNotas almacen;

    public static Inventario instancia;

    private List<int> numeroObjeto;
    private List<int> numeroNota;

    

    private void Start()
    {
        if (instancia == null)  //Guarda el Canvas del inventario y evita que se dupliquen el resto
        {
            instancia = this;
            if (!gameObject.name.Equals("Canvas"))
            {
                GameObject.DontDestroyOnLoad(this.gameObject);
            }
        }
        else
        {
            if (!gameObject.name.Equals("Canvas"))
            {
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Inventario") && inventarioActivo)  //Abrir y cerrar el inventario
        {
            if (crafteo.crafteoActivo)
            {
                if (crafteo.slotdeitems[0].isfull)
                {
                    crafteo.AñadirAInventario(0);
                    crafteo.EliminarItem(0);
                }
                if (crafteo.slotdeitems[1].isfull)
                {
                    crafteo.AñadirAInventario(1);
                    crafteo.EliminarItem(1);
                }
                crafteoMenu.SetActive(false);
                crafteo.crafteoActivo = false;
            }
            else
            {
                inventorymenu.SetActive(false);
                inventarioActivo = false;
            }
        }
        else if (Input.GetButtonDown("Inventario") && !inventarioActivo)
        {
            inventorymenu.SetActive(true);
            inventarioActivo = true;
        }
    }

    public void ComprobarFotosRepetidas()
    {
        numeroNota = new List<int>();
        nota = GameObject.Find("Notas");

        for (int i = 0; i < nota.transform.childCount; i++)
        {
            if (nota.transform.GetChild(i).name.Contains("P"))
            {
                switch (nota.transform.GetChild(i).name)
                {
                    case "P0":
                        if (almacen.notasPosesiones[0]) { numeroNota.Add(i); }
                        break;
                    case "P1":
                        if (almacen.notasPosesiones[1]) { numeroNota.Add(i); }
                        break;
                    case "P2":
                        if (almacen.notasPosesiones[2]) { numeroNota.Add(i); }
                        break;
                    case "P3":
                        if (almacen.notasPosesiones[3]) { numeroNota.Add(i); }
                        break;
                    case "P4":
                        if (almacen.notasPosesiones[4]) { numeroNota.Add(i); }
                        break;
                    case "P5":
                        if (almacen.notasPosesiones[5]) { numeroNota.Add(i); }
                        break;
                }
            }
            else if (nota.transform.GetChild(i).name.Contains("N"))
            {
                switch (nota.transform.GetChild(i).name)
                {
                    case "N0":
                        if (almacen.notasNarrativa[0]) { numeroNota.Add(i); }
                        break;
                    case "N1":
                        if (almacen.notasNarrativa[1]) { numeroNota.Add(i); }
                        break;
                    case "N2":
                        if (almacen.notasNarrativa[2]) { numeroNota.Add(i); }
                        break;
                    case "N3":
                        if (almacen.notasNarrativa[3]) { numeroNota.Add(i); }
                        break;
                    case "N4":
                        if (almacen.notasNarrativa[4]) { numeroNota.Add(i); }
                        break;
                }
            }
        }
        for (int i = 0; i < numeroNota.Count; i++)
        {
            nota.transform.GetChild(numeroNota[i]).gameObject.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name.Equals("Baul") || SceneManager.GetActiveScene().name.Equals("cajon"))
        {
            nota.SetActive(false);
        }
    }

    public void ComprobarRepetidos()    //Comprueba si los objetos que están en la escena ya han sido recogidos y los elimina
    {
        numeroObjeto = new List<int>();
        objeto = GameObject.Find("Objetos");

        for (int i = 0; i < objeto.transform.childCount; i++)
        {
            for (int j = 0; j < tamañoMaximo; j++)
            {
                if ((objeto.transform.GetChild(i).CompareTag("foto") && crafteo.fotoCrafteada)      //Comprueba si la foto o la ganzua han sido crafteadas
                    || (objeto.transform.GetChild(i).CompareTag("ganzua") && crafteo.ganzuaCrafteada))
                {
                    numeroObjeto.Add(i);
                }
                if (objeto.transform.GetChild(i).name.Equals(slotdeitems[j].itemName))
                {
                    numeroObjeto.Add(i);
                }
                if (objeto.transform.GetChild(i).name.Equals("LinternaObjeto"))
                {
                    if (linterna)
                    {
                        numeroObjeto.Add(i);
                    }
                }
                if (objeto.transform.GetChild(i).name.Equals("Coche 1") && cocheUsado)
                {
                    numeroObjeto.Add(i);
                }
                if (objeto.transform.GetChild(i).name.Equals("Comic 1") && comicUsado)
                {
                    numeroObjeto.Add(i);
                }
                if (objeto.transform.GetChild(i).name.Equals("Barrena") && barrena)
                {
                    numeroObjeto.Add(i);
                }
                if (objeto.transform.GetChild(i).name.Contains("Fusible"))
                {
                    if (objeto.transform.GetChild(i).name.Contains("Azul") && fusibleAzul)
                    {
                        numeroObjeto.Add(i);
                    }
                    else if (objeto.transform.GetChild(i).name.Contains("Rojo") && fusibleRojo)
                    {
                        numeroObjeto.Add(i);
                    }
                    else if (objeto.transform.GetChild(i).name.Contains("Verde") && fusibleVerde)
                    {
                        numeroObjeto.Add(i);
                    }
                    else if (objeto.transform.GetChild(i).name.Contains("Blanco") && fusibleBlanco)
                    {
                        numeroObjeto.Add(i);
                    }
                    else if (objeto.transform.GetChild(i).name.Contains("Negro") && fusibleNegro)
                    {
                        numeroObjeto.Add(i);
                    }
                    else if (objeto.transform.GetChild(i).name.Contains("Amarillo") && fusibleAmarillo)
                    {
                        numeroObjeto.Add(i);
                    }
                }
            }
        }

        for (int i = 0; i < numeroObjeto.Count; i++)
        {
            objeto.transform.GetChild(numeroObjeto[i]).gameObject.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name.Equals("Baul") || SceneManager.GetActiveScene().name.Equals("cajon"))
        {
            objeto.SetActive(false);
        }
    }
    public void AddItem(string itemname, Sprite itemsprite, string valorTag)    //Añade items del entorno al inventario
    {
        recolectado = false;
        if (!crafteo.crafteoActivo)
        {
            for (int i = 0; i < tamañoMaximo; i++)
            {
                if (!slotdeitems[i].isfull)
                {
                    slotdeitems[i].AddItem(itemname, itemsprite);
                    slotdeitems[i].tag = valorTag;
                    recolectado = true;
                    return;
                }
                // HACER UN ELSE QUE HAGA UNA PEQUEÑA ANIMACION O ALGO QUE INDIQUE AL USUARIO QUE EL CRAFTEO ESTÁ LLENO
            }
        }
    }
    public void AddItemFromCraft(string itemname, Sprite itemsprite, string valorTag)   //Añade items del crafteo al inventario
    {
        for (int i = 0; i < tamañoMaximo; i++)
        {
            if (!slotdeitems[i].isfull)
            {
                slotdeitems[i].AddItem(itemname, itemsprite);
                slotdeitems[i].tag = valorTag;
                recolectado = true;
                return;
            }
        }
    }
    public void AddObjetoCrafteado(string itemname, string valorTag)    //Añade el item crafteado al inventario
    {
        if (valorTag.Equals("Sensor"))
        {
            for (int i = 0; i < tamañoMaximo; i++)
            {
                if (!slotdeitems[i].isfull)
                {
                    slotdeitems[i].AddItem(itemname, foto);
                    slotdeitems[i].tag = valorTag;
                    recolectado = true;
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < tamañoMaximo; i++)
            {
                if (!slotdeitems[i].isfull)
                {
                    slotdeitems[i].AddItem(itemname, ganzua);
                    slotdeitems[i].tag = valorTag;
                    recolectado = true;
                    return;
                }
            }
        }
    }
    public void DeselectAllSlots()  //Deselecciona los slots del inventario
    {
        for (int i = 0; i < tamañoMaximo; i++)
        {
            slotdeitems[i].selectedshader.SetActive(false);
            slotdeitems[i].thisItemSelected = false;
        }
    }

    public bool InventarioLleno()
    {
        for (int i = 0; i < tamañoMaximo; i++)
        {
            if (!slotdeitems[i].isfull)
            {
                return false;
            }
        }

        return true;
    }
}
