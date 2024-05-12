using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbsoluteFreeze", menuName = "PowerUps/Universal/AbsoluteFreeze")]
public class AbsoluteFreeze : PowerupEffect
{
    [SerializeField]
    private PlayerData playerData;

    public override void ApplyEffect(GameObject obj)
    {
        playerData.slowAmmount = 100;

        if(playerData.statsWontGoDown)
            playerData.slowDuration /= 2;
    }
}
