using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Triciclo : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent_;
    public Transform Posicion_objetos;
    public Cachinero cachinero;
    public float error_distancia;
    public Transform posicion_objetivo;
    public Transform posicion_dond_dejar_a_cachinero;
    public Musica musica_manager;
    private AudioSource audio_source_;

    
    private void Awake()
    {
        audio_source_ = GetComponent<AudioSource>();
        cachinero.NavMeshAgent_.enabled = false;
    }
    private void Start()
    {
        NavMeshAgent_.destination = transform.position;
    }
    private void Update()
    {
        if (posicion_objetivo != null)
        {
            if (Vector3.Distance(transform.position, posicion_objetivo.position) < error_distancia)
            {
                Bajar_a_cachinero();
                this.enabled = false;
            }
        }
    }
    public void Ir_a_lugar(Transform posicion)
    {
        posicion_objetivo = posicion;
        NavMeshAgent_.destination = posicion.position;
        audio_source_.clip = musica_manager.Get_musica_disponible();
        audio_source_.Play();
    }
    public void Bajar_a_cachinero()
    {
        Activar_componentes_cachinero();

        cachinero.transform.parent = null;
        cachinero.transform.position = posicion_dond_dejar_a_cachinero.position;
        NavMeshAgent_.enabled = false;
        cachinero.NavMeshAgent_.enabled = true;
        cachinero.Recoger_siguiente_objeto_en_lista();
    }
    private void Activar_componentes_cachinero()
    {
        cachinero.GetComponent<Animator>().enabled = true;
        cachinero.GetComponent<Animacion_controller>().enabled = true;
        //cachinero.GetComponent<Rigidbody>().isKinematic = false;
        cachinero.GetComponent<Collider>().enabled = true;
        cachinero.GetComponent<Cachinero>().enabled = true;
        cachinero.GetComponent<NavMeshAgent>().enabled = true;
    }
    
}
