using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodPowerUp", menuName = "PowerUps/Universal/FoodPowerUp")]
public class FoodPowerUp : PowerupEffect
{
    public int healthAmount;

    public int speedAmount;

    public override void ApplyEffect(GameObject obj)
    {
        obj.GetComponentInChildren<PlayerStats>().maxHealth += healthAmount;
        obj.GetComponentInChildren<PlayerStats>().IncreaseHealth(healthAmount / 2);

        if (!PlayerStatsManager.Instance.statsWontGoDown)
        {
            PlayerStatsManager.Instance.moveVelocity -= speedAmount;
        }
    }
}
