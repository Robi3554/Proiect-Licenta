using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Swordman/Sword Wave")]
public class SwordWavePowerUp : PowerupEffect
{
    public override void ApplyEffect(GameObject obj)
    {
        obj.GetComponentInChildren<Player>().canFire = true;
    }
}
