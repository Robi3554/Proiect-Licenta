using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
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

    [Header("DropChances")]
    [SerializeField]
    internal int minChance;
    [SerializeField]
    internal int maxChance;



    private void Awake()
    {
        cvc = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();

        points = 1000;

        StartCoroutine(CheckForEnemies());
        StartCoroutine(CheckPowerUps());
    }

    private void Update()
    {
        CheckRespawn();
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

    private void IncreaseChance()
    {
        maxChance += 2;

        if(maxChance > 101)
        {
            maxChance = 101;
            minChance += 2;
        }
    }

    private void IncreasePoints(int value)
    {
        points += value;
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
}
