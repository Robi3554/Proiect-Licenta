using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPowerUps : AllSpawner, IDataPersistence
{
    protected GameManager manager;

    protected BoxCollider2D bc;

    public GameObject[] positions;

    public PowerUpList commonList;
    public PowerUpList rareList;
    public PowerUpList legendaryList;

    [Header("For SaveData")]
    [SerializeField]
    private List<GameObject> spawnedPowerups = new List<GameObject>();
    private bool isTaken;

    void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        bc = GetComponent<BoxCollider2D>();
    }

    protected virtual void SpawnPowerUp(int index, int n, PowerUpList  list)
    {
        if (index >= 0 && index <= legendaryList.powerUps.Length)
        {
            GameObject prefab = list.powerUps[index];
            GameObject powerup = Instantiate(prefab, positions[n].transform.position, Quaternion.identity);
            PowerUp power = powerup.GetComponent<PowerUp>();

            if (power != null)
            {
                power.sp = this;
                spawnedPowerups.Add(powerup);
                Debug.Log($"Spawned object added: {powerup.name}, InstanceID: {powerup.GetInstanceID()}");
            }
        }
    }

    public virtual void PowerUpTaken(GameObject takenPower)
    {
        if (spawnedPowerups.Contains(takenPower))
        {
            spawnedPowerups.Remove(takenPower);
            isTaken = true;
            Debug.Log($"Spawned object destroyed and removed from the list: {takenPower.name}, InstanceID: {takenPower.GetInstanceID()}");
        }
        
        else
        {
            Debug.Log($"Failed to find the destroyed object in the list: {takenPower.name}, InstanceID: {takenPower.GetInstanceID()}");
        }
    }

    public void LoadData(GameData data)
    {
        data.powerupsTaken.TryGetValue(id, out isTaken);
        if(isTaken)
        {
            gameObject.SetActive(false);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.powerupsTaken.ContainsKey(id))
        {
            data.powerupsTaken.Remove(id);
        }

        data.powerupsTaken.Add(id, isTaken);
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
                    SpawnPowerUp(randInt, i, commonList);
                }
                else if (chance <= 80)
                {
                    do
                    {
                        randInt = Random.Range(0, rareList.powerUps.Length);
                    } while (alreadyChosen.Contains(randInt));

                    alreadyChosen[i] = randInt;

                    Debug.Log("Rare");
                    SpawnPowerUp(randInt, i, rareList);
                }
                else if (chance <= 100)
                {
                    do
                    {
                        randInt = Random.Range(0, legendaryList.powerUps.Length);
                    } while (alreadyChosen.Contains(randInt));

                    alreadyChosen[i] = randInt;

                    Debug.Log("Legendary");
                    SpawnPowerUp(randInt, i, legendaryList);
                }
            }

            bc.enabled = false;
        }
    }
}
