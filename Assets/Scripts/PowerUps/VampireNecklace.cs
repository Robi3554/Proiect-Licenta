using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VampireNecklace", menuName = "PowerUps/Universal/VampireNecklace")]
public class VampireNecklace : PowerupEffect
{
    public override void ApplyEffect(GameObject obj)
    {
        obj.GetComponent<Player>().canStealLife = true;
    }
}
