using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIceAtr", menuName = "PowerUps/Universal/Ice Atribute")]
public class IceAtr : PowerupEffect
{
    public override void ApplyEffect(GameObject obj)
    {
        obj.GetComponentInChildren<Player>().canSlow = true;
    }
}
