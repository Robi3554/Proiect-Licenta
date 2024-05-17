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

    private BoarWarrior bw;

    private LayerMask maskToHit;

    private string layerToExclude = "Damageable";

    void Awake()
    {
        bw = GetComponentInParent<BoarWarrior>();

        maskToHit = ~LayerMask.GetMask("Damageable");
    }

    public void Attack()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapBoxAll(atkPos.position, size, maskToHit);

        StartCoroutine(DisableCo(delay));

        foreach (Collider2D col in detectedObjects)
        {
            IDamageable damageable = col.GetComponent<IDamageable>();

            if (damageable != null)
            {
                if(col.gameObject.layer != LayerMask.NameToLayer(layerToExclude))
                    damageable.Damage(data.attackDamage);
            }

            IKnockbackable knockbackable = col.GetComponent<IKnockbackable>();

            if (knockbackable != null)
            {
                if (col.gameObject.layer != LayerMask.NameToLayer(layerToExclude))
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
