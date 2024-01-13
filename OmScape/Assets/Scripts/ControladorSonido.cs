using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ControladorSonido : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void EjecutarSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }
}
