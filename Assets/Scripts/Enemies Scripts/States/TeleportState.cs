using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportState : State
{
    protected D_TeleportState stateData;

    public TeleportState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_TeleportState stateData) : base(stateMachine, entity, animBoolName)
    {
        this.stateData = stateData;
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
