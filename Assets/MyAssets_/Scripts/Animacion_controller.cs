using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion_controller : MonoBehaviour
{
    public Animator animator;
    public List<string> animaciones;
    private string animacion_actual;
    public void Idle()
    {
        Set_all_parameters_bool_false();
        Cambiar_animacion("Idle");
    }
    public void Correr()
    {
        Set_all_parameters_bool_false();
        Cambiar_animacion("Corriendo");
    }
    public void Golpear()
    {
        Set_all_parameters_bool_false();
        Cambiar_animacion("Golpeando");
        //Debug.Log("Player golpeando");
    }
    public void Death()
    {
        Set_all_parameters_bool_false();
        Cambiar_animacion("Death");
    }
    private void Update()
    {

    }

    public void Cambiar_animacion(string nombre_animacion)
    {
        if (animacion_actual == nombre_animacion)
        {
            //return;
        }
        animacion_actual = nombre_animacion;
        Set_all_parameters_bool_false();
        animator.SetBool(nombre_animacion, true);
    }
    public void Idle_player()
    {
        animator.SetBool("Idle", true);
    }
    private void Set_all_parameters_bool_false()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Corriendo", false);
        animator.SetBool("Golpeando", false);
        animator.SetBool("Death", false);
    }
    
}
