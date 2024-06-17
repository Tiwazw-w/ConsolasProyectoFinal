using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cachinero : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent_;

    public float velocidad;
    public Player_ Player_objetivo;
    public float daño;
    public float distancia_para_ver_a_player;
    public float distancia_para_atacar_a_player;
    public GameObject objeto_recogido;
    public Triciclo triciclo;
    public Transform posicion_objeto_recogido;
    public float distancia_para_recoger_objeto;

    public Animacion_controller animacion_Controller;
    public bool Llevando_objeto_a_triciclo;
    public bool Recogiendo_objeto;

    public List<GameObject> objetos_por_recoger;

    public int index_objeto_lista_actual;
    public bool atacando_a_player;

    public float vida;
    private void Start()
    {
        Mix_objetos();
    }
    private void Update()
    {
        if(Vector3.Distance(Player_objetivo.gameObject.transform.position, transform.position) < distancia_para_ver_a_player)
        {
            
            Atacar_a_player();
            
        }
        if (vida <= 0)
        {
            Death_();
        }
    }
    private void Mix_objetos()
    {
        for (int i = objetos_por_recoger.Count - 1; i > 0; i--)
        {
            
            int j = UnityEngine.Random.Range(0, i + 1);
            GameObject temp = objetos_por_recoger[i];
            objetos_por_recoger[i] = objetos_por_recoger[j];
            objetos_por_recoger[j] = temp;
        }
    }
    public void Atacar_a_player()
    {
        if (atacando_a_player == false)
        {
            if (Llevando_objeto_a_triciclo)
            {
                Soltar_objeto(objeto_recogido.transform);
            }
            StopAllCoroutines();
            StartCoroutine(Atacar_a_player_());
        }
    }
    public void Death_()
    {
        StopAllCoroutines();
        animacion_Controller.Death();
        
        NavMeshAgent_.enabled = false;
        GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }
    private IEnumerator Atacar_a_player_()
    {
        
        atacando_a_player = true;
        while(true)
        {
            if(Vector3.Distance(Player_objetivo.gameObject.transform.position, transform.position) < distancia_para_atacar_a_player)
            {
                Golpear();
                transform.LookAt(new Vector3(Player_objetivo.transform.position.x,transform.position.y,Player_objetivo.transform.position.z));
            }
            else
            {
                Ir_a_lugar(Player_objetivo.transform);
            }
            yield return null;
        }
    }
    public void Golpear()
    {
        animacion_Controller.Golpear();
        NavMeshAgent_.destination = transform.position;
    }
    public void Idle()
    {
        animacion_Controller.Idle();
        NavMeshAgent_.destination = transform.position;
    }
    public void Ir_a_lugar(Transform posicion)
    {
        animacion_Controller.Correr();
        NavMeshAgent_.destination = posicion.position;
    }
    public void Recoger_objeto(GameObject objeto)
    {
        if (Recogiendo_objeto == false)
        {
            StartCoroutine(Coroutine_Recoger_objeto(objeto));
        }
    }
    public void Bajar_vida_a_player()
    {
        Player_objetivo.vida = (Player_objetivo.vida - daño);
        //Debug.Log("Bajando vida a player");
    }
    public void Recoger_siguiente_objeto_en_lista()
    {
        index_objeto_lista_actual++;
        if (index_objeto_lista_actual <= objetos_por_recoger.Count-1)
        {
            Recoger_objeto(objetos_por_recoger[index_objeto_lista_actual]);
        }
        else
        {
            Idle();
        }
    }
    public void Soltar_objeto(Transform posicion)
    {
        objeto_recogido.GetComponent<Collider>().enabled = true;
        objeto_recogido.GetComponent<Rigidbody>().isKinematic = false;
        objeto_recogido.transform.parent = null;
        objeto_recogido.transform.position = posicion.position;
        objeto_recogido = null;
    }
    public IEnumerator Coroutine_Llevar_objeto_a_triciclo()
    {
        Llevando_objeto_a_triciclo = true;
        while (true)
        {
            if (Vector3.Distance(transform.position, triciclo.transform.position) > distancia_para_recoger_objeto)
            {
                Ir_a_lugar(triciclo.transform);
            }
            else
            {
                Soltar_objeto(triciclo.Posicion_objetos);
                
                Llevando_objeto_a_triciclo = false;
                Recoger_siguiente_objeto_en_lista();
                
                break;
            }
            yield return null;
        }
    }

    public IEnumerator Coroutine_Recoger_objeto(GameObject objeto)
    {
        Recogiendo_objeto = true;
        while (true)
        {
            if (Vector3.Distance(transform.position, objeto.transform.position) > distancia_para_recoger_objeto)
            {
                Ir_a_lugar(objeto.transform);
            }
            else
            {
                objeto.GetComponent<Collider>().enabled = false;
                objeto.GetComponent<Rigidbody>().isKinematic = true;
                objeto.transform.parent = posicion_objeto_recogido;
                objeto.transform.localPosition = new Vector3(0, 0, 0);
                objeto_recogido = objeto;
                Recogiendo_objeto = false;
                StartCoroutine(Coroutine_Llevar_objeto_a_triciclo());

                break;
            }
            yield return null;
        }
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distancia_para_recoger_objeto);
        Gizmos.color=Color.blue;
        Gizmos.DrawWireSphere(transform.position, distancia_para_ver_a_player);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distancia_para_atacar_a_player);
    }
}
