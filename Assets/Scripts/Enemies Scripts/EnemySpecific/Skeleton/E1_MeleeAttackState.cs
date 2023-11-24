using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MeleeAttackState : MeleeAttackState
{
    private Skeleton skele;

    public E1_MeleeAttackState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, Transform attackPos, D_MeleeAttack stateData, Skeleton skele) : base(stateMachine, entity, animBoolName, attackPos, stateData)
    {
        this.skele = skele;
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

        if (isAnimationFinnished)
        {
            if (isPlayerInMinAggroRange)
            {
                stateMachine.ChangeState(skele.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(skele.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
