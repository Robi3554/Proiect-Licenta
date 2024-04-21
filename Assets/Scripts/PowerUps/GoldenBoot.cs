using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Golden Boot", menuName = "PowerUps/Universal/Golden Boot")]
public class GoldenBoot : PowerupEffect
{
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private float jumpIncrease;
    [SerializeField]
    private float speedIncrease;

    public override void ApplyEffect(GameObject obj)
    {
        playerData.ammountOfJumps++;

        playerData.jumpVelocity += jumpIncrease;

        playerData.moveVelocity += speedIncrease;
    }
}
