using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newHeart", menuName = "Loot/Heart")]
public class Heart : Loot
{
    public float healAmount;

    public override void TouchPlayer(GameObject obj)
    { 
        obj.GetComponentInChildren<PlayerStats>().IncreaseHealth(healAmount);
    }
}
