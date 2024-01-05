using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Archer : Entity
{
    public E2_MoveState moveState { get; private set; }
    public E2_IdleState idleState { get; private set; }
    public E2_PlayerDetectedState playerDetectedState { get; private set; }
    public E2_MeleeAttackState meleeAttackState { get; private set; }
    public E2_LookForPlayerState lookForPlayerState { get; private set; }
    public E2_StunState stunState { get; private set; }
    public E2_DeadState deadState { get; private set; }
    public E2_DodgeState dodgeState { get; private set;}

    public E2_RangedAttackState rangedAttackState { get; private set;}

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState2 deadStateData;
    [SerializeField]
    public D_DodgeState dodgeStateData;
    [SerializeField]
    public D_RangedAttackStateData rangedAttackStateData;
   
    [SerializeField]
    private Transform meleeAttackPos;
    [SerializeField]
    private Transform rangedAttackPos;

    public override void Awake()
    {
        base.Awake();

        moveState = new E2_MoveState(stateMachine, this, "move", moveStateData, this);
        idleState = new E2_IdleState(stateMachine, this, "idle", idleStateData, this);  
        playerDetectedState = new E2_PlayerDetectedState(stateMachine, this, "playerDetected", playerDetectedData, this);
        meleeAttackState = new E2_MeleeAttackState(stateMachine, this, "meleeAttack", meleeAttackPos, meleeAttackStateData, this);
        lookForPlayerState = new E2_LookForPlayerState(stateMachine, this, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new E2_StunState(stateMachine, this, "stun", stunStateData, this);
        deadState = new E2_DeadState(stateMachine, this, "dead", deadStateData, this);
        dodgeState = new E2_DodgeState(stateMachine, this, "dodge", dodgeStateData, this);
        rangedAttackState = new E2_RangedAttackState(stateMachine, this, "rangedAttack", rangedAttackPos, rangedAttackStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPos.position, meleeAttackStateData.attackRadius);
    }
}
