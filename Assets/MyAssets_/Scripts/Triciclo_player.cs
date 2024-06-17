using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triciclo_player : MonoBehaviour
{

    public Trigger_objetos_triciclo_player trigger_Objetos_Triciclo_Player;
    private void Start()
    {
        StartCoroutine(Desactivar_activar_trigger());
    }
    private void Update()
    {
        
        
    }
    public void Activar_trigger()
    {
        trigger_Objetos_Triciclo_Player.gameObject.SetActive(true);
    }
    public void Desactivar_trigger()
    {
        trigger_Objetos_Triciclo_Player.gameObject.SetActive(false);
    }
    private IEnumerator Desactivar_activar_trigger()
    {
        while (true)
        {
            trigger_Objetos_Triciclo_Player.precio_total_objetos_dentro = 0;
            Activar_trigger();
            yield return new WaitForSeconds(0.2f);
            Desactivar_trigger();
            yield return new WaitForSeconds(0.2f);
        }
    }
    
}
