using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    public GameObject[] positions;

    public PowerUpList commonList;
    public PowerUpList rareList;
    public PowerUpList legendaryList;

    void Start()
    {
        int randInt;

        int[] alreadyChosen = new int[positions.Length];

        for (int i = 0; i < positions.Length; i++)
        {
            int chance = Random.Range(0, 100);

            if(chance <= 60)
            {
                do
                {
                    randInt = Random.Range(0, commonList.powerUps.Length);
                } while (alreadyChosen.Contains(randInt));

                alreadyChosen[i] = randInt;

                Debug.Log("Common");
                SpawnCommonPowerUp(randInt, i);

                randInt = 0;
            }
            else if(chance <= 85)
            {
                do
                {
                    randInt = Random.Range(0, rareList.powerUps.Length);
                } while (alreadyChosen.Contains(randInt));

                alreadyChosen[i] = randInt;

                Debug.Log("Rare");
                SpawnRarePowerUp(randInt, i);

                randInt = 0;
            }
            else if(chance <= 100)
            {
                do
                {
                    randInt = Random.Range(0, legendaryList.powerUps.Length);
                } while (alreadyChosen.Contains(randInt));

                alreadyChosen[i] = randInt;

                Debug.Log("Legendary");
                SpawnLegendaryPowerUp(randInt, i);

                randInt = 0;
            }
        }
    }

    private void SpawnCommonPowerUp(int index, int n)
    {
        if (index >= 0 && index < commonList.powerUps.Length)
        {
            GameObject prefab = commonList.powerUps[index];
            Instantiate(prefab, positions[n].transform.position, Quaternion.identity);
        }
    }

    private void SpawnRarePowerUp(int index, int n)
    {
        if (index >= 0 && index < rareList.powerUps.Length)
        {
            GameObject prefab = rareList.powerUps[index];
            Instantiate(prefab, positions[n].transform.position, Quaternion.identity);
        }
    }

    private void SpawnLegendaryPowerUp(int index, int n)
    {
        if (index >= 0 && index < legendaryList.powerUps.Length)
        {
            GameObject prefab = legendaryList.powerUps[index];
            Instantiate(prefab, positions[n].transform.position, Quaternion.identity);
        }
    }
}
