using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FinalSpawnPowerUp : SpawnPowerUps
{
    private int count = 0;

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            int randInt;

            int[] alreadyChosen = new int[positions.Length];

            for (int i = 0; i < positions.Length; i++)
            {
                float chance = Random.Range(manager.minChance, manager.maxChance);
                Debug.Log(chance);
                if(manager.noMoreEnemies && count < 2)
                {
                    do
                    {
                        randInt = Random.Range(0, legendaryList.powerUps.Length);
                    } while (alreadyChosen.Contains(randInt));

                    alreadyChosen[i] = randInt;

                    count++;
                    Debug.Log("Legendary");
                    SpawnLegendaryPowerUp(randInt, i);
                }
                else if (chance <= 40)
                {
                    do
                    {
                        randInt = Random.Range(0, commonList.powerUps.Length);
                    } while (alreadyChosen.Contains(randInt));

                    alreadyChosen[i] = randInt;

                    Debug.Log("Common");
                    SpawnCommonPowerUp(randInt, i);
                }
                else if (chance <= 80)
                {
                    do
                    {
                        randInt = Random.Range(0, rareList.powerUps.Length);
                    } while (alreadyChosen.Contains(randInt));

                    alreadyChosen[i] = randInt;

                    Debug.Log("Rare");
                    SpawnRarePowerUp(randInt, i);
                }
                else if (chance <= 100)
                {
                    do
                    {
                        randInt = Random.Range(0, legendaryList.powerUps.Length);
                    } while (alreadyChosen.Contains(randInt));

                    alreadyChosen[i] = randInt;

                    Debug.Log("Legendary");
                    SpawnLegendaryPowerUp(randInt, i);
                }
            }

            bc.enabled = false;
        }
    }
}
