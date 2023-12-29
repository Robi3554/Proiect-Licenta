using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDamageUp", menuName = "PowerUps/Universal/Damage Up")]
public class DamageUp : PowerupEffect
{
    [SerializeField]
    private AggresiveWeaponData data;

    [SerializeField]
    private float ammount;

    private int attackCounter = 0;

    public override void ApplyEffect(GameObject obj)
    {
        for (int i = 0; i < 3; i++)
        {
            data.AttackDetails[attackCounter].damageAmount += ammount;
            attackCounter++;
        }
        attackCounter = 0;
    }
}
