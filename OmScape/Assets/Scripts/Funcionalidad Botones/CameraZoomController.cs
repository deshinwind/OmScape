using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraZoomController : MonoBehaviour
{
    public bool[] zoomCheck;
    
    public float[] zoomController;

    public Vector2[] posicionBotones;

    public Camera cam;

    public GameObject botonesPanel;
    public GameObject[] botones;
    public GameObject[] objetos;
    public GameObject[] notas;

    public ObjetosActivos objetosActivos;

    private int n = 0;
    private int numeroBotones;

    public float speed = 0.1f;
    private float zoomDefault = 5;

    void Start()
    {
        cam = Camera.main;
        numeroBotones = botones.Length;
        PosicionBotones();

        objetosActivos = GameObject.Find("Canvas2").GetComponent<ObjetosActivos>(); //Quitar esta referenciacion y ponerla desde el inspector (CUANDO PONGA EL ZOOM GENERICO)

        objetos = new GameObject[GameObject.Find("Objetos").transform.childCount];
        notas = new GameObject[GameObject.Find("Notas").transform.childCount];

        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i] = GameObject.Find("Objetos").transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < notas.Length; i++)
        {
            notas[i] = GameObject.Find("Notas").transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("H1"))
        {
            if (objetosActivos.bufanda && objetosActivos.cajaDeFusibles && objetosActivos.candado && !objetosActivos.boton.activeSelf && zoomCheck[1] && !objetosActivos.fusibles)
            {
                Invoke("ActivarBotonFusibles", 0.5f);
            }

            if (!zoomCheck[1])
            {
                objetosActivos.boton.SetActive(false);

                if (!objetosActivos.bufanda) { if (objetos[0].activeSelf) { objetos[0].GetComponent<BoxCollider2D>().enabled = false; } }
                if (!objetosActivos.cajaDeFusibles) { if (objetos[1].activeSelf) { objetos[1].GetComponent<BoxCollider2D>().enabled = false; } }
            }
            else
            {
                if (objetosActivos.cajaDeFusibles){ objetos[0].GetComponent<SpriteRenderer>().sortingOrder = 0; }
                else { objetos[0].GetComponent<SpriteRenderer>().sortingOrder = 2; }
                if (!objetosActivos.bufanda) { if (objetos[0].activeSelf) { objetos[0].GetComponent<BoxCollider2D>().enabled = true; } }
                if (!objetosActivos.cajaDeFusibles) { if (objetos[1].activeSelf) { objetos[1].GetComponent<BoxCollider2D>().enabled = true; } }
            }
        }
        else if (SceneManager.GetActiveScene().name.Equals("H2"))
        {
            if (zoomCheck[4])
            {
                if (objetos[0].activeSelf) { objetos[0].GetComponent<BoxCollider2D>().enabled = true; }
                if (objetos[1].activeSelf) { objetos[1].GetComponent<BoxCollider2D>().enabled = true; }
                if (objetos[2].activeSelf) { objetos[2].GetComponent<BoxCollider2D>().enabled = true; }
            }
            else if (zoomCheck[1])
            {
                if (notas[0].activeSelf) { notas[0].GetComponent<BoxCollider2D>().enabled = true; }
            }
            else
            {
                if (objetos[0] != null)
                    if (objetos[0].activeSelf) { objetos[0].GetComponent<BoxCollider2D>().enabled = false; }
                if (objetos[1] != null)
                    if (objetos[1].activeSelf) { objetos[1].GetComponent<BoxCollider2D>().enabled = false; }
                if (objetos[2] != null)
                    if (objetos[2].activeSelf) { objetos[2].GetComponent<BoxCollider2D>().enabled = false; }
                if (notas[0] != null)
                    if (notas[0].activeSelf) { notas[0].GetComponent<BoxCollider2D>().enabled = false; }
            }
        }
        else if (SceneManager.GetActiveScene().name.Equals("H3"))
        {
            if (zoomCheck[3])
            {
                if (objetos[0].activeSelf) { objetos[0].GetComponent<BoxCollider2D>().enabled = true; }
            }
            else
            {
                if (objetos[0] != null)
                {
                    if (objetos[0].activeSelf) { objetos[0].GetComponent<BoxCollider2D>().enabled = false; }
                }
                
            }
        }
        else if (SceneManager.GetActiveScene().name.Equals("H4"))
        {
            if (zoomCheck[3])
            {
                if (objetos[0].activeSelf) { objetos[0].GetComponent<BoxCollider2D>().enabled = true; }
                if (notas[1].activeSelf) { notas[1].GetComponent<BoxCollider2D>().enabled = true; }
            }
            else if (zoomCheck[6])
            {
                if (notas[0].activeSelf) { notas[0].GetComponent<BoxCollider2D>().enabled = true; }
            }
            else
            {
                if (objetos[0] != null)
                    if (objetos[0].activeSelf) { objetos[0].GetComponent<BoxCollider2D>().enabled = false; }
                if (notas[0] != null)
                    if (notas[0].activeSelf) { notas[0].GetComponent<BoxCollider2D>().enabled = false; }
                if (notas[1] != null)
                    if (notas[1].activeSelf) { notas[1].GetComponent<BoxCollider2D>().enabled = false; }
            }
        }
    }

    public void LateUpdate()
    {
        if (!GameObject.Find("Bloqueo").GetComponent<BoxCollider2D>().enabled)
        {
            Zoom();
        }

        if (!botonesPanel.activeInHierarchy)
        {
            if (!(EventSystem.current.currentSelectedGameObject == null))
            {
                if (EventSystem.current.currentSelectedGameObject.name.Equals("H2Cama"))
                {
                    Invoke("ActivarBaul", 0.35f);
                }
            }

            if (Input.GetMouseButtonDown(1) && Time.timeScale == 1)
            {
                zoomCheck[n] = false;
                n = 0;
                Invoke("ActivarBotones", 0.35f);
            }
        }
    }

    public void ActivarBotonFusibles()
    {
        objetosActivos.boton.SetActive(true);
    }

    public void Zoom()
    {
        if (n == 0)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomDefault, speed);
            cam.transform.position = Vector2.Lerp(cam.transform.position, Vector2.zero, speed);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomController[n], speed);
            cam.transform.position = Vector2.Lerp(cam.transform.position, posicionBotones[n-1], speed);
        }
    }

    public void ActivarBotones()
    {
        botonesPanel.SetActive(true);
        zoomCheck[n] = false;
    }

    public void BotonPulsado()
    {
        if (!GameObject.Find("Bloqueo").GetComponent<BoxCollider2D>().enabled)
        {
            string nombre = EventSystem.current.currentSelectedGameObject.name;
            for (int i = 0; i < botones.Length; i++)
            {
                if (botones[i].gameObject.name == nombre)
                {
                    n = i + 1;
                    ZoomCheck();
                }
            }
        }
    }
    public void ZoomCheck()
    {
        if (zoomCheck[n])
        {
            zoomCheck[n] = false;
        }
        else
        {
            zoomCheck[n] = true;
            DesactivarBotones();
        }
    }

    public void DesactivarBotones()
    {
        botonesPanel.SetActive(false);
        zoomCheck[0] = false;
    }

    private void PosicionBotones()
    {
        posicionBotones = new Vector2[numeroBotones];
        for (int i = 0; i < posicionBotones.Length; i++)
        {
            posicionBotones[i] = botones[i].transform.position;
        }
    }

    private void ActivarBaul()
    {
        GameObject.Find("Baul").GetComponent<Button>().enabled = true;
    }
}