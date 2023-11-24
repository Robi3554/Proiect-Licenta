using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_StunState : StunState
{
    private Archer archer;

    public E2_StunState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_StunState stateData, Archer archer) : base(stateMachine, entity, animBoolName, stateData)
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

        if (isStunTimeOver)
        {
            if (isPlayerInMinAgrroRange)
            {
                stateMachine.ChangeState(archer.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(archer.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
