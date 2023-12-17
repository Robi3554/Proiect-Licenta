using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Executioner : Entity
{
    public Exec_Idle_State idleState { get; private set; }
    public Exec_Spawn_State spawnState { get; private set; }
    public Exec_Attack_State attackState { get; private set; }
    public Exec_Teleport_State teleportState { get; private set;}

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_SpawnState spawnStateData;
    [SerializeField]
    private D_MeleeAttack attackStateData;
    [SerializeField]
    private D_TeleportState teleportStateData;

    [SerializeField]
    private Transform attackPos;

    private Vector2 size = new Vector2(20f, 20f);

    protected bool playerDetect;
    protected bool isPlayerInMaxAggroRange;

    public override void Awake()
    {
        base.Awake();

        idleState = new Exec_Idle_State(stateMachine, this, "idle", idleStateData, this);
        spawnState = new Exec_Spawn_State(stateMachine, this, "spawn", spawnStateData, this);
        attackState = new Exec_Attack_State(stateMachine, this, "attack", attackPos, attackStateData, this);
        teleportState = new Exec_Teleport_State(stateMachine, this, "teleport", teleportStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(attackPos.position, attackStateData.attackRadius);

        Gizmos.DrawWireSphere(transform.position, entityData.minAggroRange);
        Gizmos.DrawWireSphere(transform.position, entityData.maxAggroRange);
        Gizmos.DrawWireSphere(transform.position, entityData.closeRangeActionDistance);

        Gizmos.DrawWireCube(playerCheck.position, new Vector2(20f, 20f));
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        playerDetect = CheckPlayer();
        isPlayerInMaxAggroRange = CheckPlayerInMaxAggroRange();

        if(isPlayerInMaxAggroRange && !playerDetect)
        {
            Movement?.Flip();
        }

        anim.SetInteger("atkCount", attackState.count);
    }

    public override bool CheckPlayerInMinAggroRange()
    {
        return Physics2D.CircleCast(transform.position, entityData.minAggroRange, transform.right, entityData.minAggroRange,entityData.whatIsPlayer);
    }

    public override bool CheckPlayerInMaxAggroRange()
    {
        return Physics2D.CircleCast(transform.position, entityData.maxAggroRange, transform.right, entityData.maxAggroRange,entityData.whatIsPlayer);
    }

    public override bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.CircleCast(transform.position, entityData.closeRangeActionDistance, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }

    public bool CheckPlayer()
    {
        return Physics2D.BoxCast(playerCheck.position, size, 0f, transform.right, 8f, entityData.whatIsPlayer);
    }

}
