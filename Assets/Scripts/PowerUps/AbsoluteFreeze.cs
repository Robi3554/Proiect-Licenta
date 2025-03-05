using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbsoluteFreeze", menuName = "PowerUps/Universal/AbsoluteFreeze")]
public class AbsoluteFreeze : PowerupEffect
{
    public override void ApplyEffect(GameObject obj)
    {
        PlayerStatsManager.Instance.slowAmount = 100;

        if(!PlayerStatsManager.Instance.statsWontGoDown)
            PlayerStatsManager.Instance.slowDuration /= 2;
    }
}
