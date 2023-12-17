using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel : MonoBehaviour
{
    [SerializeField] private ParticleSystem particulas;
    
     void fallaste()
    {
        particulas.Play();
    }

}
