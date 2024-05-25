using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuickBalde", menuName = "PowerUps/Swordsman/Quick Blade")]
public class QuickBlade : PowerupEffect
{
    public AggresiveWeaponData data;

    public PlayerData pData;

    public float ammount;

    public float percentage;

    public override void ApplyEffect(GameObject obj)
    {
        if (!pData.statsWontGoDown)
        {
            for (int i = 0; i < 3; i++)
            {
                data.AttackDetails[i].damageAmount -= ammount;
            }
        }

        ChangeAtkSpeed(percentage);
    }

    public void ChangeAtkSpeed(float value)
    {
        pData.attackSpeed = pData.attackSpeed + (pData.attackSpeed * (value / 100));
    }
}
