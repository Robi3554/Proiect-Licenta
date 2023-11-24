using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Linq;

public class AggresiveWeapon : Weapon
{
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    
    private Movement movement;

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

        if(damageable != null)
        {
            detectedDamageables.Add(damageable);
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
