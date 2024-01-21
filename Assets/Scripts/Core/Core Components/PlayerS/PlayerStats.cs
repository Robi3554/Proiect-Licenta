using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : Stats
{
    [Header("Health Bar")]
    [SerializeField]
    private HealthBar healtBar;

    [SerializeField]
    private TextMeshProUGUI text;

    protected override void Awake()
    {
        base.Awake();
    }

    protected void FixedUpdate()
    {
        healtBar.SetMaxHealth(maxHealth);

        healtBar.SetHealth(currentHealth);

        text.text = $"{currentHealth}/{maxHealth}";
    }

    public override void DecreaseHealth(float amount)
    {
        base.DecreaseHealth(amount);
    }

    public override void IncreaseHealth(float amount)
    {
        base.IncreaseHealth(amount);
    }

    public override void CacthFire()
    {
        base.CacthFire();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}
