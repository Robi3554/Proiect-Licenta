using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PlayerDetectedState : PlayerDetectedState
{
    private Skeleton skele;

    public E1_PlayerDetectedState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_PlayerDetected stateData, Skeleton skele) : base(stateMachine, entity, animBoolName, stateData)
    {
        this.skele = skele;
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
        else if (performLongRangeAction)
        {
            stateMachine.ChangeState(skele.chargeState);
        }
        else if (!isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(skele.lookForPlayerState);
        }
        else if (!isDetectingLEdge)
        {
            Movement?.Flip();
            stateMachine.ChangeState(skele.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
