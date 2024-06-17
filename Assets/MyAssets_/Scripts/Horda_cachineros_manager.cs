using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horda_cachineros_manager : MonoBehaviour
{
    public List<triciclo_tiempo> triciclos;
    


    public void Activar_triciclo(Triciclo triciclo,Transform posicion)
    {
        triciclo.Ir_a_lugar(posicion);
    }
    public void Comenzar_a_spawnear()
    {
        StartCoroutine(Comenzar());
    }
    private void Update()
    {
        
    }
    private IEnumerator Comenzar()
    {
        foreach (triciclo_tiempo item in triciclos)
        {
            yield return new WaitForSeconds(item.tiempo);
            item.triciclo.Ir_a_lugar(item.posicion);

        }
    }
    
}
[System.Serializable]
public class triciclo_tiempo
{
    public Triciclo triciclo;
    public Transform posicion;
    public float tiempo;
}
