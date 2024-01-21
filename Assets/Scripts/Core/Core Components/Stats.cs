using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponent
{
    public event Action OnHealthZero;

    [SerializeField]
    internal float maxHealth;

    protected float currentHealth;

    [SerializeField]
    internal bool canBurn;
    internal bool onFire;

    [Header("OnFire")]
    [SerializeField]
    private float duration;
    [SerializeField]
    private float timeBetweenBurn;
    [SerializeField]
    private float burnDamage;

    private SpriteRenderer sr;

    protected override void Awake()
    {
        base.Awake();

        currentHealth = maxHealth;
        sr = GetComponentInParent<SpriteRenderer>();
    }

    public virtual void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            currentHealth = 0;

            OnHealthZero?.Invoke();
        }
    }

    public virtual void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    public virtual void CacthFire()
    {
        if (canBurn && !onFire)
        {
            onFire = true;

            Color onFireColor = HexToColor("FC8702");

            sr.color = onFireColor;

            if (onFire)
            {
                StartCoroutine(OnFire());
            }
        }
    }

    Color HexToColor(string hex)
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString("#" + hex, out color);
        return color;
    }

    public IEnumerator OnFire()
    {
        for (int i = 1; i <= duration; i++)
        {
            yield return new WaitForSeconds(timeBetweenBurn);

            DecreaseHealth(burnDamage);
        }

        Color regularColor = HexToColor("FFFFFF");

        sr.color = regularColor;

        onFire = false;
    }

    public virtual void OnDestroy()
    {
        StopCoroutine(OnFire());
    }
}
