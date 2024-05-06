using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private GameManager manager;

    private int seconds;
    private int minutes;
    private int hours;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();

        StartCoroutine(CheckSeconds());
    }

    void Update()
    {
        seconds = Mathf.FloorToInt(manager.elapsedTime % 60);
        minutes = Mathf.FloorToInt(manager.elapsedTime / 60);
        if(minutes >= 60)
        {
            manager.elapsedTime = 0;
            hours++;
        }
        timeText.text = string.Format("{0:00}:{1:00}:{2:00}",hours, minutes, seconds);
    }

    public void ChangePoints()
    {
        manager.points--;
    }

    private IEnumerator CheckSeconds()
    {
        int previousSeconds = seconds;

        while (true)
        {
            yield return new WaitForSeconds(1f);

            if(seconds != previousSeconds)
            {
                previousSeconds = seconds;
                ChangePoints();
            }
        }
    }
}
