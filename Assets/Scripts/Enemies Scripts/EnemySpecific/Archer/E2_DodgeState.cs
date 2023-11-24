using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_DodgeState : DodgeState
{
    private Archer archer;

    public E2_DodgeState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_DodgeState stateData, Archer archer) : base(stateMachine, entity, animBoolName, stateData)
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

        if (isDodgeOver)
        {
            if(isPlayerInMaxAggroRange && performCloseRangeAction)
            {
                stateMachine.ChangeState(archer.meleeAttackState);
            }
            else if(isPlayerInMaxAggroRange && !performCloseRangeAction)
            {
                stateMachine.ChangeState(archer.rangedAttackState);
            }
            else if (!isPlayerInMaxAggroRange)
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
