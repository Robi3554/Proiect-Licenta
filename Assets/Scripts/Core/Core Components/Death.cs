using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField]
    private GameObject[] deathParticles;

    private ParticleManager ParticleManager => particleManager ? particleManager : core.GetCoreComponent<ParticleManager>();
    private Stats Stats => stats ? stats : core.GetCoreComponent<Stats>();

    private ParticleManager particleManager;
    private Stats stats;


    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            ParticleManager.StartParticles(particle);
        }

        if(transform.parent.gameObject.CompareTag("Enemy"))
        {
            GetComponentInParent<LootBag>().InstantiateLoot(transform.position);
        }

        core.transform.parent.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Stats.OnHealthZero += Die;
    }

    private void OnDisable()
    {
        Stats.OnHealthZero -= Die;
    }
}
