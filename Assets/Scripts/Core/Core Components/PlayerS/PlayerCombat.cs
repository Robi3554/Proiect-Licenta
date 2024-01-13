using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public override void Damage(float amount)
    {
        base.Damage(amount);

        StartCoroutine(FramesCo());
    }

    public override void Knockback(Vector2 angle, float strength, int direction)
    {
        base.Knockback(angle, strength, direction);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    protected override void Awake()
    {
        base.Awake();

        sr = GetComponentInParent<SpriteRenderer>();
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
}
