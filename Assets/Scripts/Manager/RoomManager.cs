using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private DoorManager doorManager;

    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    private int count = 0;

    public List<EnemySpawner> spawners = new List<EnemySpawner>();

    public int nrOfWaves;

    public float timeBetweenWaves;
    public float waitForDoors;

    public bool canSpawn = true;

    void Awake()
    {
        doorManager = FindObjectOfType<DoorManager>();
    }

    void Start()
    {
        StartCoroutine(CloseDoors());

        StartCoroutine(StartWave());
    }

    void FixedUpdate()
    {

    }

    private void WaveSpawn()
    {
        foreach (EnemySpawner spawn in spawners)
        {
            spawn.SpawnRandomEnemy();
        }

        canSpawn = false;
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
        if(count >= nrOfWaves)
        {
            StartCoroutine(OpenDoors());
        }
        else if(canSpawn)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            WaveSpawn();
            count++;
        }
    }

    private IEnumerator CloseDoors()
    {
        yield return new WaitForSeconds(waitForDoors);

        doorManager.EnableTileMapRenderer();
        doorManager.DisableTriggerCollider();
    }

    private IEnumerator OpenDoors()
    {
        yield return new WaitForSeconds(waitForDoors);

        doorManager.DisableTileMapRenderer();
        doorManager.EnableTriggerCollider();
    }
}
