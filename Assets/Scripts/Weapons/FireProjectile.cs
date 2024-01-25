using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField]
    private Transform firePos;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private Swordsman player;

    private void Fire()
    {
        if (player.canShoot)
        {
            Instantiate(projectile, firePos.position, firePos.rotation);
        }
    }

}
