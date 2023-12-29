using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSpeedUp", menuName = "PowerUps/Universal/Speed Up")]
public class SpeedUp : PowerupEffect
{
    [SerializeField]
    private PlayerData data;

    [SerializeField]
    private float ammount;

    public override void ApplyEffect(GameObject obj)
    {
        data.moveVelocity += ammount;
    }
}
