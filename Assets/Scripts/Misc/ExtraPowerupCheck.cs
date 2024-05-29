using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPowerupCheck : MonoBehaviour
{
    private Timer timer;

    private GameManager gameManager;

    private BoxCollider2D bc;

    public int mLimit;
    public int sLimit;

    public bool useSeconds;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();

        gameManager = FindObjectOfType<GameManager>();

        bc = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && ((useSeconds && timer.seconds <= sLimit) || timer.minutes <= mLimit))
        {
            gameManager.extraPowerup = true;

            bc.enabled = false;
        }
    }
}
