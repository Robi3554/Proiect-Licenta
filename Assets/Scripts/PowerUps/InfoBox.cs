using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoBox : MonoBehaviour
{
    private PowerUp powerUp;

    private TMP_Text infoText;
    private void Awake()
    {
        powerUp = GetComponentInParent<PowerUp>();

        infoText = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        infoText.text = powerUp.powerUpDescription;
    }
}
