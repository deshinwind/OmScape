using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panel : MonoBehaviour
{
    [SerializeField] private ParticleSystem particulas;
    public bool escaneado = false;
    public Crafteo crafteo;
    public Animator escaneop;

    public bool desactivada = true;

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
