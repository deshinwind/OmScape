using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInventario : MonoBehaviour
{
    public static ControladorInventario instancia;

    private void Awake()
    {
        if (ControladorInventario.instancia == null)
        {
            ControladorInventario.instancia = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
