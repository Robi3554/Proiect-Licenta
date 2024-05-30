using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    private GameManager gameManager;

    private Transform player;

    private BoxCollider2D playerBc;

    public Loot lootSO;

    public float speed;

    private bool isFollowing = false;


    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        gameManager = FindObjectOfType<GameManager>();

        playerBc = player.GetComponent<BoxCollider2D>();

        StartCoroutine(StartFollowing());
    }

    private void Update()
    {
        if(isFollowing)
            transform.position = Vector3.Lerp(transform.position, player.position, speed);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ParticleContainer") && isFollowing)
        {
            lootSO.TouchPlayer(playerBc.gameObject);
            IncreasePoints(lootSO.points);
            Destroy(gameObject);
        }
    }

    private void IncreasePoints(int points)
    {
        gameManager.points += points;
    }

    private IEnumerator StartFollowing()
    {
        yield return new WaitForSeconds(1f);

        isFollowing = true;
    }
}
