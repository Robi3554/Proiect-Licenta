using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HitNegation", menuName = "PowerUps/Universal/HitNegation")]
public class HitNegation : PowerupEffect
{
    public override void ApplyEffect(GameObject obj)
    {
        obj.GetComponentInChildren<Player>().canNegateHits = true;
    }
}
