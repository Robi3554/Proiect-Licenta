using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AggresiveWeapon Data", menuName = "Data/Weapon Data/Ranged Weapon")]
public class RangedWeaponData : WeaponData
{
    [SerializeField]
    private RAttackDetails[] attackDetails;

    public RAttackDetails[] AttackDetails { get => attackDetails; private set => attackDetails = value; }

    public GameObject projectile;

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
