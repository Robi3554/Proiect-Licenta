using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : State
{
    private Movement Movement { get => movement??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    protected Transform attackPos;

    protected bool isAnimationFinnished;
    protected bool isPlayerInMinAggroRange;

    public AttackState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, Transform attackPos) : base(stateMachine, entity, animBoolName)
    {
        this.attackPos = attackPos;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
    }

    public override void Enter()
    {
        base.Enter();

        entity.atsm.attackState = this;
        isAnimationFinnished = false;
        Movement?.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Movement?.SetVelocityX(0f);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void TriggerAttack()
    {

    }

    public virtual void FinishAttack()
    {
        isAnimationFinnished = true;
    }
}
