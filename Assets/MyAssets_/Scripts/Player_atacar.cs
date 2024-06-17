using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_atacar : MonoBehaviour
{
    public Player_ player;
    public RayCast_puntero puntero;
    public void Atacar_()
    {
        GameObject objeto_detectado = puntero.Castear_rayo();
        if (objeto_detectado != null)
        {
            if (objeto_detectado.tag == "Cachinero")
            {
                Debug.Log("Player atacando");
                
                Cachinero cachinero_detectado=objeto_detectado.GetComponent<Cachinero>();
                cachinero_detectado.vida = cachinero_detectado.vida - player.daño;
            }
        }
        
    }
}
