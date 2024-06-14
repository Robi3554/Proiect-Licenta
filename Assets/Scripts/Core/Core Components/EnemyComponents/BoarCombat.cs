using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarCombat : CombatNoKnockback
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void Damage(float amount)
    {
        base.Damage(amount);

        AudioManager.Instance.OneShotSound(FMODEvents.Instance.boarHit, transform.position);
    }
}
