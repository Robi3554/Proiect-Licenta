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
    private Player player;

    private void Fire()
    {
        if (player.canFire)
        {
            Instantiate(projectile, firePos.position, firePos.rotation);
        }
    }

}
