using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private BoxCollider2D bc;

    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    void Awake()
    {
        if (!gameObject.name.Contains("(NoCollider)"))
        {
            bc = GetComponent<BoxCollider2D>();

            bc.enabled = false;

            StartCoroutine(StartCollider());
        }
    }

    public void SpawnRandomEnemy()
    {
         int randomIndex = Random.Range(0, enemies.Count);
        
         Instantiate(enemies[randomIndex], transform.position, Quaternion.identity);

        if (gameObject.CompareTag("Spawner"))
        {
            Destroy(gameObject);
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

    private IEnumerator StartCollider()
    {
        yield return new WaitForSeconds(1f);

        bc.enabled = true;
    }
}
