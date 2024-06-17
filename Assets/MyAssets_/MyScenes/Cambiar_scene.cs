using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiar_scene : MonoBehaviour
{
    
    public void Cambiar_scene_(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
