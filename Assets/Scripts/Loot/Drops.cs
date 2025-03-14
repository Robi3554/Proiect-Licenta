using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    [SerializeField]
    private Transform hitPos;

    private GameManager gameManager;

    private GameObject player;

    private BoxCollider2D playerBc;

    private LayerMask whatIsPlayer;

    public Loot lootSO;

    public float speed;

    public float radius;

    private bool isFollowing = false;


    void Start()
    {
        player = GameObject.FindWithTag("Player");

        gameManager = FindObjectOfType<GameManager>();

        playerBc = player.GetComponent<BoxCollider2D>();

        whatIsPlayer = LayerMask.GetMask("Player");

        StartCoroutine(StartFollowing());
    }

    private void FixedUpdate()
    {
        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, speed);

            Collider2D hit = Physics2D.OverlapCircle(hitPos.position, radius, whatIsPlayer);

            if (hit)
            {
                lootSO.TouchPlayer(playerBc.gameObject);
                IncreasePoints(lootSO.points);
                AudioManager.Instance.OneShotSound(FMODEvents.Instance.lootPickup, transform.position);
                Destroy(gameObject);
            }
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitPos.position, radius);
    }
}
