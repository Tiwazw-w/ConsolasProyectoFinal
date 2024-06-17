using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    public List<AudioClip> musicas;
    public int index_musica_actual_disponible;
    private void Awake()
    {
        index_musica_actual_disponible = -1;
        Mix_musica();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Mix_musica();
        }
    }
    public void Mix_musica()
    {
        for (int i = musicas.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            AudioClip temp = musicas[i];
            musicas[i] = musicas[j];
            musicas[j] = temp;
        }
       
    }
    public AudioClip Get_musica_disponible()
    {
        index_musica_actual_disponible++;
        return musicas[index_musica_actual_disponible];
        
    }
}
