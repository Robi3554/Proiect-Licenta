using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Data/Weapon Data/Weapon")]
public class WeaponData : ScriptableObject
{
    public int amountOfAttacks { get; protected set; }

    public float[] moveSpeed { get; protected set; }
}
