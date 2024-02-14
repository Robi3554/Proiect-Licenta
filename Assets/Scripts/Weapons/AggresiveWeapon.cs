using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Linq;

public class AggresiveWeapon : Weapon
{
    protected Movement Movement => movement ? movement : core.GetCoreComponent<Movement>();
    protected Combat Comabt  => combat ? combat : core.GetCoreComponent<Combat>();
    
    private Movement movement;
    private Combat combat;

    [SerializeField]
    private PlayerData data;

    private List<IDamageable> detectedDamageables = new List<IDamageable>();

    private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable>();

    protected AggresiveWeaponData agrresiveWeaponData;

    protected override void Awake()
    {
        base.Awake();

        if(weaponData.GetType() == typeof(AggresiveWeaponData))
        {
            agrresiveWeaponData = (AggresiveWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("Wrong Data For The Weapon");
        }
    }

    private void FixedUpdate()
    {
        if (data != null)
        {
            anim.speed = data.attackSpeed;
        }
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = agrresiveWeaponData.AttackDetails[attackCounter];

        foreach(IDamageable item in detectedDamageables.ToList())
        {
            item.Damage(details.damageAmount);
        }

        foreach(IKnockbackable item in detectedKnockbackables.ToList())
        {
            item.Knockback(details.knockbackAngle, details.knockbackStrength, Movement.facingDir);
        }
    }

    public void AddToDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        Combat debuff = collision.GetComponent<Combat>();

        if (damageable != null)
        {
            detectedDamageables.Add(damageable);

            if (player.canLightOnFire)
            {
                debuff.StartsBurning(data.fireDuration, data.timeBetweenBurn, data.burnDamage);
            }
            else if (player.canSlow)
            {
                debuff.StartSlowness(data.slowDuration);
            }

            Instantiate(player.chainLightning, collision.transform.position, Quaternion.identity);
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if(knockbackable != null)
        {
            detectedKnockbackables.Add(knockbackable);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageables.Remove(damageable);
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if (knockbackable != null)
        {
            detectedKnockbackables.Remove(knockbackable);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddToDetected(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveFromDetected(collision);
    }
}
