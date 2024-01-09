using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAttackSpeedUp", menuName = "PowerUps/Universal/Attack Speed Up")]
public class AttackSpeedUp : PowerupEffect
{
    public float percentage;

    public override void ApplyEffect(GameObject obj)
    {
        obj.GetComponentInChildren<Player>().ChangeAtkSpeed(percentage);
    }
}
