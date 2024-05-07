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
    [SerializeField]
    internal string rarity;
    public bool isUnique;

    [Header("Element")]
    [SerializeField]
    internal bool isFireElement;
    [SerializeField]
    internal bool isIceElement;

    private bool inTrigger = false;

    [SerializeField]
    private int points;

    private InventoryManager inventoryManager;

    public bool isSubscribed = false;

    public PowerUpList list;

    public delegate void PowerUpPoints(int ammount);
    public event PowerUpPoints PowerUpIncrease;

    private void Awake()
    {
        inventoryManager = GameObject.Find("Inventory Canvas").GetComponent<InventoryManager>();

        PlayerInputHandler playerInput = FindObjectOfType<PlayerInputHandler>();

        if (playerInput != null)
        {
            playerInput.PowerUp += PowerUpHandlerPick;
        } 

        points = PointsToIncrease();
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
            PowerUpIncrease?.Invoke(points);
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

    private int PointsToIncrease()
    {
        if (rarity.Equals("common"))
            return 20;
        else if (rarity.Equals("rare"))
            return 55;
        else if (rarity.Equals("legendary"))
            return 100;
        else
            return 999;
    }
}
