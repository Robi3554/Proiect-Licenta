using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSOData
{
    public bool statsWontGoDown;

    public float moveVelocity;

    public float jumpVelocity;
    public int ammountOfJumps;

    public float attackSpeed;

    public float healAmmount;
    public float healsLeft;
    public float healCooldown;

    public float fireDuration;
    public float timeBetweenBurn;
    public float burnDamage;

    public float slowDuration;
    public float slowAmmount;

    public PlayerSOData()
    {
        statsWontGoDown = false;
        moveVelocity = 10;
        jumpVelocity = 25;
        ammountOfJumps = 1;
        attackSpeed = 1;
        healAmmount = 35;
        healsLeft = 1;
        healCooldown = 10;
        fireDuration = 4;
        timeBetweenBurn = 2;
        burnDamage = 6;
        slowDuration = 4;
        slowAmmount = 2;
    }
}
