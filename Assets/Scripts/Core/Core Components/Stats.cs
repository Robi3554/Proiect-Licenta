using System;
using System.Collections;
using UnityEngine;

public class Stats : CoreComponent
{
    private Coroutine burnCoroutine;
    private Coroutine slowCoroutine;

    public event Action OnHealthZero;

    [SerializeField]
    private D_Entity enemyData;
    [SerializeField]
    private D_MoveState moveData;

    [SerializeField]
    internal float maxHealth;

    protected float curentHealth;

    [SerializeField]
    internal bool 
        canBurn,
        canBeSlowed;

    internal bool 
        onFire,
        isSlowed;

    internal SpriteRenderer sr;

    internal GameManager gameManager;

    protected override void Awake()
    {
        base.Awake();

        curentHealth = maxHealth;
        sr = GetComponentInParent<SpriteRenderer>();

        gameManager = FindObjectOfType<GameManager>();
    }

    public virtual void Update()
    {
        if (gameManager.is1Health)
        {
            maxHealth = 1f;
            curentHealth = 1f;
        }
    }

    public virtual void DecreaseHealth(float amount)
    {
        curentHealth -= amount;

        if(curentHealth <= 0)
        {
            curentHealth = 0;

            OnHealthZero?.Invoke();
        }
    }

    public virtual void IncreaseHealth(float amount)
    {
        curentHealth = Mathf.Clamp(curentHealth + amount, 0, maxHealth);
    }

    public virtual void LightOnFire(float fireDuration, float timeBetweenBurn, float burnDamage)
    {
        if (canBurn && !onFire)
        {
            onFire = true;

            Color onFireColor = HexToColor("FC8702");

            sr.color = onFireColor;

            if (onFire)
            {
                burnCoroutine = StartCoroutine(OnFireCo(fireDuration, timeBetweenBurn, burnDamage));
            }
        }
    }

    public virtual void Slowing(float slowDuration, float slowAmmount)
    {
        if(canBeSlowed && !isSlowed && !onFire)
        {
            isSlowed = true;

            Color isSlowedColor = HexToColor("75B7F1");

            sr.color = isSlowedColor;

            Debug.Log("Get Slowed!");

            if (isSlowed)
            {
                slowCoroutine = StartCoroutine(SlowingCo(slowDuration, slowAmmount));
            }
        }
    }

    Color HexToColor(string hex)
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString("#" + hex, out color);
        return color;
    }

    public IEnumerator OnFireCo(float fireDuration, float timeBetweenBurn, float burnDamage)
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

    public virtual IEnumerator SlowingCo(float slowDuration, float slowAmmount)
    {
        float moveSpeed = moveData.movementSpeed;

        float animSpeed = enemyData.animSpeed;

        moveData.movementSpeed = moveSpeed / slowAmmount;

        enemyData.animSpeed = animSpeed /slowAmmount;

        yield return new WaitForSeconds(slowDuration);

        Color regularColor = HexToColor("FFFFFF");

        sr.color = regularColor;

        moveData.movementSpeed = moveSpeed;

        enemyData.animSpeed = animSpeed;

        isSlowed = false;
    }

    public virtual void OnDestroy()
    {
        if (burnCoroutine != null)
        {
            StopCoroutine(burnCoroutine);
        }
        
        if(slowCoroutine != null)
        {
            StopCoroutine(slowCoroutine);
        }
    }
}
