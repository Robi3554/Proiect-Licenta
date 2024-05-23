using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player SFX")]
    [field: SerializeField]
    public EventReference playerWalk {  get; private set; } 

    [field: Header("Powerup Pickup")]
    [field: SerializeField]
    public EventReference pickup { get; private set; }

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
