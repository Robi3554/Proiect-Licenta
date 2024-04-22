using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private AggresiveWeaponData weaponData;
    [SerializeField]
    private float size;
    [SerializeField]
    private LayerMask whatIsEnemy;

    private Player player;

    private int counter;
    private float damage;

    public Vector2 knockbackAngle = Vector2.zero;
    public float knockbackStrength = 0f;

    void Start()
    {
        player = FindObjectOfType<Player>();

        for (int i = 0; i < 3; i++)
        {
            damage += weaponData.AttackDetails[counter].damageAmount;
            counter++;
        }
    }

    public void ExplosionDamage()
    {
        Collider2D[] detectedObj = Physics2D.OverlapCircleAll(transform.position, size, whatIsEnemy);

        foreach (Collider2D col in detectedObj)
        {
            IDamageable damageable = col.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(damage);
            }

            IKnockbackable knockbackable = col.GetComponent<IKnockbackable>();

            if (knockbackable != null)
            {
                knockbackable.Knockback(knockbackAngle, knockbackStrength, player.GetDirection());
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, size);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
