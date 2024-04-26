using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependancyShow : MonoBehaviour
{
    private PowerUp pu;

    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private Color regularColor;

    void Start()
    {
        pu = GetComponent<PowerUp>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if(pu.isFireElement == true && col.GetComponent<Player>().canLightOnFire == true ||
                pu.isIceElement == true && col.GetComponent<Player>().canSlow == true)
            {
                sr.color = regularColor;    
            }
        }
    }
}
