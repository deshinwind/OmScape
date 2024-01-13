using UnityEngine;

public class Puntero : MonoBehaviour
{
    public bool correcto;

    public string[] listaObjetos;

    public GameObject objeto;

    public AlmacenObjetos almacenObjetos;

    public Crafteo crafteo;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            Raycasteo();
        }
    }

    public void Raycasteo()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (!crafteo.crafteoActivo)
        {
            if (hit.collider != null)
            {
                objeto = GameObject.Find(hit.transform.name);
                if (ComprobarNombreObjeto(hit))
                {
                    if (objeto.name.Equals("Bloqueo"))
                    {
                    }
                    else if (objeto.name.Equals("LinternaObjeto"))
                    {
                        objeto.GetComponent<recolectable>().Linterna();
                        almacenObjetos.RecogerObjeto(objeto.name);
                    }
                    else if (objeto.name.Equals("CajonDoble"))
                    {
                        objeto.GetComponent<doblefondo>().Abrir();
                    }
                    else if (objeto.name.Equals("Sensor"))
                    {
                        GameObject.Find("Canvas").GetComponent<ButtonFuncionality>().ButtonSensor();
                    }
                    else if (objeto.name.Equals("Bufanda"))
                    {
                        objeto.GetComponent<bufanda>().Abrir();
                    }
                    else if (objeto.name.Equals("CajaDeFusibles"))
                    {
                        objeto.GetComponent<cajadefusibles>().Abrir();
                    }
                    else if (objeto.name.Equals("Baul"))
                    {
                        objeto.GetComponent<Baul>().Abrir();
                    }
                    else if (objeto.name.Equals("Candado"))
                    {
                        objeto.GetComponent<candado>().Abrir();
                    }
                    else
                    {
                        objeto.GetComponent<recolectable>().EnviarAInventario();
                        if (GameObject.Find("Inventario").GetComponent<Inventario>().recolectado)
                        {
                            almacenObjetos.RecogerObjeto(objeto.name);
                        }
                    }
                }
                else
                {
                    objeto.GetComponent<Notas>().EnviarAlAlmacen();
                }
            }
        }
    }

    private bool ComprobarNombreObjeto(RaycastHit2D hit)
    {
        for (int i = 0; i < listaObjetos.Length; i++)
        {
            if (listaObjetos[i].Equals(hit.transform.name))
            {
                return true;
            }
        }
        return false;
    }
}
