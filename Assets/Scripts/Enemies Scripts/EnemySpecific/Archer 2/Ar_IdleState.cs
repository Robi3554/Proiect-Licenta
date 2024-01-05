using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;

public class Ar_IdleState : IdleState
{
    private Archer2 arch;

    public Ar_IdleState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_IdleState stateData, Archer2 arch) : base(stateMachine, entity, animBoolName, stateData)
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
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(arch.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
