using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RockAttack : MonoBehaviour
{
    [SerializeField]
    private D_MeleeAttack data;
    [SerializeField]
    private Transform atkPos;
    [SerializeField]
    private Vector2 size;
    [SerializeField]
    private float delay;

    private Animator anim;

    private BoarWarrior bw;

    void Awake()
    {
        bw = GetComponentInParent<BoarWarrior>();

        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapBoxAll(atkPos.position, size, data.whatIsPlayer);

        StartCoroutine(DisableCo(delay));

        foreach (Collider2D collider in detectedObjects)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(data.attackDamage);
            }

            IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

            if (knockbackable != null)
            {
                knockbackable.Knockback(data.knockbackAngle, data.knockbackStrength, bw.GetFacingDir());
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(atkPos.position, size);
    }

    private IEnumerator DisableCo(float value)
    {
        yield return new WaitForSeconds(value);

        gameObject.SetActive(false);
    }
}
