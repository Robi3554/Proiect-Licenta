using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executioner : Entity
{
    public Exec_Idle_State idleState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;

    public override void Awake()
    {
        base.Awake();

        idleState = new Exec_Idle_State(stateMachine, this, "idle", idleStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }
}
