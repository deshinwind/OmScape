using UnityEngine;

public class Puntero : MonoBehaviour
{
    public GameObject objeto;
    public string[] listaObjetos;
    public bool correcto;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Raycasteo();
        }
    }

    public void Raycasteo()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            ComprobarNombreObjeto(hit);

            if (correcto)
            {
                objeto = GameObject.Find(hit.transform.name);

                if (objeto.name.Equals("NotaFalsa"))
                {
                    objeto.GetComponent<Notas>().MostrarNotaFalsa();
                }
                else if (objeto.name.Length == 2)
                {
                    objeto.GetComponent<Notas>().EnviarAlAlmacen();
                }
                else if (objeto.name.Equals("LinternaObjeto"))
                {
                    objeto.GetComponent<recolectable>().Linterna();
                }
                else if (objeto.name.Equals("doble"))
                {
                    objeto.GetComponent<doblefondo>().Abrir();
                }
                else if (objeto.name.Equals("Sensor"))
                {
                    GameObject.Find("Canvas").GetComponent<ButtonFuncionality>().ButtonSensor();
                }
                else if (objeto.name.Equals("bufanda"))
                {
                    objeto.GetComponent<bufanda>().Abrir();
                }
                else if (objeto.name.Equals("caja de fusibles"))
                {
                    objeto.GetComponent<cajadefusibles>().Abrir();
                }
                else if (objeto.name.Equals("baul"))
                {
                    objeto.GetComponent<Baul>().Abrir();
                }
                else if (objeto.name.Equals("candado"))
                {
                    objeto.GetComponent<candado>().Abrir();
                }
                else
                {
                    objeto.GetComponent<recolectable>().EnviarAInventario();
                }
            }
        }
    }

    private void ComprobarNombreObjeto(RaycastHit2D hit)
    {
        correcto = false;

        for (int i = 0; i < listaObjetos.Length; i++)
        {
            if (listaObjetos[i].Equals(hit.transform.name))
            {
                correcto = true;
            }
        }
    }
}
