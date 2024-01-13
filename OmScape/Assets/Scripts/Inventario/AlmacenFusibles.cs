using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlmacenFusibles : MonoBehaviour
{
    public bool enviado;
    public bool desactivada = true;

    public slotdeitems slot;

    public Inventario inventario;

    public ObjetosActivos activos;

    public CameraZoomController zoomController;

    void Start()
    {
        zoomController = GameObject.Find("Zoom").GetComponent<CameraZoomController>();
        activos = GameObject.Find("Canvas2").GetComponent<ObjetosActivos>();
        inventario = GameObject.Find("Inventario").GetComponent<Inventario>();
    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name.Equals("H1"))
        {
            if (activos.fusibles)
            {
                if (desactivada)
                {
                    GameObject.Find("Puerta").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/interfaz/vacio");
                    desactivada = false;
                }
            }
        }
    }
}
