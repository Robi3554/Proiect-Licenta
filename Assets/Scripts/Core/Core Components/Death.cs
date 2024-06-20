using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField]
    private GameObject[] deathParticles;

    [SerializeField]
    private D_Entity data;

    private ParticleManager ParticleManager => particleManager ? particleManager : core.GetCoreComponent<ParticleManager>();
    private Stats Stats => stats ? stats : core.GetCoreComponent<Stats>();

    private ParticleManager particleManager;
    private Stats stats;

    public event Action IncreaseChance;

    public event Action deathScreen;

    public delegate void IncreaseMaxHealth(float amount);
    public event IncreaseMaxHealth IncreaseHealth;

    public delegate void IncreasePoints(int ammount);
    public event IncreasePoints PointIncrease;

    public bool isSubscribed = false;
    public bool subscribedToHealth = false;

    public void Die()
    {
        if(transform.parent.gameObject.CompareTag("Enemy"))
        {
            foreach (var particle in deathParticles)
            {
                ParticleManager.StartParticles(particle);
            }

            //GetComponentInParent<LootBag>().InstantiateLoot(transform.position);

            IncreaseChance?.Invoke();

            IncreaseHealth?.Invoke(1f);

            PointIncrease?.Invoke(data.pointsToIncrease);

            Entity enemy = GetComponentInParent<Entity>();

            if(enemy.es != null)
            {
                Transform current = transform;

                while(current.parent != null)
                {
                    current = current.parent;
                }

                enemy.es.EnemyDestroyed(current.gameObject);
            }
        }

        if (gameObject.CompareTag("Player"))
        {
            deathScreen.Invoke();

            AudioManager.Instance.OneShotSound(FMODEvents.Instance.deathSound, transform.position);
            AudioManager.Instance.CleanUp();
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
