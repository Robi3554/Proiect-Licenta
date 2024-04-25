using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FasterBurning", menuName = "PowerUps/Universal/FasterBurning")]
public class FasterBurning : PowerupEffect
{
    [SerializeField]
    private PlayerData playerData;

    public override void ApplyEffect(GameObject obj)
    {
        playerData.timeBetweenBurn -= 0.25f;

        playerData.burnDamage -= 0.5f;
    }
}
