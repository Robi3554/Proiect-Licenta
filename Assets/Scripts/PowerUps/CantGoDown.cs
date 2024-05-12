using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Faith", menuName = "PowerUps/Universal/Faith")]
public class CantGoDown : PowerupEffect
{
    public PlayerData data;

    public override void ApplyEffect(GameObject obj)
    {
        data.statsWontGoDown = true;
    }
}
