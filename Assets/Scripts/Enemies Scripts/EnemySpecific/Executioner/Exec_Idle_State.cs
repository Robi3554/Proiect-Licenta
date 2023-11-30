using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Exec_Idle_State : IdleState
{
    private Executioner exec;

    private Spawner spawner;

    public Exec_Idle_State(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_IdleState stateData, Executioner exec) : base(stateMachine, entity, animBoolName, stateData)
    {
        this.exec = exec;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        spawner = exec.GetComponent<Spawner>();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        CountAndCheck();

        base.LogicUpdate();

        if (isPlayerInMinAggroRange && Time.time > stateData.maxIdleTime)
        {
            stateMachine.ChangeState(exec.spawnState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void CountAndCheck()
    {
        if (spawner == null)
        {
            Debug.LogError("Spawner is null.");
            return;
        }
        else if(spawner.enemyPrefab == null)
        {
            Debug.LogError("EnemyPrefab is null");
        }

        GameObject[] instances = GameObject.FindObjectsOfType<GameObject>();

        int currentCount = 0;

        foreach (GameObject instance in instances)
        {
            GameObject correspondingPrefab = PrefabUtility.GetCorrespondingObjectFromSource(instance);

            if (correspondingPrefab != null && correspondingPrefab == spawner.enemyPrefab)
            {
                currentCount++;
            }
            else
            {
                Debug.LogError("CorrespoingPrefab is NULL!!");
                return;
            }
        }

        Debug.Log($"Current count: {currentCount}");
    }
}
