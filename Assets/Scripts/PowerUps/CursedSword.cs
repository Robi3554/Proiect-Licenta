using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCursedSword", menuName = "PowerUps/Swordsman/CursedSword")]
public class CursedSword : PowerupEffect
{
    [SerializeField]
    private AggresiveWeaponData data;

    public PlayerData pData;

    private int attackCounter = 0;

    public override void ApplyEffect(GameObject obj)
    {
        for (int i = 0; i < 3; i++)
        {
            data.AttackDetails[attackCounter].damageAmount *= 2;
            attackCounter++;
        }
        attackCounter = 0;

        if(!pData.statsWontGoDown)
            obj.GetComponentInChildren<PlayerStats>().maxHealth = Mathf.Ceil(obj.GetComponentInChildren<PlayerStats>().maxHealth / 2); 
    }
}
