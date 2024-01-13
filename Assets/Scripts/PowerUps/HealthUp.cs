using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newHealthUp", menuName = "PowerUps/Universal/Health Up")]
public class HealthUp : PowerupEffect
{
    public float healthAmount;

    public override void ApplyEffect(GameObject obj)
    {
        obj.GetComponentInChildren<PlayerStats>().maxHealth += healthAmount;
        obj.GetComponentInChildren<PlayerStats>().IncreaseHealth(healthAmount / 2);
    }
}
