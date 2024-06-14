using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManagerScript : MonoBehaviour
{
    int tiempo;
   public TextMeshProUGUI textTime;

    // Start is called before the first frame update
    void Start()
    {
        tiempo = 0;
        InvokeRepeating("time", 1, 1);
    }

    

    void time()
    {
        tiempo = tiempo + 1;
        textTime.text = "Tiempo: " + tiempo;
    }
}
