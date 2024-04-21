using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BW_MeleeAttackState : MeleeAttackState
{
    private BoarWarrior bWarrior;

    public BW_MeleeAttackState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, Transform attackPos, D_MeleeAttack stateData, BoarWarrior bWarrior) : base(stateMachine, entity, animBoolName, attackPos, stateData)
    {
        this.bWarrior = bWarrior;
    }

    public override void Enter()
    {
        base.Enter();

        entity.atsm.bwMeleeAttackState = this;
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
                stateMachine.ChangeState(bWarrior.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(bWarrior.lookForPlayerState);
            }
        }
    }

    public void RockAttackStart()
    {
        bWarrior.EnableRocks();
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
