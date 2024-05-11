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

    void Awake()
    {
        WaveSpawn();
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

        count++;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (!col.name.StartsWith("Combat"))
            {
                enemies.Add(col.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (!col.name.StartsWith("Combat"))
            {
                enemies.Remove(col.gameObject);
            }
        }
    }
}
