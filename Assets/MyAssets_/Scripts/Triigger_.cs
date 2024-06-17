using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Triigger_ : MonoBehaviour
{
    public UnityEvent eventos;
    public List<string> tags_para_activar;
    private void OnTriggerEnter(Collider other)
    {
        foreach (string tag_ in tags_para_activar)
        {
            if (other.tag == tag_)
            {
                Debug.Log(tag_);
                eventos.Invoke();
                
            }
        }
        
    }


}
