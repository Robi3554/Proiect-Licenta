using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatNoKnockback : CoreComponent, IDamageable
{
    [SerializeField]
    private GameObject damageParticles;

    private Stats Stats => stats ? stats : core.GetCoreComponent<Stats>();
    private ParticleManager ParticleManager => particleManager ? particleManager : core.GetCoreComponent<ParticleManager>();

    private Stats stats;
    private ParticleManager particleManager;

    public override void LogicUpdate()
    {
        
    }

    public void Damage(float amount)
    {
        Debug.Log(core.transform.parent.name + " damaged!");
        Stats?.DecreaseHealth(amount);

        ParticleManager?.StartParticlesWithRandomRotation(damageParticles);
    }
}
