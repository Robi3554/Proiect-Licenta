using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarWarrior : Entity
{
    public BW_IdleState idleState { get; private set; }
    public BW_MoveState moveState { get; private set; }


    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;

    public override void Awake()
    {
        base.Awake();

        idleState = new BW_IdleState(stateMachine, this, "idle", idleStateData, this);
        moveState = new BW_MoveState(stateMachine, this, "move", moveStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
