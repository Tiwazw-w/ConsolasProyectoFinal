using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlatformCheck : MonoBehaviour
{
   public TextMeshProUGUI plataforma;
    void Start()
    {
#if UNITY_STANDALONE_WIN
        Debug.Log("You are running on Windows.");
        plataforma.text = "You are running on Windows.";
#else
       Debug.Log("You are running on Xbox.");
        plataforma.text = "You are running on xbox.";
#endif
    }
}
