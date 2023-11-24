using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_StunState : StunState
{
    private Skeleton skele;

    public E1_StunState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_StunState stateData, Skeleton skele) : base(stateMachine, entity, animBoolName, stateData)
    {
        this.skele = skele;
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
            if (performCloseRangeAction)
            {
                stateMachine.ChangeState(skele.meleeAttackState);
            }
            else if (isPlayerInMinAgrroRange)
            {
                stateMachine.ChangeState(skele.chargeState);
            }
            else
            {
                skele.lookForPlayerState.SetTurnImmediately(true);
                stateMachine.ChangeState(skele.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
