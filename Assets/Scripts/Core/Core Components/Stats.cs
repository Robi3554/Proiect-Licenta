using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponent
{
    public event Action OnHealthZero;

    [SerializeField]
    private D_MoveState data;

    [SerializeField]
    internal float maxHealth;

    protected float currentHealth;

    [SerializeField]
    internal bool 
        canBurn,
        canBeSlowed;

    internal bool 
        onFire,
        isSlowed;

    [Header("OnFire")]
    [SerializeField]
    private float fireDuration;
    [SerializeField]
    private float timeBetweenBurn;
    [SerializeField]
    private float burnDamage;

    [Header("Slowed")]
    [SerializeField]
    private float slowDuration;

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

    public virtual void LightOnFire()
    {
        if (canBurn && !onFire)
        {
            onFire = true;

            Color onFireColor = HexToColor("FC8702");

            sr.color = onFireColor;

            if (onFire)
            {
                StartCoroutine(OnFireCo());
            }
        }
    }

    public virtual void Slowing()
    {
        if(canBeSlowed && !isSlowed && !onFire)
        {
            isSlowed = true;

            Color isSlowedColor = HexToColor("75B7F1");

            sr.color = isSlowedColor;

            if (isSlowed)
            {
                StartCoroutine(SlowingCo());
            }
        }
    }

    Color HexToColor(string hex)
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString("#" + hex, out color);
        return color;
    }

    public IEnumerator OnFireCo()
    {
        for (int i = 1; i <= fireDuration; i++)
        {
            yield return new WaitForSeconds(timeBetweenBurn);

            DecreaseHealth(burnDamage);
        }

        Color regularColor = HexToColor("FFFFFF");

        sr.color = regularColor;

        onFire = false;
    }

    public virtual IEnumerator SlowingCo()
    {
        float speed = data.movementSpeed;

        data.movementSpeed = speed / 2;

        yield return new WaitForSeconds(slowDuration);

        Color regularColor = HexToColor("FFFFFF");

        sr.color = regularColor;

        data.movementSpeed = speed;

        isSlowed = false;
    }

    public virtual void OnDestroy()
    {
        StopCoroutine(OnFireCo());
    }
}
