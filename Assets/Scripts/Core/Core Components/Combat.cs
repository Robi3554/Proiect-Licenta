using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable
{
    [SerializeField]
    protected GameObject damageParticles;

    protected Movement Movement => movement ? movement : core.GetCoreComponent<Movement>();
    protected CollisionSenses CollisionSenses => collisionSenses ? collisionSenses : core.GetCoreComponent<CollisionSenses>(); 
    protected Stats Stats => stats ? stats : core.GetCoreComponent<Stats>();
    protected ParticleManager ParticleManager => particleManager ? particleManager : core.GetCoreComponent<ParticleManager>();

    protected Movement movement;
    protected CollisionSenses collisionSenses;
    protected Stats stats;
    protected ParticleManager particleManager;

    [SerializeField]
    protected float maxKncockbackTime = 0.5f;

    protected float knockbackStartTime;

    protected bool isKnockbackActive;

    public override void LogicUpdate()
    {
        CheckKnockback();
    }

    public virtual void Damage(float amount)
    {
        Debug.Log(core.transform.parent.name + " damaged!");

        Stats?.DecreaseHealth(amount);

        ParticleManager?.StartParticlesWithRandomRotation(damageParticles);
    }

    public virtual void Knockback(Vector2 angle, float strength, int direction)
    {
        Movement?.SetVelocity(strength, angle, direction);

        Movement.canSetVelocity = false;

        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    public virtual void StartsBurning(float fireDuration, float timeBetweenBurn, float burnDamage)
    {
        if (Stats.canBurn)
        {
            Stats?.LightOnFire(fireDuration, timeBetweenBurn, burnDamage);
        }
    }

    public virtual void StartSlowness(float slowDuration)
    {
        if (Stats.canBeSlowed)
        {
            Stats?.Slowing(slowDuration);
        }
    }

    protected virtual void CheckKnockback()
    {
        if(isKnockbackActive && ((Movement?.currentVelocity.y <= 0.01f && CollisionSenses.Ground) || Time.time >= knockbackStartTime + maxKncockbackTime))
        {
            isKnockbackActive = false;
            Movement.canSetVelocity = true;
        }
    }
}
