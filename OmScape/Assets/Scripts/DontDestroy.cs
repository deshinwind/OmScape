using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instancia1;
    public static DontDestroy instancia2;
    public static DontDestroy instancia3;

    //Evita que se duplique el Canvas2 cuando vulve a la escena H1

    void Start()
    {
        if (gameObject.name.Equals("Canvas2"))
        {
            if (instancia1 == null)  //Si es la primera vez que entra en la escena H1, guarda el canvas en la instancia
            {
                instancia1 = this;
                GameObject.DontDestroyOnLoad(this.gameObject);
            }
            else //Si la instancia ya tiene un Canvas, elimina el nuevo Canvas"
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.name.Equals("Main Camera"))
        {
            if (instancia2 == null)  //Si es la primera vez que entra en la escena H1, guarda el canvas en la instancia
            {
                instancia2 = this;
                GameObject.DontDestroyOnLoad(this.gameObject);
            }
            else //Si la instancia ya tiene un Canvas, elimina el nuevo Canvas"
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.name.Equals("ControladorSonido"))
        {
            if (instancia3 == null)
            {
                instancia3 = this;
                GameObject.DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
