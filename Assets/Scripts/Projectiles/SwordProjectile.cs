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
        travelDistance;

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
        
    }

    private void Damage()
    {
        damagedEnemies.Clear();

        Collider2D[] damageHit = Physics2D.OverlapCircleAll(damagePos.position, damageRadius, whatIsEnemy);
        Collider2D groundHit = Physics2D.OverlapCircle(damagePos.position, damageRadius, whatIsGround);

        if (groundHit)
        {
            Destroy(gameObject);
        }
        else if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance)
        {
            Destroy(gameObject);
        }
        else
        {
            foreach (Collider2D collider in damageHit)
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();

                if (damageable != null && !damagedEnemies.Contains(damageable))
                {
                    damageable.Damage(damage);
                    damagedEnemies.Add(damageable);
                    //Destroy(gameObject);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePos.position, damageRadius);
    }

    private void DamageCalc()
    {
        damage = Mathf.Round(data.AttackDetails[countData.count].damageAmount / 2);
        countData.count++;

        if (countData.count >= data.AttackDetails.Length)
        {
            countData.count = 0;
        }

        Debug.Log(damage);
    }

    public void AddToDetected(Collider2D col)
    {
        IDamageable damageable = col.GetComponent<IDamageable>();

        
    }

    public void RemoveFromDetected(Collider2D col)
    {
        IDamageable damageable = col.GetComponent<IDamageable>();

       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        IDamageable damageable = col.GetComponent<IDamageable>();

        if (damageable != null && !damagedEnemies.Contains(damageable))
        {
            AddToDetected(col);
            Damage();
            damagedEnemies.Add(damageable);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        RemoveFromDetected(col);
    }
}
