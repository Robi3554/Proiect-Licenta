using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Universal/Explosion")]
public class ExplosionPowerUp : PowerupEffect
{
    public override void ApplyEffect(GameObject obj)
    {
        obj.GetComponent<Player>().canCauseExplosions = true;
    }
}
