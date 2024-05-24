using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PlayerDetectedState : PlayerDetectedState
{
    private Skeleton skele;

    private SkeleCombat combat;

    public E1_PlayerDetectedState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_PlayerDetected stateData, Skeleton skele) : base(stateMachine, entity, animBoolName, stateData)
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

        combat = skele.GetComponentInChildren<SkeleCombat>();
        combat.shieldUp = true;
    }

    public override void Exit()
    {
        base.Exit();
        combat.shieldUp = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (performCloseRangeAction && isShieldUpOver)
        {
            stateMachine.ChangeState(skele.meleeAttackState);
        }
        else if (performLongRangeAction && isShieldUpOver)
        {
            stateMachine.ChangeState(skele.chargeState);
        }
        else if (!isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(skele.lookForPlayerState);
        }
        else if (!isDetectingLedge && !isDetectingLedgeP)
        {
            Movement?.Flip();
            stateMachine.ChangeState(skele.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
