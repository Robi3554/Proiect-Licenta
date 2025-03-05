using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager Instance;

    [SerializeField]
    private PlayerData playerData;

    [Header("Move State")]
    public float moveVelocity;

    [Header("Jump State")]
    public float jumpVelocity;
    public int amountOfJumps;

    [Header("Dash State")]
    public float dashVelocity;

    [Header("Attack State")]
    public float attackSpeed;

    [Header("Heal State")]
    public float healAmount;
    public float healsLeft;
    public float healCooldown;

    [Header("Fire Element")]
    public float fireDuration;
    public float timeBetweenBurn;
    public float burnDamage;

    [Header("Ice Element")]
    public float slowDuration;
    public float slowAmount;

    [Header("Bonus Effects")]
    public bool statsWontGoDown;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InitializeStats(playerData);
    }

    private void InitializeStats(PlayerData data)
    {
        moveVelocity = data.moveVelocity;
        jumpVelocity = data.jumpVelocity;
        amountOfJumps = data.amountOfJumps;
        dashVelocity = data.dashVelocity;
        attackSpeed = data.attackSpeed;
        healAmount = data.healAmount;
        healCooldown = data.healCooldown;
        healsLeft = data.healsLeft;
        fireDuration = data.fireDuration;
        timeBetweenBurn = data.timeBetweenBurn;
        burnDamage = data.burnDamage;
        slowDuration = data.slowDuration;
        slowAmount = data.slowAmount;
        statsWontGoDown = data.statsWontGoDown;
    }

    void Update()
    {
        
    }
}
