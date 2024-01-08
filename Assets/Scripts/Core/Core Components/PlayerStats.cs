using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    [SerializeField]
    private HealthBar healtBar;

    protected override void Awake()
    {
        base.Awake();

        healtBar.SetMaxHealth(maxHealth);
    }

    public override void DecreaseHealth(float amount)
    {
        base.DecreaseHealth(amount);

        healtBar.SetHealth(currentHealth);
    }

    public override void IncreaseHealth(float amount)
    {
        base.IncreaseHealth(amount);

        healtBar.SetHealth(currentHealth);
    }
}
