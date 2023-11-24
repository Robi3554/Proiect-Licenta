using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Vector2 originPoint;

    [SerializeField]
    private float spawnrate = 3f;

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField] 
    private GameObject spawner;

    [SerializeField]
    private bool canSpawn = true;

    private int spawnRadius = 4;

    private void Start()
    {
        originPoint = spawner.transform.position;

        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnrate);

        while (canSpawn)
        {
            yield return wait;
            Spawn();
        }
    }

    private void Spawn()
    {
        int facingDir = Random.Range(-1, 1);
        Vector2 point = (Random.insideUnitCircle * spawnRadius) + originPoint;

        Instantiate(enemyPrefab, point, Quaternion.identity);
    }
}
