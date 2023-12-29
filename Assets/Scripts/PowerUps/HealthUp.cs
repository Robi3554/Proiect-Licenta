using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newHealthUp", menuName = "PowerUps/Universal/Health Up")]
public class HealthUp : PowerupEffect
{
    public float healthAmmount;

    public override void ApplyEffect(GameObject obj)
    {
        obj.GetComponentInChildren<Stats>().maxHealth += healthAmmount;
    }
}
