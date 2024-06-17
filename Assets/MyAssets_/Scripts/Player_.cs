using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player_ : MonoBehaviour
{
    public RayCast_puntero puntero;
    public Transform posicion_objeto_agarrado;
    public GameObject objeto_agarrado;
    public bool agarrando_objeto;
    public float vida;
    public Animacion_controller animacion_Controller;
    public float coldown_golpe;
    public bool disponible_golpear;
    public float daño;
    public Slider vida_UI;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //StartCoroutine(Coldown_golpe_());
        vida_UI.maxValue = vida;
    }

    // Update is called once per frame
    void Update()
    {
        vida_UI.value = vida;
        puntero.Castear_rayo();
        //if (objeto_agarrado!= null)
        //{
        //    if (Input.GetKeyDown(KeyCode.F))
        //    {
        //        Debug.Log("f");
        //        Soltar_objeto();
        //    }
        //}
        
       
        
    }
    private IEnumerator Coldown_golpe_()
    {
        float contador=0;
        while (true)
        {
            contador = contador + Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (contador > coldown_golpe)
                {
                    
                    //animacion_Controller.animator
                    //Debug.Log("Golpeando");
                    contador = 0;
                }
            }
            yield return null;
            
        }
    }
    public void Disponible_golpear_true()
    {
        disponible_golpear = true;
    }
    public void OnFire(InputAction.CallbackContext context)
    {

        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log("OnFire"); 
            if (disponible_golpear)
            {
                disponible_golpear = false;
                animacion_Controller.animator.Play("Golpeando", 0, 0.25f);
                Invoke("Disponible_golpear_true", coldown_golpe);
            }
        }
    }
    public void Agarrar_soltar(InputAction.CallbackContext context)
    {

        if (context.phase == InputActionPhase.Started)
        {
            if (objeto_agarrado != null)
            {

                Soltar_objeto();

            }
            else
            {

                GameObject gameObject_detectado = puntero.Castear_rayo();
                if (gameObject_detectado != null)
                {
                    if (gameObject_detectado.tag == "Objeto")
                    {
                        Debug.Log(gameObject_detectado.tag);
                        Agarrar_objeto(gameObject_detectado);
                    }
                    else
                    {
                        Debug.Log(gameObject_detectado.tag);
                    }



                }
            }
        }
    }

    public void Agarrar_objeto(GameObject objeto)
    {
        objeto_agarrado = objeto;
        objeto.GetComponent<Collider>().enabled = false;
        objeto.GetComponent<Rigidbody>().isKinematic = true;
        agarrando_objeto = true;
        objeto.transform.parent = posicion_objeto_agarrado;
        objeto.transform.localPosition = new Vector3(0, 0, 0);

    }
    public void Soltar_objeto()
    {
        objeto_agarrado.GetComponent<Collider>().enabled = true;
        objeto_agarrado.GetComponent<Rigidbody>().isKinematic = false;
        objeto_agarrado.transform.parent = null;
        objeto_agarrado = null;
        Debug.Log("Soltar");
    }
}
