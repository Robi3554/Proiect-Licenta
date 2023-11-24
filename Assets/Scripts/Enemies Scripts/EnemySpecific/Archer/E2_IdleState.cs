using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_IdleState : IdleState
{
    private Archer archer;

    public E2_IdleState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_IdleState stateData, Archer archer) : base(stateMachine, entity, animBoolName, stateData)
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

        if (isPlayerInMinAggroRange)
        {
            stateMachine.ChangeState(archer.playerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(archer.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
