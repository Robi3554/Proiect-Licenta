using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerAbilityState
{
    private int wallJumpDir;

    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.inputHandler.UseJumpInput();
        player.jumpState.ResetAmmountOfJumpsLeft();
        Movement?.SetVelocity(playerData.wallJumpVelocity, playerData.wallJumpAngle, wallJumpDir);
        Movement?.CheckIfShouldFlip(wallJumpDir);
        player.jumpState.DecreaseAmmountOfJumpsLeft();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.anim.SetFloat("yVelocity", Movement.currentVelocity.y);
        player.anim.SetFloat("xVelocity", Mathf.Abs(Movement.currentVelocity.x));

        if(Time.time >= startTime + playerData.wallJumpTime)
        {
            isAbilityDone = true;
        }
    }

    public void DetermineWallJumpDirection(bool isTouchingWall)
    {
        if (isTouchingWall)
        {
            wallJumpDir = -Movement.facingDir;
        }
        else
        {
            wallJumpDir = Movement.facingDir;
        }
    } 
}
