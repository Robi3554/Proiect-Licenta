using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeaponData : MonoBehaviour, IDataPersistence
{
    public AggresiveWeaponData wData;

    public void LoadData(GameData data)
    {
        wData.AttackDetails[0].damageAmount = data.damage[0];
        wData.AttackDetails[1].damageAmount = data.damage[1];
        wData.AttackDetails[2].damageAmount = data.damage[2];

        wData.AttackDetails[0].knockbackStrength = data.knockbackStrength[0];
        wData.AttackDetails[1].knockbackStrength = data.knockbackStrength[1];
        wData.AttackDetails[2].knockbackStrength = data.knockbackStrength[2];

        wData.AttackDetails[0].knockbackAngle = data.knockbackAngle[0];
        wData.AttackDetails[1].knockbackAngle = data.knockbackAngle[1];
        wData.AttackDetails[2].knockbackAngle = data.knockbackAngle[0];
    }

    public void SaveData(GameData data)
    {
        data.damage[0] = wData.AttackDetails[0].damageAmount;
        data.damage[1] = wData.AttackDetails[1].damageAmount;
        data.damage[2] = wData.AttackDetails[2].damageAmount;

        data.knockbackStrength[0] = wData.AttackDetails[0].knockbackStrength;
        data.knockbackStrength[1] = wData.AttackDetails[1].knockbackStrength;
        data.knockbackStrength[2] = wData.AttackDetails[2].knockbackStrength;

        data.knockbackAngle[0] = wData.AttackDetails[0].knockbackAngle;
        data.knockbackAngle[1] = wData.AttackDetails[1].knockbackAngle;
        data.knockbackAngle[2] = wData.AttackDetails[2].knockbackAngle;
    }
}
