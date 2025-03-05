using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Faith", menuName = "PowerUps/Universal/Faith")]
public class CantGoDown : PowerupEffect
{
    public override void ApplyEffect(GameObject obj)
    {
        PlayerStatsManager.Instance.statsWontGoDown = true;
    }
}
