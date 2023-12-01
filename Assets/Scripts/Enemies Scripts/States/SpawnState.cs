public class SpawnState : State
{
    protected Spawner spawner;

    protected D_SpawnState stateData;

    protected bool isPlayerInMinAggroRange;
    protected bool isAnimationFinished;

    public SpawnState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_SpawnState stateData) : base(stateMachine, entity, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
    }

    public override void Enter()
    {
        base.Enter();

        isAnimationFinished = false;
        entity.atsm.spawnState = this;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void ToSpawn()
    {
        spawner.Spawn();
    }
}
