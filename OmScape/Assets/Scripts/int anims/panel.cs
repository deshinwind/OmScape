using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel : MonoBehaviour
{
    [SerializeField] private ParticleSystem particulas;
    public bool escaneado = false;
    public Crafteo crafteo;

    private void Start()
    {
        crafteo = GameObject.Find("Canvas2").GetComponent<Crafteo>();
    }

    private void Update()
    {
        
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
