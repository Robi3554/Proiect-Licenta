using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using FMOD.Studio;

public class Movement : CoreComponent
{
    protected CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }

    private CollisionSenses collisionSenses;

    public Rigidbody2D rb { get; private set; }

    private Vector2 workSpace;

    public int facingDir {  get; private set; }

    public Vector2 currentVelocity { get; private set; }

    public bool canSetVelocity { get; set; }

    private EventInstance playerWalk;

    protected override void Awake()
    {
        base.Awake();

        rb = GetComponentInParent<Rigidbody2D>();

        facingDir = 1;

        canSetVelocity = true;
    }

    protected void Start()
    {
        playerWalk = AudioManager.Instance.CreateEventInstance(FMODEvents.Instance.playerWalk);
    }

    public override void LogicUpdate()
    {
        currentVelocity = rb.velocity;
    }

    #region Set Functions
    public void SetVelocityZero()
    {
        workSpace = Vector2.zero;
        UpdateSound();
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

            UpdateSound();
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

    private void UpdateSound()
    {
        if (gameObject.CompareTag("Player"))
        {
            if (rb.velocity.x != 0 && (CollisionSenses.Ground || CollisionSenses.Platform))
            {
                PLAYBACK_STATE playback_state;

                playerWalk.getPlaybackState(out playback_state);

                if (playback_state.Equals(PLAYBACK_STATE.STOPPED))
                {
                    playerWalk.start();
                }
            }
            else
            {
                playerWalk.stop(STOP_MODE.ALLOWFADEOUT);
            }
        }   
    }
}
