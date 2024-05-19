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

        StartCoroutine(CheckEnemies());
    }

    protected void FixedUpdate()
    {
        healtBar.SetMaxHealth(maxHealth);

        healtBar.SetHealth(currentHealth);

        text.text = $"{currentHealth}/{maxHealth}";

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

    public void IncreaseMaxHealth(float amount)
    {
        Player player = GetComponentInParent<Player>();

        if (player.canStealLife)
        {
            maxHealth += amount;
            currentHealth += amount;
        }
    }

    public override void LightOnFire(float fireDuration, float timeBetweenBurn, float burnDamage)
    {
        base.LightOnFire(fireDuration, timeBetweenBurn, burnDamage);
    }

    private IEnumerator CheckEnemies()
    {
        while (true)
        {
            Death[] death = FindObjectsOfType<Death>();

            foreach (Death de in death)
            {
                if (!de.subscribedToHealth)
                {
                    de.IncreaseHealth += IncreaseMaxHealth;
                    de.subscribedToHealth = true;
                }
            }

            yield return null;
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();

        StopCoroutine(CheckEnemies());
    }
}
