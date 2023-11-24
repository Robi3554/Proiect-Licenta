using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_RangedAttackState : RangedAttackState
{
    private Archer archer;

    public E2_RangedAttackState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, Transform attackPos, D_RangedAttackStateData stateData, Archer archer) : base(stateMachine, entity, animBoolName, attackPos, stateData)
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
            else
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
