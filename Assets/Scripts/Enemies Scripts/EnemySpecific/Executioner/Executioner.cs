using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executioner : Entity
{
    public Exec_Idle_State idleState { get; private set; }
    public Exec_Spawn_State spawnState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_SpawnState spawnStateData;

    public override void Awake()
    {
        base.Awake();

        idleState = new Exec_Idle_State(stateMachine, this, "idle", idleStateData, this);
        spawnState = new Exec_Spawn_State(stateMachine, this, "spawn", spawnStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }
}
