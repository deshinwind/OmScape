using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puntero : MonoBehaviour
{
    public GameObject objeto;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Raycasteo();
        }
    }

    public void Raycasteo()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.transform.name.Equals("Linterna"))
        {
            objeto.GetComponent<recolectable>().EnviarAInventario();
            Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
        }
        else
        {
            print("FY");
        }
    }
}
