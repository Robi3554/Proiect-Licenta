using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Exec_Idle_State : IdleState
{
    private Executioner exec;

    private int spawnCount;

    protected bool performCloseRangeAction;

    public Exec_Idle_State(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_IdleState stateData, Executioner exec) : base(stateMachine, entity, animBoolName, stateData)
    {
        this.exec = exec;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
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

        if (performCloseRangeAction && isIdleTimeOver)
        {
            stateMachine.ChangeState(exec.attackState);
        }
        else if (isPlayerInMaxAggroRange && isIdleTimeOver && spawnCount < 2)
        {
            stateMachine.ChangeState(exec.spawnState);
            spawnCount++;
        }
        else if(isPlayerInMaxAggroRange && !performCloseRangeAction && isIdleTimeOver)
        {
            stateMachine.ChangeState(exec.teleportState);
            spawnCount = 0;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
