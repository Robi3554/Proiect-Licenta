using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjectile : MonoBehaviour
{
    private float damage;
    private float xStartPos;

    private Rigidbody2D rb;

    [SerializeField]
    private AggresiveWeaponData data;
    [SerializeField]
    private Counting countData;

    [SerializeField]
    private float
        damageRadius,
        speed,
        travelDistance,
        travelTime;

    [SerializeField]
    private LayerMask
        whatIsGround,
        whatIsEnemy;

    [SerializeField]
    private Transform damagePos;

    private HashSet<IDamageable> damagedEnemies = new HashSet<IDamageable>();
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.velocity = transform.right * speed;

        xStartPos = transform.position.x;

        DamageCalc();
    }

    private void FixedUpdate()
    {
        Collider2D groundHit = Physics2D.OverlapCircle(damagePos.position, damageRadius, whatIsGround);

        if (groundHit)
        {
            Destroy(gameObject);
        }
        else if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance)
        {
            Debug.Log("Travel Over!");
            Destroy(gameObject);
        }
    }

    private void Damage()
    {
        damagedEnemies.Clear();

        Collider2D[] damageHit = Physics2D.OverlapCircleAll(damagePos.position, damageRadius, whatIsEnemy);
       
        foreach (Collider2D collider in damageHit)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if (damageable != null && !damagedEnemies.Contains(damageable))
            {
                damageable.Damage(damage);
                damagedEnemies.Add(damageable);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePos.position, damageRadius);
    }

    private void DamageCalc()
    {
        damage = Mathf.Round(data.AttackDetails[data.count].damageAmount / 2);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        IDamageable damageable = col.GetComponent<IDamageable>();

        if (damageable != null && !damagedEnemies.Contains(damageable))
        {
            Damage();
            damagedEnemies.Add(damageable);
        }
    }
}
