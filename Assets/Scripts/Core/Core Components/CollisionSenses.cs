using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    
    private Movement movement;

    #region Check Transforms
    public Transform GroundCheck
    {
        get => GenericNotImplementedError<Transform>.TryGet(groundCheck, transform.parent.name);
        private set => groundCheck = value; 
    }
    public Transform WallCheck
    {
        get => GenericNotImplementedError<Transform>.TryGet(wallCheck, transform.parent.name);
        private set => groundCheck = value;
    }
    public Transform LedgeCheckHorizontal 
    {
        get => GenericNotImplementedError<Transform>.TryGet(ledgeCheckHorizontal, transform.parent.name);
        private set => groundCheck = value;
    }
    public Transform LedgeCheckVertical 
    {
        get => GenericNotImplementedError<Transform>.TryGet(ledgeCheckVertical, transform.parent.name);
        private set => groundCheck = value;
    }
    public Transform CeilingCheck 
    {
        get => GenericNotImplementedError<Transform>.TryGet(ceilingCheck, transform.parent.name);
        private set => groundCheck = value;
    }

    public float GroundCheckRadius { get => groundCheckRadius; set => groundCheckRadius = value; }
    public float WallCheckDistance { get => wallCheckDistance; set => wallCheckDistance = value; }

    public LayerMask WhatIsGround { get => whatIsGround; set => whatIsGround = value; }

    public LayerMask WhatIsPlatform { get => whatIsPlatform; set => whatIsPlatform = value; }

    [SerializeField]
    private Transform
        groundCheck,
        wallCheck,
        ledgeCheckHorizontal,
        ledgeCheckVertical,
        ceilingCheck;

    [SerializeField]
    private float groundCheckRadius;
    [SerializeField] 
    private float wallCheckDistance;

    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask whatIsPlatform;
    #endregion

    public bool Ceiling
    {
        get => Physics2D.OverlapCircle(CeilingCheck.position, groundCheckRadius, whatIsGround);
    }

    public bool Ground
    {
        get => Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);
    }

    public bool Platform
    {
        get => Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsPlatform);
    }

    public bool WallFront
    {
        get => Physics2D.Raycast(WallCheck.position, Vector2.right * Movement.facingDir, wallCheckDistance, whatIsGround);
    }

    public bool LedgeHorizontal
    {
        get => Physics2D.Raycast(LedgeCheckHorizontal.position, Vector2.right * Movement.facingDir, wallCheckDistance, whatIsGround);
    }

    public bool LedgeVertical
    {
        get => Physics2D.Raycast(LedgeCheckVertical.position, Vector2.down, wallCheckDistance, whatIsGround);
    }

    public bool LedgeVerticalP
    {
        get => Physics2D.Raycast(LedgeCheckVertical.position, Vector2.down, wallCheckDistance, whatIsPlatform);
    }

    public bool WallBack
    {
        get => Physics2D.Raycast(WallCheck.position, Vector2.right * -Movement.facingDir, wallCheckDistance, whatIsGround);
    }
}
