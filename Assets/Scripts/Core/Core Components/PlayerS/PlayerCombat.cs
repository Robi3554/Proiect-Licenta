using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerCombat : Combat
{
    [Header("IFrames")]
    [SerializeField]
    private Color flashColor;
    [SerializeField]
    private Color regularColor;
    [SerializeField]
    private float flashDuration;
    [SerializeField]
    private int numberOfFlashes;
    [SerializeField]
    private Collider2D col;

    private SpriteRenderer sr;

    private Player pr;

    private int count;

    public float intensity;
    public float time;

    protected override void Awake()
    {
        base.Awake();

        sr = GetComponentInParent<SpriteRenderer>();

        pr = GetComponentInParent<Player>();
    }

    public override void Damage(float amount)
    {
        Debug.Log(core.transform.parent.name + " damaged!");

        if (pr.canNegateHits && count >= 2)
        {
            count = 0;

            StartCoroutine(FramesCo());
        }
        else
        {
            Stats?.DecreaseHealth(amount);

            if (pr.canNegateHits)
            {
                count++;
            }

            CameraShake.Instance.Shake(intensity, time);

            ParticleManager?.StartParticlesWithRandomRotation(damageParticles);

            StartCoroutine(FramesCo());
        }
    }

    public override void Knockback(Vector2 angle, float strength, int direction)
    {
        base.Knockback(angle, strength, direction);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    protected override void CheckKnockback()
    {
        base.CheckKnockback();
    }

    private IEnumerator FramesCo()
    {
        int temp = 0;
        col.enabled = false;
        while(temp < numberOfFlashes)
        {
            sr.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            sr.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        col.enabled = true;
    }

    private void OnDestroy()
    {
        StopCoroutine(FramesCo());
    }
}
