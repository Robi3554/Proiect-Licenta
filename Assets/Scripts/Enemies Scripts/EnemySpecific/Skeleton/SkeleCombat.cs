using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeleCombat : Combat
{
    [SerializeField]
    private Skeleton skele;

    protected override void Awake()
    {
        skele = GetComponentInParent<Skeleton>();

        if(skele != null)
        {
            Debug.Log("Skeleton Component Present");
        }
    }

    public override void Damage(float amount)
    {
        if(skele.stateMachine.GetCurrentStateAsString().CompareTo("playerDetectedState") != 0)
        {
            base.Damage(amount);
        }
        else
        {
            Debug.Log("Player Hit Blocked!");
            Stats?.DecreaseHealth(0);
        }
    }
}
