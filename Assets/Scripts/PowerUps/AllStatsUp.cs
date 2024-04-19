using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "AllStatsUp", menuName = "PowerUps/Universal/AllStatsUp")]
public class AllStatsUp : PowerupEffect
{
    [SerializeField]
    private AggresiveWeaponData data;
    [SerializeField]
    private PlayerData playerData;

    private int attackCounter = 0;

    public int hAmmount;
    public int dAmmount;
    public int sAmmount;

    public float atkSpeedPercentage;

    public override void ApplyEffect(GameObject obj)
    {
        ChangeDamage(dAmmount);

        ChangeSpeed(sAmmount);

        ChangeAtkSpeed(atkSpeedPercentage);

        obj.GetComponentInChildren<PlayerStats>().maxHealth += hAmmount;
        obj.GetComponentInChildren<PlayerStats>().IncreaseHealth(obj.GetComponentInChildren<PlayerStats>().maxHealth);
    }

    public void ChangeAtkSpeed(float value)
    {
        playerData.attackSpeed = playerData.attackSpeed + (playerData.attackSpeed * (value / 100));
    }

    public void ChangeDamage(float value)
    {
        for (int i = 0; i < 3; i++)
        {
            data.AttackDetails[attackCounter].damageAmount += value;
            attackCounter++;
        }
        attackCounter = 0;
    }

    public void ChangeSpeed(float value)
    {
        playerData.moveVelocity += value;
    }
}
