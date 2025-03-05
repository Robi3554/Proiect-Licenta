using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FasterBurning", menuName = "PowerUps/Universal/FasterBurning")]
public class FasterBurning : PowerupEffect
{
    public override void ApplyEffect(GameObject obj)
    {
        PlayerStatsManager.Instance.timeBetweenBurn -= 0.25f;

        if(!PlayerStatsManager.Instance.statsWontGoDown)
            PlayerStatsManager.Instance.burnDamage -= 0.5f;
    }
}
