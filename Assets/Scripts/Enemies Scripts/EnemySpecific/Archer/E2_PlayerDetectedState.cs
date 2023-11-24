using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_PlayerDetectedState : PlayerDetectedState
{
    private Archer archer;

    public E2_PlayerDetectedState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_PlayerDetected stateData, Archer archer) : base(stateMachine, entity, animBoolName, stateData)
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (performCloseRangeAction)
        {
            if (Time.time >= archer.dodgeState.startTime + archer.dodgeStateData.dodgeCooldown)
            {
                stateMachine.ChangeState(archer.dodgeState);
            }
            else
            {
                stateMachine.ChangeState(archer.meleeAttackState);
            }
        }
        else if (performLongRangeAction)
        {
            stateMachine.ChangeState(archer.rangedAttackState);
        }
        else if (!isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(archer.lookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
