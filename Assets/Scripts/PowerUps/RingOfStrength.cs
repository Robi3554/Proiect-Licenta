using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RingOfStrength", menuName = "PowerUps/Universal/Ring Of Strength")]
public class RingOfStrength : PowerupEffect
{
    public AggresiveWeaponData data;

    public float dAmount;
    public float kAmount;

    public override void ApplyEffect(GameObject obj)
    {
        for (int i = 0; i < 3; i++)
        {
            data.AttackDetails[i].damageAmount += dAmount;
            data.AttackDetails[i].knockbackStrength += kAmount;
        }
    }
}
