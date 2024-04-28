using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
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

    [Header("PowerUp Info")]
    [SerializeField]
    private string powerUpName;
    [SerializeField]
    private Sprite sprite;
    [TextArea]
    [SerializeField]
    internal string powerUpDescription;

    [Header("Element")]
    [SerializeField]
    internal bool isFireElement;
    [SerializeField]
    internal bool isIceElement;

    private bool inTrigger = false;

    private InventoryManager inventoryManager;

    public bool isUnique;

    public PowerUpList list;

    private void Awake()
    {
        inventoryManager = GameObject.Find("Inventory Canvas").GetComponent<InventoryManager>();

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
            inventoryManager.AddPowerUp(powerUpName, sprite, powerUpDescription);
            if(isUnique)
                RemoveFromList(gameObject);
            Destroy(gameObject);
        }
    }

    private void RemoveFromList(GameObject obj)
    {
        if(list.powerUps != null)
        {
            for(int i = 0; i < list.powerUps.Length; i++)
            {
                if (obj.name.StartsWith(list.powerUps[i].name))
                {
                    list.powerUps[i] = null;

                    for (int j = i; j < list.powerUps.Length - 1; j++)
                    {
                        list.powerUps[j] = list.powerUps[j + 1];
                    }

                    Array.Resize(ref list.powerUps, list.powerUps.Length - 1);
                    break;
                }
            }
        }
    }
}
