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
    private PlayerStats PlayerStats => pStats ? pStats : core.GetCoreComponent<PlayerStats>();

    protected Movement movement;
    protected CollisionSenses collisionSenses;
    protected Stats stats;
    protected ParticleManager particleManager;
    private PlayerStats pStats;

    [SerializeField]
    protected float maxKncockbackTime = 0.5f;

    protected bool isKnockbackActive;

    protected float knockbackStartTime;

    protected bool hitByWave = false;

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

    private void CheckKnockback()
    {
        if(isKnockbackActive && ((Movement?.currentVelocity.y <= 0.01f && CollisionSenses.Ground) || Time.time >= knockbackStartTime + maxKncockbackTime))
        {
            isKnockbackActive = false;
            Movement.canSetVelocity = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!hitByWave)
        {
            if (col.CompareTag("SwordWave"))
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col, true);
                hitByWave = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("SwordWave"))
        {
            hitByWave = false;
        }
    }
}
