using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Golden Boot", menuName = "PowerUps/Universal/Golden Boot")]
public class GoldenBoot : PowerupEffect
{
    [SerializeField]
    private float jumpIncrease;
    [SerializeField]
    private float speedIncrease;

    public override void ApplyEffect(GameObject obj)
    {
        PlayerStatsManager.Instance.amountOfJumps++;

        PlayerStatsManager.Instance.jumpVelocity += jumpIncrease;

        PlayerStatsManager.Instance.moveVelocity += speedIncrease;
    }
}
