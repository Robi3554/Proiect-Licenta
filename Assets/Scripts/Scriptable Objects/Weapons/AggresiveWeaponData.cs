using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AggresiveWeapon Data", menuName = "Data/Weapon Data/Aggresive Weapon")]
public class AggresiveWeaponData : WeaponData
{
    [SerializeField]
    private WeaponAttackDetails[] attackDetails;

    public WeaponAttackDetails[] AttackDetails { get => attackDetails; private set => attackDetails = value; }

    private void OnEnable()
    {
        amountOfAttacks = attackDetails.Length;

        moveSpeed = new float[amountOfAttacks];

        for (int i = 0; i < amountOfAttacks; i++) 
        {
            moveSpeed[i] = attackDetails[i].moveSpeed;
        }
    }
}
