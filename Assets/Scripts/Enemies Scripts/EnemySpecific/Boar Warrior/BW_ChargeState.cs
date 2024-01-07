using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BW_ChargeState : ChargeState
{
    private BoarWarrior bWarrior;

    public BW_ChargeState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_ChargeState stateData, BoarWarrior bWarrior) : base(stateMachine, entity, animBoolName, stateData)
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
            stateMachine.ChangeState(bWarrior.meleeAttackState);
        }
        else if ((!isDetectingLedge && !isDetectingLedgeP) || isDetectingWall)
        {
            stateMachine.ChangeState(bWarrior.lookForPlayerState);
        }
        else if (isChargeTimeOver)
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

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
