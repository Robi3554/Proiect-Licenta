using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;

public class BW_LookForPlayerState : LookForPlayerState
{
    private BoarWarrior bWarrior;

    public BW_LookForPlayerState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_LookForPlayerState stateData, BoarWarrior bWarrior) : base(stateMachine, entity, animBoolName, stateData)
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
            stateMachine.ChangeState(bWarrior.playerDetectedState);
        }
        else if (isAllTurnsTimeDone)
        {
            stateMachine.ChangeState(bWarrior.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
