using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Vector2 originPoint;

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField] 
    private GameObject spawner;

    private int spawnRadius = 4;

    private void Start()
    {
        originPoint = spawner.transform.position;
    }

    public void Spawn()
    {
        Vector2 point = Point(spawnRadius, originPoint);

        Instantiate(enemyPrefab, point, Quaternion.identity);
    }

    public Vector2 Point(int spawnradius, Vector2 origin)
    {
        Vector2 point = (Random.insideUnitCircle * spawnradius) + originPoint;

        return point;
    }
}
