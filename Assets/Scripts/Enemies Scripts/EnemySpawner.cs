using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    private string id;

    [ContextMenu("Generate id")]
    private void GenerateId()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private BoxCollider2D bc;

    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    private List<GameObject> spawnedEnemies;

    private bool enemyDestroyed = false;

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
        
        GameObject enemy = Instantiate(enemies[randomIndex], transform.position, Quaternion.identity);

        Entity entity = enemy.GetComponent<Entity>();

        if (!gameObject.name.Contains("(NoCollider)") && entity != null)
        {
            bc.enabled = false;
            entity.es = this;
            spawnedEnemies.Add(enemy);
            Debug.Log($"Spawned object added: {enemy.name}, InstanceID: {enemy.GetInstanceID()}");
        }

    }

    public void EnemyDestroyed(GameObject destroyedEnemy)
    {
        Debug.Log("EnemyIsSomewhere");
        if(spawnedEnemies.Contains(destroyedEnemy))
        {
            spawnedEnemies.Remove(destroyedEnemy);
            enemyDestroyed = true;
            Debug.Log($"Spawned object destroyed and removed from the list: {destroyedEnemy.name}, InstanceID: {destroyedEnemy.GetInstanceID()}");
        }
        else
        {
            Debug.Log($"Failed to find the destroyed object in the list: {destroyedEnemy.name}, InstanceID: {destroyedEnemy.GetInstanceID()}");
        }
    }

    public void LoadData(GameData data)
    {
        data.enemiesDefeated.TryGetValue(id, out enemyDestroyed);
        if(enemyDestroyed)
        {
            gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.enemiesDefeated.ContainsKey(id))
        {
            data.enemiesDefeated.Remove(id);
        }

        data.enemiesDefeated.Add(id, enemyDestroyed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SpawnRandomEnemy();
            //gameObject.SetActive(false);
        }
    }

    private IEnumerator StartCollider()
    {
        yield return new WaitForSeconds(1f);

        bc.enabled = true;
    }
}
