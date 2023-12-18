using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebadepausa : MonoBehaviour
{

    public GameObject aqui;
    public void PauseGame()
    {
       aqui.SetActive(true);
        
    }

    private void Update()
    {
        if (aqui.activeSelf)
        {
            if (Input.GetMouseButtonDown(1))
            {
               aqui.SetActive(false);
            }
            
        }
    }
}
