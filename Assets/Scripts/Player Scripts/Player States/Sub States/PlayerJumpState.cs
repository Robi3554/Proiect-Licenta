using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int ammountOfJumpsLeft;

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        ammountOfJumpsLeft = playerData.ammountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();

        player.inputHandler.UseJumpInput();
        Movement?.SetVelocityY(playerData.jumpVelocity);
        isAbilityDone = true;
        ammountOfJumpsLeft--;
        player.inAirState.SetIsJumping();
    }

    public bool CanJump()
    {
        if(ammountOfJumpsLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetAmmountOfJumpsLeft() => ammountOfJumpsLeft = playerData.ammountOfJumps;

    public void DecreaseAmmountOfJumpsLeft() => ammountOfJumpsLeft--;
}
