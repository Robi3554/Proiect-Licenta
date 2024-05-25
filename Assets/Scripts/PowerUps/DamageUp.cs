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

    public override void ApplyEffect(GameObject obj)
    {
        for (int i = 0; i < 3; i++)
        {
            data.AttackDetails[i].damageAmount += ammount;
        }
    }
}
