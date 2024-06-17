using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast_puntero : MonoBehaviour
{
    public float distancia;
    public RectTransform puntero_UI;
    public float max_scale;
    public float min_scale;

    public List<string> tags_puntero;
    // Start is called before the first frame update
    void Start()
    {
        puntero_UI.sizeDelta = new Vector2(min_scale, min_scale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject Castear_rayo()
    {
        RaycastHit raycastHit;


        if (Physics.Raycast(transform.position, transform.forward, out raycastHit, distancia))
        {
            foreach (string item in tags_puntero)
            {
                if (item == raycastHit.collider.tag)
                {
                    puntero_UI.sizeDelta = new Vector2(max_scale, max_scale);
                    return raycastHit.collider.gameObject;
                }
            }

        }
        else
        {
            puntero_UI.sizeDelta = new Vector2(min_scale, min_scale);
        }
        return null;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * distancia);
    }
}
