using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;

    public float maxHealth;
    public float curentHealth;

    public Vector3 playerPos;

    public bool canLightOnFire;
    public bool canSlow;
    public bool canCauseExplosion;
    public bool canStealLife;
    public bool canNegateHits;
    public bool canShoot;

    public SerializableDictionary<string, bool> enemiesDefeated;

    public SerializableDictionary<string, bool> powerupsTaken;

    public PlayerSOData soData;

    public GameData()
    {
        maxHealth = 150f;
        curentHealth = 150f;

        canLightOnFire = false;
        canSlow = false;
        canCauseExplosion = false;
        canStealLife = false;
        canNegateHits = false;
        canShoot = false;

        playerPos = new Vector3(-227.58f, 9.16f, 0f);

        enemiesDefeated = new SerializableDictionary<string, bool>();

        powerupsTaken = new SerializableDictionary<string, bool>();

        soData = new PlayerSOData();
    }

    public int GetPercentageComplete()
    {
        int totalDefeated = 0;
        int totalTaken = 0;

        foreach(bool defeated in enemiesDefeated.Values)
        {
            if(defeated)
                totalDefeated++;
        }
        foreach(bool taken in powerupsTaken.Values)
        {
            if(taken)
                totalTaken++;
        }

        int percentageComplete = -1;
        if(enemiesDefeated.Count != 0)
        {
            percentageComplete = ((totalDefeated + 1) + totalTaken) * 100 / (enemiesDefeated.Count + powerupsTaken.Count);
        }

        return percentageComplete;
    }
}
