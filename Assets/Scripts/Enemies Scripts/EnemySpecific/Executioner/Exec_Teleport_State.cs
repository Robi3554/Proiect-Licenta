using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exec_Teleport_State : TeleportState
{
    private Executioner exec;

    protected bool isTeleportFinished;

    public Exec_Teleport_State(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_TeleportState stateData, Executioner exec) : base(stateMachine, entity, animBoolName, stateData)
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

        entity.atsm.teleportState = this;
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

        if (isTeleportFinished)
        {
            stateMachine.ChangeState(exec.idleState);
        }
    }

    public void ToTeleport()
    {
        exec.transform.position = exec.GetComponent<Executioner>().TeleportPosition().position;

        isTeleportFinished = true;
    }
}
