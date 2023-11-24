using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_MeleeAttackState : MeleeAttackState
{
    private Archer archer;

    public E2_MeleeAttackState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, Transform attackPos, D_MeleeAttack stateData, Archer archer) : base(stateMachine, entity, animBoolName, attackPos, stateData)
    {
        this.archer = archer;
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
                stateMachine.ChangeState(archer.playerDetectedState);
            }
            else if (!isPlayerInMinAggroRange)
            {
                stateMachine.ChangeState(archer.lookForPlayerState);
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
