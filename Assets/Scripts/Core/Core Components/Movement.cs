using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : CoreComponent
{
    public Rigidbody2D rb { get; private set; }

    private Vector2 workSpace;

    public int facingDir {  get; private set; }

    public Vector2 currentVelocity { get; private set; }

    public bool canSetVelocity { get; set; }

    protected override void Awake()
    {
        base.Awake();

        rb = GetComponentInParent<Rigidbody2D>();

        facingDir = 1;

        canSetVelocity = true;
    }

    public override void LogicUpdate()
    {
        currentVelocity = rb.velocity;
    }

    #region Set Functions
    public void SetVelocityZero()
    {
        workSpace = Vector2.zero;
        SetFinalVelocity();
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();

        workSpace.Set(angle.x * velocity * direction, angle.y * velocity);

        SetFinalVelocity();

    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        workSpace = direction * velocity;

        SetFinalVelocity();
    }

    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, currentVelocity.y);

        SetFinalVelocity();
    }

    public void SetVelocityY(float velocity)
    {
        workSpace.Set(currentVelocity.x, velocity);

        SetFinalVelocity();
    }

    private void SetFinalVelocity()
    {
        if (canSetVelocity)
        {
            rb.velocity = workSpace;
            currentVelocity = workSpace;
        }
    }

    public void Flip()
    {
        facingDir *= -1;

        rb.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void CheckIfShouldFlip(int xinput)
    {
        if (xinput != 0 && xinput != facingDir)
        {
            Flip();
        }
    }
    #endregion

}
