using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : Stats, IDataPersistence
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

        healtBar.SetHealth(curentHealth);

        text.text = $"{curentHealth}/{maxHealth}";

        if(curentHealth > maxHealth)
            curentHealth = maxHealth;
    }

    public void LoadData(GameData data)
    {
        maxHealth = data.maxHealth;
        curentHealth = data.curentHealth;
    }

    public void SaveData(ref GameData data)
    {
        data.maxHealth = maxHealth;
        data.curentHealth = curentHealth;
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
            curentHealth += amount;
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
