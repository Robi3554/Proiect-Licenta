using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Swordsman/Sword Wave")]
public class SwordWavePowerUp : PowerupEffect
{
    public override void ApplyEffect(GameObject obj)
    {
        obj.GetComponent<Swordsman>().canShoot = true;
    }
}
