using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executioner : Entity
{
    public Exec_Idle_State idleState { get; private set; }
    public Exec_Spawn_State spawnState { get; private set; }

    public Exec_Attack_State attackState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_SpawnState spawnStateData;
    [SerializeField]
    private D_MeleeAttack attackStateData;

    [SerializeField]
    private Transform attackPos;

    public override void Awake()
    {
        base.Awake();

        idleState = new Exec_Idle_State(stateMachine, this, "idle", idleStateData, this);
        spawnState = new Exec_Spawn_State(stateMachine, this, "spawn", spawnStateData, this);
        attackState = new Exec_Attack_State(stateMachine, this, "attack", attackPos, attackStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }

    public override void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPos.position, attackStateData.attackRadius);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        anim.SetInteger("atkCount", attackState.count);
    }
}
