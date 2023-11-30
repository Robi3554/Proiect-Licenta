using UnityEditor;
using UnityEngine;

public class Exec_Spawn_State : SpawnState
{
    private Executioner exec;

    public Exec_Spawn_State(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_SpawnState stateData, Executioner exec) : base(stateMachine, entity, animBoolName, stateData)
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

        spawner = exec.GetComponent<Spawner>();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        

        if (count >= stateData.numberToSpawn)
        {
            stateMachine.ChangeState(exec.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void ToSpawn()
    {
        base.ToSpawn();
    }
}
