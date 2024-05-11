using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    private GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    public void SpawnRandomEnemy()
    {
         int randomIndex = Random.Range(0, enemies.Count);
        
         Instantiate(enemies[randomIndex], transform.position, Quaternion.identity);

        if (gameObject.CompareTag("Spawner"))
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SpawnRandomEnemy();
            gameObject.SetActive(false);
        }
    }
}
