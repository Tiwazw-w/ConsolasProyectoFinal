using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar_desactivar_GO : MonoBehaviour
{
    public List<GameObject> objetos_a_desactivar;
    public List<GameObject> objetos_a_activar;

    public void Activar_()
    {
        foreach (GameObject item in objetos_a_activar)
        {
            item.SetActive(true);
        }
    }
    public void Desactivar()
    {
        foreach (GameObject item in objetos_a_desactivar)
        {
            item.SetActive(false);
        }
    }
}
