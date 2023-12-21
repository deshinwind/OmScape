using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panel : MonoBehaviour
{
    public bool escaneado = false;
    public bool desactivada = true;

    public Crafteo crafteo;

    public ParticleSystem particulas;
    
    public Animator escaneop;

    private void Start()
    {
        crafteo = GameObject.Find("Canvas2").GetComponent<Crafteo>();
        escaneop = gameObject.AddComponent<Animator>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("H2")/* && escaneado && desactivada*/)
        {
            if (escaneado)
            {
                if (desactivada)
                {
                    GameObject.Find("puerta").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/interfaz/vacio");
                    desactivada = false;
                }
            }
        }
    }

    public void neutro()
    {
        escaneop.SetBool("no", false);
    }
    public void fallaste()
    {
        escaneop.SetBool("no", true);
        particulas.Play();
        Invoke("neutro", 0.5f);
    }
    public void acertaste()
    {
        escaneop.SetBool("si", true);
    }

    public void Escanear()
    {
        escaneado = true;
    }
}
