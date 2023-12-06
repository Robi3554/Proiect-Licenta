using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Exec_Attack_State : MeleeAttackState
{
    private Executioner exec;

    public int count;

    public Exec_Attack_State(FiniteStateMachine stateMachine, Entity entity, string animBoolName, Transform attackPos, D_MeleeAttack stateData, Executioner exec) : base(stateMachine, entity, animBoolName, attackPos, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
        if(count >= 2)
        {
            isAnimationFinnished = true;
            count = 0;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAnimationFinnished)
        {
            stateMachine.ChangeState(exec.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        count++;
    }
}
