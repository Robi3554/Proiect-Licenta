using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float damageHopSpeed = 3f;

    public float ledgeCheckDistance = 0.4f;

    public float minAggroRange = 3f;
    public float maxAggroRange = 4f;

    public float stunResistance = 3f;
    public float stunRecoveryTime = 2f;

    public float closeRangeActionDistance = 1f;

    public float animSpeed = 1f;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
