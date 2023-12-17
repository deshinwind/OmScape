using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CameraZoomController : MonoBehaviour
{
    public bool[] zoomCheck;
    public float[] zoomController;
    [SerializeField] private Camera cam;
    private float speed = 0.0125f;
    public GameObject botonesPanel;
    public GameObject[] botones;
    public Vector2[] posicionBotones;

    private float zoomDefault = 5;
    private int n = 0;
    private int numeroBotones;

    public GameObject baul;

    void Start()
    {
        cam = Camera.main;
        numeroBotones = botones.Length;
        PosicionBotones(numeroBotones);
    }

    private void Update()
    {
        if (zoomCheck[1])
        {
            baul.SetActive(true);
        }
    }

    public void LateUpdate()
    {
        Zoom();
        
        if (!botonesPanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                zoomCheck[n] = false;
                n = 0;
                Invoke("ActivarBotones", 0.35f);
            }
        }
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

    private void PosicionBotones(int numeroBotones)
    {
        posicionBotones = new Vector2[numeroBotones];
        for (int i = 0; i < posicionBotones.Length; i++)
        {
            posicionBotones[i] = botones[i].transform.position;
        }
    }
}