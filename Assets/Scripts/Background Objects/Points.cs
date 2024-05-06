using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    private GameManager manager;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        pointsText.text = manager.points.ToString();
    }
}
