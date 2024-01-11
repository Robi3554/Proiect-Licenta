using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAttackSpeedUp", menuName = "PowerUps/Universal/Attack Speed Up")]
public class AttackSpeedUp : PowerupEffect
{
    [SerializeField]
    private PlayerData data;

    [SerializeField]
    private float percentage;

    public override void ApplyEffect(GameObject obj)
    {
        ChangeAtkSpeed(percentage);
    }

    public void ChangeAtkSpeed(float value)
    {
        data.attackSpeed = data.attackSpeed + (data.attackSpeed * (value / 100));
    }
}
