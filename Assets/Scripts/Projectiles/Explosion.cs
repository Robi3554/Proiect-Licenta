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
    }

    void Update()
    {
        if (player.GetDirection() == 1)
        {
            Debug.Log("Right");
        }
        else
            Debug.Log("Left");
    }

    public void Attack()
    {
        Collider2D[] detectedObj = Physics2D.OverlapCircleAll(transform.position, size, whatIsEnemy);

        for (int i = 0; i < 3; i++)
        {
            damage += weaponData.AttackDetails[counter].damageAmount;
            counter++;
        }

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

            counter = 0;
            damage = 0;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
