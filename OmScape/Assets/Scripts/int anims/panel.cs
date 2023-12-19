using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panel : MonoBehaviour
{
    [SerializeField] private ParticleSystem particulas;
    public bool escaneado = false;
    public Crafteo crafteo;
    private Animator escaneop;

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
            print(SceneManager.GetActiveScene().name.Equals("H2"));
            if (escaneado)
            {
                print(escaneado);
                if (desactivada)
                {
                    print(desactivada);
                    GameObject.Find("puerta").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/interfaz/vacio");
                    print("HOLA");
                    desactivada = false;
                }
            }
            
        }
    }

    public void fallaste()
    {
        
        particulas.Play();

    }

    public void Escanear()
    {
        escaneado = true;
    }
}
