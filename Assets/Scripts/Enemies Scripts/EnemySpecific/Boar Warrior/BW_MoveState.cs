using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BW_MoveState : MoveState
{
    private BoarWarrior bWarrior;

    public BW_MoveState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_MoveState stateData, BoarWarrior bWarrior) : base(stateMachine, entity, animBoolName, stateData)
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

        if (isPlayerInMinAggroRange)
        {
            //stateMachine.ChangeState(bWarrior.playerDetectedState);
        }
        else if (isDetectingWall || (!isDetectingLedge && !isDetectingLedgeP))
        {
            bWarrior.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(bWarrior.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
