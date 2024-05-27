using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPowerupCheck : MonoBehaviour
{
    private Timer timer;

    private GameManager gameManager;

    private BoxCollider2D bc;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();

        gameManager = FindObjectOfType<GameManager>();

        bc = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && timer.seconds <= 35)
        {
            gameManager.extraPowerup = true;

            bc.enabled = false;
        }
    }
}
