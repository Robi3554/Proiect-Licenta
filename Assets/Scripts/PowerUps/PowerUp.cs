using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private GameObject pickupEffect;
    [SerializeField]
    private PowerupEffect powerupEffect;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
            powerupEffect.ApplyEffect(col.gameObject);
            Destroy(gameObject);
        }
    }

}
