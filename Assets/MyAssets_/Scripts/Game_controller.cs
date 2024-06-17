using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Game_controller : MonoBehaviour
{
    public Horda_cachineros_manager horda_Cachineros_Manager;
    
    public TextMeshProUGUI textoHora;
    public hora_ inicio_hora;
    public hora_ hora_bus_viene;
    public float velocidadSimulacion = 1.0f; // La velocidad a la que avanza la hora simulada

    public Camion_basura camion_Basura;
    public DateTime horaSimulada;
    public TextMeshProUGUI text_Precio_final_game_over;
    public GameObject UI_game_over;
    public Trigger_objetos_triciclo_player trigger_Objetos_Triciclo_Player_;

    void Start()
    {
        horda_Cachineros_Manager.Comenzar_a_spawnear();
        horaSimulada=horaSimulada.AddHours(inicio_hora.hora);
        horaSimulada=horaSimulada.AddMinutes(inicio_hora.minuto);
        horaSimulada=horaSimulada.AddSeconds(inicio_hora.segundo);
        // Inicia la hora simulada con la hora actual del sistema
        //horaSimulada = DateTime.Now;
        
    }

    void Update()
    {
        // Avanza la hora simulada con el tiempo transcurrido desde el último frame
        horaSimulada = horaSimulada.AddSeconds(Time.deltaTime * velocidadSimulacion);


        // Formatea la hora simulada en un string
        string horaFormateada = horaSimulada.ToString("HH:mm");

        // Actualiza el texto en la interfaz de usuario
        textoHora.text = "" + horaFormateada;
        if (horaSimulada.Hour == hora_bus_viene.hora && horaSimulada.Minute == horaSimulada.Minute)
        {
            camion_Basura.Activar();
        }
    }
    public void On_Camion_llega_al_final()
    {
        Time.timeScale = 0;
        Debug.Log("CAMION LLEGO AL FINAL");
        UI_game_over.SetActive(true);
        text_Precio_final_game_over.text = "Precio objetos: "+trigger_Objetos_Triciclo_Player_.precio_total_objetos_dentro+"";
    }

}
[Serializable]
public class hora_
{
    public hora_()
    {

    }
    public int hora;
    public int minuto;
    public int segundo;
}
