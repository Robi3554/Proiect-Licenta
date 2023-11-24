using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : MoveState
{
    protected Skeleton skele;

    public E1_MoveState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_MoveState stateData, Skeleton skele) : base(stateMachine, entity, animBoolName, stateData)
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

        if (isPlayerInMinAggroRange)
        {
            stateMachine.ChangeState(skele.playerDetectedState);
        }
        else if(isDetectingWall || !isDetectingLedge)
        {
            skele.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(skele.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
