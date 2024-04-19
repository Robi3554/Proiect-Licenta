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

    [SerializeField]
    private PlayerData playerData;

    protected override void Awake()
    {
        base.Awake();

        maxHealth = playerData.maxHealth;
        currentHealth = playerData.currentHealth;
    }

    protected void FixedUpdate()
    {
        healtBar.SetMaxHealth(maxHealth);

        healtBar.SetHealth(currentHealth);

        text.text = $"{currentHealth}/{maxHealth}";

        playerData.maxHealth = maxHealth;
        playerData.currentHealth = currentHealth;

        if(currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public override void DecreaseHealth(float amount)
    {
        base.DecreaseHealth(amount);
    }

    public override void IncreaseHealth(float amount)
    {
        base.IncreaseHealth(amount);
    }

    public override void LightOnFire(float fireDuration, float timeBetweenBurn, float burnDamage)
    {
        base.LightOnFire(fireDuration, timeBetweenBurn, burnDamage);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}
