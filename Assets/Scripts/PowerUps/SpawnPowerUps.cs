using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    protected GameManager manager;

    protected BoxCollider2D bc;

    public GameObject[] positions;

    public PowerUpList commonList;
    public PowerUpList rareList;
    public PowerUpList legendaryList;

    void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        bc = GetComponent<BoxCollider2D>();
    }

    protected virtual void SpawnCommonPowerUp(int index, int n)
    {
        if (index >= 0 && index < commonList.powerUps.Length)
        {
            GameObject prefab = commonList.powerUps[index];
            Instantiate(prefab, positions[n].transform.position, Quaternion.identity);
        }
    }

    protected virtual void SpawnRarePowerUp(int index, int n)
    {
        if (index >= 0 && index < rareList.powerUps.Length)
        {
            GameObject prefab = rareList.powerUps[index];
            Instantiate(prefab, positions[n].transform.position, Quaternion.identity);
        }
    }

    protected virtual void SpawnLegendaryPowerUp(int index, int n)
    {
        if (index >= 0 && index < legendaryList.powerUps.Length)
        {
            GameObject prefab = legendaryList.powerUps[index];
            Instantiate(prefab, positions[n].transform.position, Quaternion.identity);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            int randInt;

            int[] alreadyChosen = new int[positions.Length];

            for (int i = 0; i < positions.Length; i++)
            {
                float chance = Random.Range(manager.minChance, manager.maxChance);
                Debug.Log(chance);
                if (chance <= 40)
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
