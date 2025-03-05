using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDataPersistence
{
    #region State Variables
    public PlayerStateMachine stateMachine {  get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerInAirState inAirState { get; private set; }
    public PlayerLandState landState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerAttackState primaryAttackState { get; private set; }

    public PlayerHealState healState { get; private set; }

    public PlayerData playerData;
    #endregion

    #region Components
    public Core core { get; private set; }

    public Animator anim { get; private set; }

    public Rigidbody2D rb { get; private set; }

    public PlayerInputHandler inputHandler { get; private set; }

    public Transform dashDirectionIndicator { get; private set; }

    public BoxCollider2D moveCollider { get; private set; }

    public PlayerInventory inventory { get; private set; }
    #endregion

    #region Other Variables
    //private Vector2 workSpace;

    [SerializeField]
    internal bool
        canLightOnFire,
        canSlow,
        canCauseExplosions,
        canStealLife,
        canNegateHits;

    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        core = GetComponentInChildren<Core>();

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, playerData, "idle");
        moveState = new PlayerMoveState(this, stateMachine, playerData, "move");
        jumpState = new PlayerJumpState(this, stateMachine, playerData, "inAir");
        inAirState = new PlayerInAirState(this, stateMachine, playerData, "inAir");
        landState = new PlayerLandState(this, stateMachine, playerData, "land");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, playerData, "wallSlide");
        wallJumpState = new PlayerWallJumpState(this, stateMachine, playerData, "inAir");
        dashState = new PlayerDashState(this, stateMachine, playerData, "dash");
        primaryAttackState = new PlayerAttackState(this, stateMachine, playerData, "attack");
        healState = new PlayerHealState(this, stateMachine, playerData, "idle");
    }

    private void Start()
    {
        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

        inputHandler = GetComponent<PlayerInputHandler>();

        moveCollider = GetComponent<BoxCollider2D>();

        inventory = GetComponent<PlayerInventory>();

        dashDirectionIndicator = transform.Find("DashDirectionIndicator");

        primaryAttackState.SetWeapon(inventory.weapons[(int)CombatInputs.primary]);

        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        core.LogicUpdate();
        stateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
    #endregion

    #region Other Functions

    private void AnimationTirgger() => stateMachine.currentState.AnimationTrigger();

    private void AnimationFinishtrigger() => stateMachine.currentState.AnimationFinishTrigger();

    internal int GetDirection()
    {
        if(transform.rotation.y == 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public virtual void LoadData(GameData data)
    {
        Scene scene = SceneManager.GetActiveScene();

        if (data.levelData.ContainsKey(scene.name))
        {
            Vector3 playerPositionForThisScene = data.levelData[scene.name].playerPos;
            transform.position = playerPositionForThisScene;
        }
        else
        {
            Debug.LogError("Failed to get data for scene with name: " + scene.name
              + ". it may need to be added to the GameData constructor.");
        }
        //transform.position = data.levelData[scene.name].playerPos;

        playerData.statsWontGoDown = data.soData.statsWontGoDown;
        playerData.moveVelocity = data.soData.moveVelocity;
        playerData.jumpVelocity = data.soData.jumpVelocity;
        playerData.amountOfJumps = data.soData.ammountOfJumps;
        playerData.attackSpeed = data.soData.attackSpeed;
        playerData.healAmount = data.soData.healAmmount;
        playerData.healsLeft = data.soData.healsLeft;
        playerData.healCooldown = data.soData.healCooldown;
        playerData.fireDuration = data.soData.fireDuration;
        playerData.timeBetweenBurn = data.soData.timeBetweenBurn;
        playerData.burnDamage = data.soData.burnDamage;
        playerData.slowDuration = data.soData.slowDuration;
        playerData.slowAmount = data.soData.slowAmmount;
    }

    public virtual void SaveData(GameData data)
    {
        Scene scene = SceneManager.GetActiveScene();
        data.levelData[scene.name].playerPos = transform.position;

        data.soData.statsWontGoDown = playerData.statsWontGoDown;
        data.soData.moveVelocity = playerData.moveVelocity;
        data.soData.jumpVelocity = playerData.jumpVelocity;
        data.soData.ammountOfJumps = playerData.amountOfJumps;
        data.soData.attackSpeed = playerData.attackSpeed;
        data.soData.healAmmount = playerData.healAmount;
        data.soData.healsLeft = playerData.healsLeft;
        data.soData.healCooldown = playerData.healCooldown;
        data.soData.fireDuration = playerData.fireDuration;
        data.soData.timeBetweenBurn = playerData.timeBetweenBurn;
        data.soData.burnDamage = playerData.burnDamage;
        data.soData.slowDuration = playerData.slowDuration;
        data.soData.slowAmmount = playerData.slowAmount;
    }

    #endregion
}
