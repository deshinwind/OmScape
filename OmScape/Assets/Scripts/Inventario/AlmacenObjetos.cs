using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumObjetos { Coche1, Coche2, Coche3, Destornillador, Comic1, Comic2, Clip, Foto1, Foto2, FusibleAzul, FusibleRojo, FusibleVerde, FusibleBlanco, FusibleNegro, FusibleAmarillo, Barrena, FotoCompleta, Ganzua, LinternaObjeto };

public class AlmacenObjetos : MonoBehaviour
{
    public bool[] objetoRecogido;

    public void RecogerObjeto(string nombre)
    {
        EnumObjetos objeto = (EnumObjetos)System.Enum.Parse(typeof(EnumObjetos), nombre);
        switch (objeto)
        {
            case EnumObjetos.Coche1:
                objetoRecogido[(int)EnumObjetos.Coche1] = true;
                break;
            case EnumObjetos.Coche2:
                objetoRecogido[(int)EnumObjetos.Coche2] = true;
                break;
            case EnumObjetos.Coche3:
                objetoRecogido[(int)EnumObjetos.Coche3] = true;
                break;
            case EnumObjetos.Destornillador:
                objetoRecogido[(int)EnumObjetos.Destornillador] = true;
                break;
            case EnumObjetos.Comic1:
                objetoRecogido[(int)EnumObjetos.Comic1] = true;
                break;
            case EnumObjetos.Comic2:
                objetoRecogido[(int)EnumObjetos.Comic2] = true;
                break;
            case EnumObjetos.Clip:
                objetoRecogido[(int)EnumObjetos.Clip] = true;
                break;
            case EnumObjetos.Foto1:
                objetoRecogido[(int)EnumObjetos.Foto1] = true;
                break;
            case EnumObjetos.Foto2:
                objetoRecogido[(int)EnumObjetos.Foto2] = true;
                break;
            case EnumObjetos.FusibleAzul:
                objetoRecogido[(int)EnumObjetos.FusibleAzul] = true;
                break;
            case EnumObjetos.FusibleRojo:
                objetoRecogido[(int)EnumObjetos.FusibleRojo] = true;
                break;
            case EnumObjetos.FusibleVerde:
                objetoRecogido[(int)EnumObjetos.FusibleVerde] = true;
                break;
            case EnumObjetos.FusibleBlanco:
                objetoRecogido[(int)EnumObjetos.FusibleBlanco] = true;
                break;
            case EnumObjetos.FusibleNegro:
                objetoRecogido[(int)EnumObjetos.FusibleNegro] = true;
                break;
            case EnumObjetos.FusibleAmarillo:
                objetoRecogido[(int)EnumObjetos.FusibleAmarillo] = true;
                break;
            case EnumObjetos.Barrena:
                objetoRecogido[(int)EnumObjetos.Barrena] = true;
                break;
            case EnumObjetos.FotoCompleta:
                objetoRecogido[(int)EnumObjetos.FotoCompleta] = true;
                break;
            case EnumObjetos.Ganzua:
                objetoRecogido[(int)EnumObjetos.Ganzua] = true;
                break;
            case EnumObjetos.LinternaObjeto:
                objetoRecogido[(int)EnumObjetos.LinternaObjeto] = true;
                break;
        }
    }

    public bool ComprobarObjeto(string nombre)
    {
        EnumObjetos objeto = (EnumObjetos)System.Enum.Parse(typeof(EnumObjetos), nombre);
        switch (objeto)
        {
            case EnumObjetos.Coche1:
                if (objetoRecogido[(int)EnumObjetos.Coche1]) { return true; }
                else { return false; }
            case EnumObjetos.Coche2:
                if (objetoRecogido[(int)EnumObjetos.Coche2]) { return true; }
                else { return false; }
            case EnumObjetos.Coche3:
                if (objetoRecogido[(int)EnumObjetos.Coche3]) { return true; }
                else { return false; }
            case EnumObjetos.Destornillador:
                if (objetoRecogido[(int)EnumObjetos.Destornillador]) { return true; }
                else { return false; }
            case EnumObjetos.Comic1:
                if (objetoRecogido[(int)EnumObjetos.Comic1]) { return true; }
                else { return false; }
            case EnumObjetos.Comic2:
                if (objetoRecogido[(int)EnumObjetos.Comic2]) { return true; }
                else { return false; }
            case EnumObjetos.Clip:
                if (objetoRecogido[(int)EnumObjetos.Clip]) { return true; }
                else { return false; }
            case EnumObjetos.Foto1:
                if (objetoRecogido[(int)EnumObjetos.Foto1]) { return true; }
                else { return false; }
            case EnumObjetos.Foto2:
                if (objetoRecogido[(int)EnumObjetos.Foto2]) { return true; }
                else { return false; }
            case EnumObjetos.FusibleAzul:
                if (objetoRecogido[(int)EnumObjetos.FusibleAzul]) { return true; }
                else { return false; }
            case EnumObjetos.FusibleRojo:
                if (objetoRecogido[(int)EnumObjetos.FusibleRojo]) { return true; }
                else { return false; }
            case EnumObjetos.FusibleVerde:
                if (objetoRecogido[(int)EnumObjetos.FusibleVerde]) { return true; }
                else { return false; }
            case EnumObjetos.FusibleBlanco:
                if (objetoRecogido[(int)EnumObjetos.FusibleBlanco]) { return true; }
                else { return false; }
            case EnumObjetos.FusibleNegro:
                if (objetoRecogido[(int)EnumObjetos.FusibleNegro]) { return true; }
                else { return false; }
            case EnumObjetos.FusibleAmarillo:
                if (objetoRecogido[(int)EnumObjetos.FusibleAmarillo]) { return true; }
                else { return false; }
            case EnumObjetos.Barrena:
                if (objetoRecogido[(int)EnumObjetos.Barrena]) { return true; }
                else { return false; }
            case EnumObjetos.FotoCompleta:
                if (objetoRecogido[(int)EnumObjetos.FotoCompleta]) { return true; }
                else { return false; }
            case EnumObjetos.Ganzua:
                if (objetoRecogido[(int)EnumObjetos.Ganzua]) { return true; }
                else { return false; }
            case EnumObjetos.LinternaObjeto:
                if (objetoRecogido[(int)EnumObjetos.LinternaObjeto]) { return true; }
                else { return false; }
            default:
                return false;
        }
    }
}
