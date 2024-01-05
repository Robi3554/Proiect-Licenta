using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Archer2 : Entity
{
    public Ar_IdleState idleState { get; private set; }
    public Ar_MoveState moveState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;

    public override void Awake()
    {
        base.Awake();

        idleState = new Ar_IdleState(stateMachine, this, "idle", idleStateData, this);
        moveState = new Ar_MoveState(stateMachine, this, "move", moveStateData, this);
        
    }

    private void Start()
    {
        stateMachine.Initialize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        //Gizmos.DrawWireSphere(meleeAttackPos.position, meleeAttackStateData.attackRadius);
    }
}
