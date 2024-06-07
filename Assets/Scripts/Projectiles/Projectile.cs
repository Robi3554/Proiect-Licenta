using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;
    private float travelDistance;
    private float damage;
    private float xStartPos;

    private bool isGravityOn;
    private bool hasHitGround;
    private bool hasHitPlatform;

    private Rigidbody2D rb;

    [SerializeField]
    private float gravity;
    [SerializeField]
    private float damageRadius;

    [SerializeField]
    private LayerMask
        whatIsGround,
        whatIsPlatform,
        whatIsPlayer;
    [SerializeField]
    private Transform damagePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0.0f;
        rb.velocity = transform.right * speed;

        xStartPos = transform.position.x;

        isGravityOn = false;
    }

    private void Update()
    {
        if (!hasHitGround || !hasHitPlatform)
        {

            if (isGravityOn)
            {
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!hasHitGround || !hasHitPlatform)
        {
            Collider2D[] damageHit = Physics2D.OverlapCircleAll(damagePos.position, damageRadius, whatIsPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(damagePos.position, damageRadius, whatIsGround);
            Collider2D platformHit = Physics2D.OverlapCircle(damagePos.position, damageRadius, whatIsPlatform);

            if (groundHit || platformHit)
            {
                hasHitGround = true;
                hasHitPlatform = true;
                rb.gravityScale = 0.0f;
                rb.velocity = Vector2.zero;
                Destroy(gameObject, 5);
            }
            else if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance && !isGravityOn)
            {
                isGravityOn = true;

                rb.gravityScale = gravity;
            }
            else
            {
                foreach(Collider2D collider in damageHit)
                {
                    IDamageable damageable = collider.GetComponent<IDamageable>();

                    if (damageable != null)
                    {
                        damageable.Damage(damage);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePos.position, damageRadius);
    }

    public void FireProjectile(float speed, float travelDistance, float damage)
    {
        this.speed = speed;
        this.travelDistance = travelDistance;
        this.damage = damage;
    }
}
