using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAggresiveWeapon : Weapon
{
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }

    private Movement movement;

    protected RangedWeaponData rangedWeaponData;

    protected GameObject projectile;

    protected AHProjectile projectileScript;

    protected RAttackDetails details;

    public Transform firePoint;

    protected override void Awake()
    {
        base.Awake();

        if (weaponData.GetType() == typeof(RangedWeaponData))
        {
            rangedWeaponData = (RangedWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("Wrong Data For The Weapon");
        }
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        ShootProjectile();
    }

    public void ShootProjectile()
    {
        projectile = Instantiate(rangedWeaponData.projectile, firePoint.position, firePoint.rotation);
        projectileScript = projectile.GetComponent<AHProjectile>();
        projectileScript.ShootProjectile(rangedWeaponData.AttackDetails[attackCounter].projectileSpeed, rangedWeaponData.AttackDetails[attackCounter].distance, rangedWeaponData.AttackDetails[attackCounter].damageAmount,
            rangedWeaponData.AttackDetails[attackCounter].knockbackAngle, rangedWeaponData.AttackDetails[attackCounter].knockbackStrength, Movement.facingDir);
    }
}
