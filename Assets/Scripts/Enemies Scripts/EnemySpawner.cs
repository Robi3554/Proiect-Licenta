using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    private GameObject player;

    private BoxCollider2D bc;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();

        player = GameObject.Find("Player");
    }

    private void SpawnRandomEnemy()
    {
        if(enemies.Count > 0)
        {
            int randomIndex = Random.Range(0, enemies.Count);

            Instantiate(enemies[randomIndex], transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("There are no enemies in the list!");
        }
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
