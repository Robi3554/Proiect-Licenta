using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_ChargeState : ChargeState
{
    private Skeleton skele;
    public E1_ChargeState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_ChargeState stateData, Skeleton skele) : base(stateMachine, entity, animBoolName, stateData)
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(skele.meleeAttackState);
        }
        else if ((!isDetectingLedge && !isDetectingLedgeP) || isDetectingWall)
        {
            stateMachine.ChangeState(skele.lookForPlayerState);
        }
        else if (isChargeTimeOver)
        {
            if(isPlayerInMinAggroRange)
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
}
