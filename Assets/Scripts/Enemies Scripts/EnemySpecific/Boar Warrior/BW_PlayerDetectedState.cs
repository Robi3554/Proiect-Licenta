using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BW_PlayerDetectedState : PlayerDetectedState
{
    private BoarWarrior bWarrior;

    public BW_PlayerDetectedState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_PlayerDetected stateData, BoarWarrior bWarrior) : base(stateMachine, entity, animBoolName, stateData)
    {
        this.bWarrior = bWarrior;
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
            //stateMachine.ChangeState(bWarrior.meleeAttackState);
        }
        else if (performLongRangeAction)
        {
            //stateMachine.ChangeState(bWarrior.chargeState);
        }
        else if (!isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(bWarrior.lookForPlayerState);
        }
        else if (!isDetectingLedge && !isDetectingLedgeP)
        {
            Movement?.Flip();
            stateMachine.ChangeState(bWarrior.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
