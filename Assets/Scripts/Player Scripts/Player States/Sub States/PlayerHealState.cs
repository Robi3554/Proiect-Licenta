using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealState : PlayerAbilityState
{
    private PlayerStats PlayerStats { get => playerStats ??= core.GetComponent<PlayerStats>(); }

    private PlayerStats playerStats;

    public PlayerHealState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("State Enter");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(playerData.healsLeft > 0)
        {
            PlayerStats?.IncreaseHealth(playerData.healAmmount);

            isAbilityDone = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
