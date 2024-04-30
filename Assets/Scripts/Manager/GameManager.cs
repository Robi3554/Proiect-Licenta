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

    private float respawnTimeStart;

    private bool respawn;

    private CinemachineVirtualCamera cvc;

    internal int minChance;
    internal int maxChance;

    private void Start()
    {
        cvc = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();

        StartCoroutine(CheckForEnemies());
    }

    private void Update()
    {
        CheckRespawn();
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
        Debug.Log("Chance Increased");
        maxChance += 2;

        if(maxChance > 100)
        {
            maxChance = 100;
            minChance += 2;
        }
    }

    private IEnumerator CheckForEnemies()
    {
        while (true)
        {
            Death[] death = FindObjectsOfType<Death>();

            foreach (Death de in death)
            {
                if (!de.IsSubscribed)
                {
                    de.IncreaseChance += IncreaseChance;
                    de.IsSubscribed = true;
                }
            }

            yield return null;
        }
    }
}
