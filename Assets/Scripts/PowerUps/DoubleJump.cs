using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jump Ammount Increase", menuName = "PowerUps/Universal/JumpAmmountIncrease")]
public class DoubleJump : PowerupEffect
{
    [SerializeField]
    private PlayerData playerData;

    public override void ApplyEffect(GameObject obj)
    {
        playerData.ammountOfJumps++;
    }
}
