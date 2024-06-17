using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Camion_basura : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent_;
    public Transform posicion_final;
    public float error_distancia;
    public Game_controller game_Controller;
    // Start is called before the first frame update
    private void Awake()
    {
        NavMeshAgent_ = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        StartCoroutine(preguntar_si_llego_al_final());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator preguntar_si_llego_al_final()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, posicion_final.position) <= error_distancia)
            {
                game_Controller.On_Camion_llega_al_final();
                break;
            }
            yield return null;
        }
    }
    public void Activar()
    {
        gameObject.SetActive(true);
        NavMeshAgent_.destination = posicion_final.position;
        
    }
}
