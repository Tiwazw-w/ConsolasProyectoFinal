using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Fps : MonoBehaviour
{
    public TextMeshProUGUI texto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = Mathf.RoundToInt(1 / Time.deltaTime) + " FPS";
    }

    
}
