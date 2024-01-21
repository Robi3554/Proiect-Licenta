using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newFireAtr", menuName = "PowerUps/Universal/Fire Atribute")]
public class FlameAtr : PowerupEffect
{
    public override void ApplyEffect(GameObject obj)
    {
        obj.GetComponentInChildren<PlayerCombat>().enabled = true;
    }
}
