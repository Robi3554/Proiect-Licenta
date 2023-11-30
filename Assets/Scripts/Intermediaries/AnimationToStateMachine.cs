using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
    public AttackState attackState;

    public Exec_Spawn_State spawnState;

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
        spawnState.ToSpawn();
    }
}
