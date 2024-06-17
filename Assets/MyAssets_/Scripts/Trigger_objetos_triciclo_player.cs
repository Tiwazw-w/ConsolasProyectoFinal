using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trigger_objetos_triciclo_player : MonoBehaviour
{
    public TextMeshProUGUI precio_objetos;
    public List<GameObject> objetos;
    public float precio_total_objetos_dentro;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Objeto")
        {
            precio_total_objetos_dentro = precio_total_objetos_dentro + other.gameObject.GetComponent<Objeto_recogible>().precio;

            objetos.Add(other.gameObject);

        }
        precio_objetos.text = "Precio objetos: " + precio_total_objetos_dentro + "";
    }
    private void OnTriggerStay(Collider other)
    {
        
        
    }

}
