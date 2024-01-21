using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    private Movement Movement => movement ? movement : core.GetCoreComponent<Movement>();

    private Movement movement;

    private 

    protected D_MeleeAttack stateData;

    public MeleeAttackState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, Transform attackPos, D_MeleeAttack stateData) : base(stateMachine, entity, animBoolName, attackPos)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPos.position, stateData.attackRadius, stateData.whatIsPlayer);

        foreach(Collider2D collider in detectedObjects)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();
            Combat burning = collider.GetComponent<Combat>();

            if(damageable != null)
            {
                damageable.Damage(stateData.attackDamage);

                if (stateData.canLightOnFire)
                {
                    burning.StartsBurning();
                }
            }

            IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>(); 

            if(knockbackable != null)
            {
                knockbackable.Knockback(stateData.knockbackAngle, stateData.knockbackStrength, Movement.facingDir);
            }
        }
    }
}
