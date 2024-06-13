using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Ambience")]
    [field: SerializeField]
    public EventReference wind {  get; private set; }

    [field: Header("Music")]
    [field: SerializeField]
    public EventReference music { get; private set; }

    [field: Header("Player SFX")]
    [field: SerializeField]
    public EventReference playerWalk {  get; private set; }
    [field: SerializeField]
    public EventReference deathSound { get; private set; }

    [field: Header("Powerup Pickup")]
    [field: SerializeField]
    public EventReference pickup { get; private set; }
    [field: SerializeField]
    public EventReference approach { get; private set; }

    [field: Header("Loot Pickup")]
    [field: SerializeField]
    public EventReference lootPickup { get; private set; }

    public static FMODEvents Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one FMODEvents instance in the scene!");
        }
        Instance = this;
    }
}
