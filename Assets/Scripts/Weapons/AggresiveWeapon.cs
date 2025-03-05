using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Linq;

public class AggresiveWeapon : Weapon, IDataPersistence
{
    protected AggresiveWeaponData agrresiveWeaponData;
    protected Movement Movement => movement ? movement : core.GetCoreComponent<Movement>();
    protected Combat Comabt  => combat ? combat : core.GetCoreComponent<Combat>();
    
    private Movement movement;
    private Combat combat;

    private List<IDamageable> detectedDamageables = new List<IDamageable>();

    private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable>();

    private int count;

    [SerializeField]
    private int toCount;

    protected override void Awake()
    {
        base.Awake();

        if (weaponData.GetType() == typeof(AggresiveWeaponData))
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
        if (PlayerStatsManager.Instance.attackSpeed != 0)
        {
            anim.speed = PlayerStatsManager.Instance.attackSpeed;
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

            if (player.canCauseExplosions)
            {
                count++;

                if (count >= toCount)
                {
                    debuff.Explode();
                    count = 0;
                }
            }

            if (player.canLightOnFire)
            {
                debuff.StartsBurning(PlayerStatsManager.Instance.fireDuration, PlayerStatsManager.Instance.timeBetweenBurn, PlayerStatsManager.Instance.burnDamage);
            }
            else if (player.canSlow)
            {
                debuff.StartSlowness(PlayerStatsManager.Instance.slowDuration, PlayerStatsManager.Instance.slowAmount);
            }
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        AddToDetected(col);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        RemoveFromDetected(col);
    }

    public void LoadData(GameData data)
    {
        
    }

    public void SaveData(GameData data)
    {
        
    }
}
