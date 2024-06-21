using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private GameManager manager;

    internal int seconds;
    internal int minutes;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();

        StartCoroutine(CheckSeconds());
    }

    void Update()
    {
        seconds = Mathf.FloorToInt(manager.elapsedTime % 60);
        minutes = Mathf.FloorToInt(manager.elapsedTime / 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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
            if(seconds != previousSeconds && manager.activeScene.name != "EndScene")
            {
                previousSeconds = seconds;
                ChangePoints();
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
