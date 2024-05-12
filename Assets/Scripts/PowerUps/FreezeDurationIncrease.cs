using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "ColderWind", menuName = "PowerUps/Universal/ColderWind")]
public class FreezeDurationIncrease : PowerupEffect
{
    public PlayerData data;

    public float ammount;

    public override void ApplyEffect(GameObject obj)
    {
        data.slowDuration += ammount;
    }
}
