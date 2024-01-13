using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCamera : MonoBehaviour
{
    void OnEnable()
    {
        gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
    }
}
