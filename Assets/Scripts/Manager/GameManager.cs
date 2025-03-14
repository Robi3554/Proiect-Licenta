using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    private Transform respawnPoint;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float respawnTime;

    [Header("Timer&Points")]
    [SerializeField]
    internal float elapsedTime;
    [SerializeField]
    internal int points;

    private float respawnTimeStart;

    private bool respawn;

    private CinemachineVirtualCamera cvc;

    internal Scene activeScene;

    [Header("DropChances")]
    [SerializeField]
    internal float minChance;
    [SerializeField]
    internal float maxChance;

    public bool noMoreEnemies;
    public bool extraPowerup = true;

    public List<GameObject> spawners = new List<GameObject>();

    public List<GameObject> enemies = new List<GameObject>();

    public int count;

    [Header("Modifiers")]
    public Auxiliary aux;
    public bool isDoubleSpeed;
    public bool is1Health;

    private void Awake()
    {
        cvc = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();

        points = 1000;

        spawners = FindSpawners();

        StartCoroutine(CheckForEnemies());
        StartCoroutine(CheckPowerUps());
    }

    private void Start()
    {
        count = spawners.Count;

        aux = FindObjectOfType<Auxiliary>();

        SetGame2XSpeed();

        SetGame1HP();
    }

    private void Update()
    {
        CheckRespawn();

        activeScene = SceneManager.GetActiveScene();

        if(activeScene.name != "EndScene")
            elapsedTime += Time.deltaTime;
    }

    public void Respawn()
    {
        respawnTimeStart = Time.time;

        respawn = true;
    }

    private void CheckRespawn()
    {
        if(Time.time >= respawnTimeStart + respawnTime && respawn)
        {
            var playerTemp = Instantiate(player, respawnPoint);
            cvc.m_Follow = playerTemp.transform;
            respawn = false;
        }
    }

    private List<GameObject> FindSpawners()
    {
        List<GameObject> foundSpawners = new List<GameObject>();

        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach(GameObject obj in allObjects)
        {
            if(obj.name.Contains("Spawner") && !obj.name.Contains("(NoCollider)") && !obj.name.Contains("PowerUp"))
            {
                foundSpawners.Add(obj);
            }
        }

        return foundSpawners;
    }

    private void IncreaseChance()
    {
        maxChance += 1.5f;

        if(maxChance > 101)
        {
            maxChance = 101;
            minChance += 1.5f;
        }
    }

    private void IncreasePoints(int value)
    {
        points += value;
    }

    public void SetGame2XSpeed()
    {
        if (aux.isFastForward)
        {
            Time.timeScale = 2f;
            Time.fixedDeltaTime = 0.01f;
            isDoubleSpeed = true;
        }
    }

    public void SetGame1HP()
    {
        if (aux.is1Health)
        {
            is1Health = true;
        }
    }

    private IEnumerator CheckForEnemies()
    {
        while (true)
        {
            Death[] death = FindObjectsOfType<Death>();

            foreach (Death de in death)
            {
                if (!de.isSubscribed)
                {
                    de.IncreaseChance += IncreaseChance;
                    de.PointIncrease += IncreasePoints;
                    de.isSubscribed = true;
                }
            }

            yield return null;
        }
    }

    private IEnumerator CheckPowerUps()
    {
        while (true)
        {
            PowerUp[] powerUps = FindObjectsOfType<PowerUp>();

            foreach (PowerUp pu in powerUps)
            {
                if (!pu.isSubscribed)
                {
                    pu.PowerUpIncrease += IncreasePoints;
                    pu.isSubscribed = true;
                }
            }

            yield return null;
        }
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
            count--;
            if (count == 0)
                noMoreEnemies = true;
        }
    }

    public void LoadData(GameData data)
    {
        points = data.points;
        elapsedTime = data.time;
    }

    public void SaveData(GameData data)
    {
        data.points = points;
        data.time = elapsedTime;
    }
}
