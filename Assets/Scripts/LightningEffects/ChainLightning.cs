using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : MonoBehaviour
{
    [SerializeField]
    private GameObject 
        lightningEffect,
        beenStruck;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private float damageAmmount;
    [SerializeField]
    private int ammountOfChains;

    private CircleCollider2D col;

    private Animator anim;

    private List<IDamageable> detectedDamageables = new List<IDamageable>();

    private GameObject startObject;

    public GameObject endObject;

    public ParticleSystem particle;

    private int singleSpawns; 

    void Start()
    {
        if(ammountOfChains == 0)
            Destroy(gameObject);

        col = GetComponent<CircleCollider2D>();

        anim = GetComponent<Animator>();

        particle = GetComponent<ParticleSystem>();

        startObject = gameObject;

        singleSpawns = 1;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        IDamageable damageable = col.GetComponent<IDamageable>();

        if(mask == (mask | (1 << col.gameObject.layer)) && col.GetComponentInChildren<EnemyStruck>())
        {
            if (damageable != null)
            {

                if (singleSpawns != 0)
                {
                    endObject = col.gameObject;

                    ammountOfChains--;

                    Instantiate(lightningEffect, col.gameObject.transform.position, Quaternion.identity);

                    Instantiate(beenStruck, col.gameObject.transform);

                    damageable.Damage(damageAmmount);

                    anim.StopPlayback();

                    col.enabled = false;

                    singleSpawns--;

                    particle.Play();

                    var emitParams = new ParticleSystem.EmitParams();

                    emitParams.position = startObject.transform.position;

                    particle.Emit(emitParams, 1);

                    emitParams.position = endObject.transform.position;

                    particle.Emit(emitParams, 1);

                    Destroy(endObject, 1f);
                }
            }
        }
    }
}
