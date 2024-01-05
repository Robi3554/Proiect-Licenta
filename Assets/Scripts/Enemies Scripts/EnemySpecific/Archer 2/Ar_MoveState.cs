using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ar_MoveState : MoveState
{
    private Archer2 arch;

    public Ar_MoveState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_MoveState stateData, Archer2 arch) : base(stateMachine, entity, animBoolName, stateData)
    {
        this.arch = arch;
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

        if (isPlayerInMinAggroRange || isPlayerInMaxAggroRange)
        {
            //stateMachine.ChangeState(arch.playerDetectedState);
        }
        else if (isDetectingWall || (!isDetectingLedge && !isDetectingLedgeP))
        {
            arch.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(arch.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
