using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }

    protected CollisionSenses Collision { get => collision ??= core.GetCoreComponent<CollisionSenses>(); }

    private Movement movement;

    private CollisionSenses collision;

    public FiniteStateMachine stateMachine;

    public D_Entity entityData;

    public int lastDamageDir { get; private set; }
    public Animator anim { get; private set; }
    public AnimationToStateMachine atsm { get; private set; }
    public Core core { get; private set; }

    [SerializeField]
    protected Transform
        wallCheck,
        ledgeCheck,
        playerCheck;

    [SerializeField]
    internal EnemySpawner es;

    private Vector2 velocityWorkspace;

    private float lastDamageTime;

    protected bool isStunned;
    protected bool isDead;

    public virtual void Awake()
    {
        core  = GetComponentInChildren<Core>();

        anim = GetComponent <Animator>();
        atsm = GetComponent<AnimationToStateMachine>();

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        core.LogicUpdate();

        stateMachine.currentState.LogicUpdate();

        if(Time.time >= lastDamageTime + entityData.stunRecoveryTime)
        {
            ResetStunResistance();
        }
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();

        anim.SetFloat("yVelocity", Movement.rb.velocity.y);

        anim.speed = entityData.animSpeed;
    }

    public virtual bool CheckPlayerInMinAggroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAggroRange, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAggroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxAggroRange, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }

    public virtual void DamageHop(float velocity)
    {
        velocityWorkspace.Set(Movement.rb.velocity.x, velocity);
        Movement.rb.velocity = velocityWorkspace;
    }

    public virtual void ResetStunResistance()
    {
        isStunned = false;
    }

    public int GetFacingDir()
    {
        return Movement.facingDir;
    }

    public virtual void OnDrawGizmos()
    {
        if(core != null)
        {
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * Movement.facingDir * Collision.WallCheckDistance));
            Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));

            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance), 0.2f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAggroRange), 0.2f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAggroRange), 0.2f);
        }
    }
}
