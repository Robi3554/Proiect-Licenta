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

    public SerializableDictionary<string, bool> enemiesDefeated;

    public GameData()
    {
        maxHealth = 150f;
        curentHealth = 150f;

        playerPos = new Vector3(-227.58f, 9.16f, 0f);

        enemiesDefeated = new SerializableDictionary<string, bool>();
    }

    public int GetPercentageComplete()
    {
        int totalDefeated = 0;

        foreach(bool defeated in enemiesDefeated.Values)
        {
            if(defeated)
                totalDefeated++;
        }

        int percentageComplete = -1;
        if(enemiesDefeated.Count != 0)
        {
            percentageComplete = (totalDefeated * 100 / enemiesDefeated.Count);
        }

        return percentageComplete;
    }
}
