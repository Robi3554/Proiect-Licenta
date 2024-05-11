using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    private int count = 0;

    public List<EnemySpawner> spawners = new List<EnemySpawner>();

    public int timeBetweenWaves;

    public bool canSpawn = true;

    void Awake()
    {
        StartCoroutine(StartWave());
    }

    void Update()
    {
        
    }

    private void WaveSpawn()
    {
        foreach (EnemySpawner spawn in spawners)
        {
            spawn.SpawnRandomEnemy();
        }

        canSpawn = false;
        count++;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && !col.name.StartsWith("Combat"))
        {
            enemies.Add(col.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && !col.name.StartsWith("Combat"))
        {
            enemies.Remove(col.gameObject);
            if (enemies.Count <= 0)
            {
                canSpawn = true;
                StartCoroutine(StartWave());
            }
                
        }
    }

    private IEnumerator StartWave()
    {
        if(count >= 3)
        {
            Destroy(gameObject);
        }
        else if(canSpawn)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            WaveSpawn();
        }
    }
}
