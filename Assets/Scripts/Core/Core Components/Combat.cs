using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable
{
    [SerializeField]
    private GameObject damageParticles;

    private Movement Movement => movement ? movement : core.GetCoreComponent<Movement>();
    private CollisionSenses CollisionSenses => collisionSenses ? collisionSenses : core.GetCoreComponent<CollisionSenses>(); 
    private Stats Stats => stats ? stats : core.GetCoreComponent<Stats>();
    private ParticleManager ParticleManager => particleManager ? particleManager : core.GetCoreComponent<ParticleManager>();
    private Movement movement;
    private CollisionSenses collisionSenses;
    private Stats stats;
    private ParticleManager particleManager;

    [SerializeField]
    private float maxKncockbackTime = 0.5f;

    private bool isKnockbackActive;

    private float knockbackStartTime;

    public override void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(float amount)
    {
        Debug.Log(core.transform.parent.name + " damaged!");
        Stats?.DecreaseHealth(amount);

        ParticleManager?.StartParticlesWithRandomRotation(damageParticles);
    }

    public void Knockback(Vector2 angle, float strength, int direction)
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
}
