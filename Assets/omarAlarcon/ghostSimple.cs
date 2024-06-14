using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostSimple : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
