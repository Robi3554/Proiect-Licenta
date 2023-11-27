using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exec_Idle_State : IdleState
{
    private Executioner exec;

    public Exec_Idle_State(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_IdleState stateData, Executioner exec) : base(stateMachine, entity, animBoolName, stateData)
    {
        this.exec = exec;
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
