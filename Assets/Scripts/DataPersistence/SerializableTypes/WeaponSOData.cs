using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponSOData
{
    public WeaponAttackDetails[] attackDetails;

    public WeaponSOData()
    {
        attackDetails[0].damageAmount = 10;
        attackDetails[0].knockbackStrength = 10;
        attackDetails[0].knockbackAngle = new Vector2(1, 2);

        attackDetails[1].damageAmount = 15;
        attackDetails[1].knockbackStrength = 15;
        attackDetails[1].knockbackAngle = new Vector2(1, 1);

        attackDetails[0].damageAmount = 20;
        attackDetails[0].knockbackStrength = 20;
        attackDetails[0].knockbackAngle = new Vector2(2, 2);
    }
}
