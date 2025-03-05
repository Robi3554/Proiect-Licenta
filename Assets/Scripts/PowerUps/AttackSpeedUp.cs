using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAttackSpeedUp", menuName = "PowerUps/Universal/Attack Speed Up")]
public class AttackSpeedUp : PowerupEffect
{
    public float percentage;

    public override void ApplyEffect(GameObject obj)
    {
        ChangeAtkSpeed(percentage);
    }

    public void ChangeAtkSpeed(float value)
    {
        PlayerStatsManager.Instance.attackSpeed = PlayerStatsManager.Instance.attackSpeed + (PlayerStatsManager.Instance.attackSpeed * (value / 100));
    }
}
