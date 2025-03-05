using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Immolation", menuName = "PowerUps/Universal/Immolation")]
public class Immolation : PowerupEffect
{
    public override void ApplyEffect(GameObject obj)
    {
        PlayerStatsManager.Instance.burnDamage += 2;

        PlayerStatsManager.Instance.fireDuration += 1;
    }
}
