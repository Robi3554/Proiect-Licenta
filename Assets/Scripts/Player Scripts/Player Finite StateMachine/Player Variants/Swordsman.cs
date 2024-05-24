using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman : Player
{
    public bool canShoot = false;

    public override void SaveData(GameData data)
    {
        data.canLightOnFire = canLightOnFire;
        data.canSlow = canSlow;
        data.canCauseExplosion = canCauseExplosions;
        data.canStealLife = canStealLife;
        data.canNegateHits = canNegateHits;
        data.canShoot = canShoot;

        base.SaveData(data);
    }

    public override void LoadData(GameData data) 
    {
        canLightOnFire = data.canLightOnFire;
        canSlow = data.canSlow;
        canCauseExplosions = data.canCauseExplosion;
        canStealLife = data.canStealLife;
        canNegateHits = data.canNegateHits;
        canShoot = data.canShoot;

        base.LoadData(data); 
    }
}
