using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Immolation", menuName = "PowerUps/Universal/Immolation")]
public class Immolation : PowerupEffect
{
    public PlayerData playerData;

    public override void ApplyEffect(GameObject obj)
    {
        playerData.burnDamage += 2;

        playerData.fireDuration += 1;
    }
}
