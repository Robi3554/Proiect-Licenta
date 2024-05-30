using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State Data/Melee Attack State")]
public class D_MeleeAttack : ScriptableObject
{
    public bool canLightOnFire;

    public float attackRadius = 0.5f;
    public float attackDamage = 10;

    public Vector2 knockbackAngle = Vector2.one;
    public float knockbackStrength = 10f;

    public LayerMask whatIsPlayer;

    [Header("Fire Attack")]
    public float burnDuration = 4f;
    public float timeBetweenBurn = 1f;
    public float burnDamage = 10f;

    [Header("Ice Attack")]
    public float slowDuration = 5f;

}
