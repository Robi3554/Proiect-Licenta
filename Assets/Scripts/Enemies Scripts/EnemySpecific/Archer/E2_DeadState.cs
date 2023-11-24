using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_DeadState : DeadState2
{
    private Archer archer;

    public E2_DeadState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_DeadState2 stateData, Archer archer) : base(stateMachine, entity, animBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
