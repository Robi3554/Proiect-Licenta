using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
    public AttackState attackState;

    public SpawnState spawnState;

    public Exec_Teleport_State teleportState;

    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }

    private void ToSpawn()
    {
        if (spawnState != null)
        {
            spawnState.ToSpawn();
        }
        else
        {
            Debug.LogError("spawnState is null. Make sure it's properly initialized.");
        }
    }

    private void ToTeleport()
    {
        if(teleportState != null)
        {
            teleportState.ToTeleport();
        }
        else
        {
            Debug.LogError("TeleportState is null!");
        }
    }
}
