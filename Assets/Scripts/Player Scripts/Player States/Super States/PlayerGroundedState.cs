using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerGroundedState : PlayerState
{
    #region Input
    protected int xInput;
    protected int yInput;

    private bool jumpInput;
    private bool grabImput;
    private bool dashInput;
    #endregion

    #region Checks
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isTouchingLedge;

    protected bool isTouchingCeiling;
    #endregion

    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    private CollisionSenses CollisionSenses
    {
        get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
    }
    private CollisionSenses collisionSenses;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        if(CollisionSenses != null)
        {
            isGrounded = CollisionSenses.Ground;
            isTouchingWall = CollisionSenses.WallFront;
            isTouchingLedge = CollisionSenses.LedgeHorizontal;
            isTouchingCeiling = CollisionSenses.Ceiling;
        }    
    }

    public override void Enter()
    {
        base.Enter();

        player.jumpState.ResetAmmountOfJumpsLeft();
        player.dashState.ResetCanDash();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.inputHandler.normalizedInputX;
        yInput = player.inputHandler.normalizedInputY;
        jumpInput = player.inputHandler.jumpInput;
        grabImput = player.inputHandler.grabInput;
        dashInput = player.inputHandler.dashInput;

        if (player.inputHandler.attackInputs[(int)CombatInputs.primary] && !isTouchingCeiling)
        {
            stateMachine.ChangeState(player.primaryAttackState);
        }
        else if(jumpInput && player.jumpState.CanJump() && !isTouchingCeiling)
        {
            stateMachine.ChangeState(player.jumpState);
        }
        else if(!isGrounded)
        {
            player.inAirState.StartCoyoteTime();
            stateMachine.ChangeState(player.inAirState);
        }
        //else if(isTouchingWall && grabImput && isTouchingLedge)
        //{
        //    stateMachine.ChangeState(player.wallGrabState);
        //}
        else if (dashInput && player.dashState.CheckIfCanDash() && !isTouchingCeiling)
        {
            stateMachine.ChangeState(player.dashState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
