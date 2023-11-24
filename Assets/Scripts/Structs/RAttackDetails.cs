using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public struct RAttackDetails
{
    public string attackName;
    public float moveSpeed;
    public float damageAmount;
    public float projectileSpeed;
    public float distance;
    public int nrPorjectiles;

    public float knockbackStrength;
    public Vector2 knockbackAngle;
}
