using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPowerupCheck : MonoBehaviour
{
    private GameManager gameManager;

    private BoxCollider2D bc;

    public int limit;

    public bool useSeconds;

    private void Start()
    {

        gameManager = FindObjectOfType<GameManager>();

        bc = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && gameManager.elapsedTime <= limit)
        {
            gameManager.extraPowerup = true;

            bc.enabled = false;
        }
    }
}
