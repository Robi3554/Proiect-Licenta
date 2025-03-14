using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;

    public float maxHealth;
    public float curentHealth;

    public float[] damage = new float[3];
    public float[] knockbackStrength = new float[3];
    public Vector2[] knockbackAngle = new Vector2[3];

    public bool canLightOnFire;
    public bool canSlow;
    public bool canCauseExplosion;
    public bool canStealLife;
    public bool canNegateHits;
    public bool canShoot;

    public float time;
    public int points;

    public string currentSceneName;

    public SerializableDictionary<string, LevelData> levelData;

    public SerializableDictionary<string, bool> enemiesDefeated;

    public SerializableDictionary<string, bool> powerupsTaken;

    public PlayerSOData soData;

    public GameData()
    {
        levelData = new SerializableDictionary<string, LevelData>
        {
            { "StartScene", new LevelData() },
            { "Level1", new LevelData() },
            { "Level2", new LevelData() },
            { "EndScene", new LevelData() }
        };

        maxHealth = 150f;
        curentHealth = 150f;

        canLightOnFire = false;
        canSlow = false;
        canCauseExplosion = false;
        canStealLife = false;
        canNegateHits = false;
        canShoot = false;

        damage[0] = 10;
        damage[1] = 15;
        damage[2] = 20;

        knockbackStrength[0] = 10;
        knockbackStrength[1] = 15;
        knockbackStrength[2] = 20;

        knockbackAngle[0] = new Vector2(1, 2);
        knockbackAngle[1] = new Vector2(1, 1);
        knockbackAngle[2] = new Vector2(2, 2);

        points = 1000;
        time = 0f;

        currentSceneName = "Level1";

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
