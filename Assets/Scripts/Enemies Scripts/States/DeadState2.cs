using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState2 : State
{
    protected D_DeadState2 stateData;

    public DeadState2(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_DeadState2 stateData) : base(stateMachine, entity, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        GameObject.Instantiate(stateData.deathBloodParticles, entity.transform.position, stateData.deathChunkParticles.transform.rotation);
        GameObject.Instantiate(stateData.deathChunkParticles, entity.transform.position, stateData.deathChunkParticles.transform.rotation);

        entity.gameObject.SetActive(false);
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
    }
}
