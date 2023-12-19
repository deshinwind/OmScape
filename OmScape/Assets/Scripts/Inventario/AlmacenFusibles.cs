using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlmacenFusibles : MonoBehaviour
{
    public slotdeitems slot;

    public Inventario inventario;
    public ObjetosActivos activos;
    public CameraZoomController zoomController;

    public bool enviado;
    public bool desactivada = true;


    void Start()
    {
        zoomController = GameObject.Find("Zoom").GetComponent<CameraZoomController>();
        activos = GameObject.Find("Canvas2").GetComponent<ObjetosActivos>();
        inventario = GameObject.Find("Canvas2").GetComponent<Inventario>();
    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name.Equals("H2"))
        {
            if (activos.fusibles)
            {
                if (desactivada)
                {
                    GameObject.Find("puerta").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/interfaz/vacio");
                    desactivada = false;
                }
            }
        }
    }
}
