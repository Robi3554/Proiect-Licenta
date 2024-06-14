using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeleCombat : Combat
{
    internal bool shieldUp = false;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Damage(float amount)
    {
        if(!shieldUp)
        {
            base.Damage(amount);
        }
        else
        {
            Debug.Log("No Damage!");
            AudioManager.Instance.OneShotSound(FMODEvents.Instance.shieldHit, transform.position);
        }
    }

    public override void Knockback(Vector2 angle, float strength, int direction)
    {
        if (!shieldUp)
        {
            base.Knockback(angle, strength, direction);
        }
        else
        {
            Debug.Log("No Knockback!");
        }
    }
}
