using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField]
    private GameObject pickupEffect;
    [SerializeField]
    private PowerupEffect powerupEffect;

    [Header("Info Box")]
    [SerializeField]
    private GameObject infoBox;

    private bool inTrigger = false;

    private void Awake()
    {
        PlayerInputHandler playerInput = FindObjectOfType<PlayerInputHandler>();

        if (playerInput != null)
        {
            playerInput.PowerUp += PowerUpHandlerPick;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            inTrigger = true;
            infoBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            inTrigger = false;
            infoBox.SetActive(false);
        }
    }

    private void PowerUpHandlerPick(Collider2D col)
    {
        if(inTrigger)
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
            powerupEffect.ApplyEffect(col.gameObject);
            Destroy(gameObject);
        }
    }
}
