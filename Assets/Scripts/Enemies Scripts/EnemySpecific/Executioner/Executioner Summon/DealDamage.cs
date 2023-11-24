using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class DealDamage : MonoBehaviour
{
    private ExecSpawn spawn;

    [SerializeField]
    private GameObject deathParticles;
    [SerializeField]
    private Vector2 angle;
    [SerializeField]
    private float 
        damageAmount,
        strength,
        damageRadius;
    [SerializeField]
    private LayerMask whatIsPlayer;
    [SerializeField]
    private Transform damagePos;

    private void Awake()
    {
        spawn = GetComponent<ExecSpawn>();
    }

    private void FixedUpdate()
    {
        DamageAndExplode();
    }

    private void DamageAndExplode()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(damagePos.position, damageRadius, whatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(damageAmount);
                Instantiate(deathParticles, transform.position, deathParticles.transform.rotation);
                Destroy(gameObject);
            }

            IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

            if (knockbackable != null)
            {
                knockbackable.Knockback(angle, strength, spawn.facingDir);
            }
        }     
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePos.position, damageRadius);
    }
}
